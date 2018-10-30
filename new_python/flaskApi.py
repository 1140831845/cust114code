from json import dumps
from threading import Thread

from flask import Flask, request, url_for
from flask_api import FlaskAPI, exceptions, status

import api
from wordSegment.segment import segment_

app = Flask(__name__)

# test function
@app.route('/hello', methods=['GET'])
def hello_word():
    txt = request.args
    return dumps({
        "hello": "word"
    })


def get_jieba_seg(text):
    '''
    param: text str
    获取jieba的分词和关键词
    '''
    segment = segment_.get_segmentation(text)
    keywords = segment_.get_keywords(text)

    return segment, keywords

def get_fool_seg(text):
    '''
    param: text str
    获取fool的分词和关键词
    '''
    segment = segment_.fool_get_segmentation(text)
    keywords = segment_.fool_get_keywords(text)

    return segment, keywords


@app.route('/search', methods=['GET'])
def search():
    '''
    提供api给调用，对传入的文本进行分词检索， 并返回结果
    '''

    # 获取需要分词的句子
    text = request.args.get('text', '')
    text = text.strip()
    print('question is:', text)
    
    # 传入参数为空抛出异常
    if not text: raise exceptions.NotAcceptable()
    
    # 获取分词
    jieba_seg, jieba_keywords = get_jieba_seg(text)
    fool_seg, fool_keywords = get_fool_seg(text)

    # 将分词结果中的词替换为数据库中存在的词
    jieba_seg, jieba_index = api.replace(jieba_seg)
    adding_keywords = [jieba_seg[index] for index in jieba_index]

    # 将关键词中的词也替换为数据库中存在的词， 并将分词中存在的关键词加入到关键词中
    jieba_keywords, jieba_index = api.replace(jieba_keywords)
    adding_keywords += jieba_keywords 
    jieba_keywords = adding_keywords

    # 去重 保持有序
    unique = set()
    order_seg = []
    for seg in jieba_seg:
        if seg not in unique:
            order_seg.append(seg)
            unique.add(seg)
    jieba_seg = order_seg

    unique.clear()
    order_seg = []
    for seg in jieba_keywords:
        if seg not in unique:
            order_seg.append(seg)
            unique.add(seg)
    jieba_keywords = order_seg
    jieba_keywords = api.remove(jieba_keywords)


    # 将分词结果中的词替换为数据库中存在的词
    fool_seg, fool_index = api.replace(fool_seg)
    adding_keywords = [fool_seg[index] for index in fool_index]

    # 将关键词中的词也替换为数据库中存在的词， 并将分词中存在的关键词加入到关键词中
    fool_keywords, fool_index = api.replace(fool_keywords)
    adding_keywords += fool_keywords
    fool_keywords = adding_keywords

    # 去重 保持有序
    unique = set()
    order_seg = []
    for seg in fool_seg:
        if seg not in unique:
            order_seg.append(seg)
            unique.add(seg)
    fool_seg = order_seg

    unique.clear()
    order_seg = []
    for seg in fool_keywords:
        if seg not in unique:
            order_seg.append(seg)
            unique.add(seg)
    fool_keywords = order_seg

    # 使用es根据关键词进行检索
    jieba_result = api.query(jieba_keywords)
    fool_result = api.query(fool_keywords)

    # 构造结果作为api返回
    jieba_result = api.format(jieba_result)
    fool_result = api.format(fool_result)


    # 构造结果将结果存入数据库中
    jieba_content = [
        f'{index}.{data["phoneNum"]},{data["allName"]}\n'
        for index, data in enumerate(jieba_result, 1)
    ]

    fool_content = [
        f'{index}.{data["phoneNum"]},{data["allName"]}\n'
        for index, data in enumerate(fool_result, 1)
    ]


    jieba_seg = ','.join(jieba_seg)
    jieba_keywords = ','.join(jieba_keywords)
    fool_seg = ','.join(fool_seg)
    fool_keywords = ','.join(fool_keywords)
    jieba_content = ''.join(jieba_content)
    fool_content = ''.join(fool_content)

    # 需要存入数据库中的结果
    save = [text, jieba_seg, fool_seg, jieba_keywords,
            fool_keywords, fool_content, jieba_content]

    Thread(target=api._save_query, args=(*save, )).start()
    # api._save_query(*save)

    return dumps({
        'jiebaSeg': jieba_seg,
        'jiebaKeywords': jieba_keywords,
        'foolSeg': fool_seg,
        'foolKeywords': fool_keywords,
        'jiebaSearchResult': jieba_result,
        'foolSearchResult': fool_result,
    })


@app.route('/word', methods=['GET', 'DELETE'])
def add_and_delete_word():
    '''
    作为api，实时往字典中增添关键词等
    '''
    if request.method == 'GET':
        word = request.args.get('word', '').strip()
        stop_word = request.args.get('stopword', '').strip()
        
        if word == '' and stop_word == '':
            print('word is None, add fail.')
            raise exceptions.NotAcceptable()
        
        if stop_word:
            segment_.add_stop_word(stop_word)

            print(f'add stopword: {stop_word} successfully')

            return dumps({
                'status': 'ok'
            })

        # 设置默认权重为2
        weight = request.args.get('weight', 2)

        weight = float(weight)

        segment_.add_word(word, weight)

        print(f'word is: {word}, weight is {weight}. add success.')

        return dumps({
            'status': 'ok'
        })

    elif request.method == 'DELETE':
        word = request.args.get('word', '').strip()
        stop_word = request.args.get('stopword', '').strip()

        if word == '' and stop_word == '':
            print('word is None, delete fail.')
            raise exceptions.NotAcceptable()
        
        if stop_word:
            segment_.delete_stop_word(word)

            print(f'delete stopword: {stop_word} successfully')

            return dumps({
                'status': 'ok'
            })

        segment_.delete_word(word)

        print(f'delete {word} success')

        return dumps({
            'status': 'ok'
        })


if __name__ == "__main__":
    app.run(debug=True, host='0.0.0.0', port=10001)
