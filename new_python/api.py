import binascii
import json
from threading import Thread

from elasticsearch import Elasticsearch

from mongo import MongoConn


def _save_query(question,
                jieba_segment,
                fool_segment,
                jieba_keywords,
                fool_keywords,
                fool_search_result,
                jieba_search_result
                ):
    '''
    将查询的内容以及查询的结果存入数据库做结果的分析
    '''
    database = 'Unicom'
    collection = 'query_test'

    document = {
        'question': question, 
        'jiebaSegment': jieba_segment,
        'foolSegment': fool_segment,
        'jiebaKeywords': jieba_keywords,
        'foolKeywords': fool_keywords,
        'foolSearchResult': fool_search_result,
        'jiebaSearchResult': jieba_search_result,
        'reason': '',
    }
    
    try:
        with MongoConn(database, collection) as conn:
            conn.insert_one(document)
    except Exception as err:
        print(err)
        return False, err

    return True


def remove(words):
    ret = []
    with MongoConn('Unicom', 'propernouns') as proper:
        for word in words:
            if proper.count_documents({'properNouns': word}) > 0:
                ret.append(word)
    return ret

def _search():
    '''
    使用elasticsearch对word进行匹配
    '''

    with open('cfg.json') as cfg:
        config = json.load(cfg)

    es = Elasticsearch(':'.join([config['esHost'], config['esPort']]))
    query = {
        "query": {
            "match": {
                "allName": {
                    "query": "",
                    "fuzziness": "AUTO",
                    "operator":  "and",
                    # "minimum_should_match": "75%",
                }
            }
        },
        'size': 20,
    }

    # from wordSegment import segment

    def __search(words, index='unicom'):

        # words = get_keywords(line)
        # jieba_words = jiebaSeg.get_keywords(line)

        print(f'begin search: {words}')

        query['query']['match']['allName']['query'] = ' '.join(words)
        print(query['query']['match']['allName']['query'])
        search_result = es.search(index=index, body=query)

        # query['query']['match']['allName']['query'] = ' '.join(jieba_words)
        # jieba_search_result = es.search(index=index, body=query)

        # return search_result, jieba_search_result
        return search_result


    return __search


def format(data):
    '''
    将es的查询结果整理成（电话，allname）的形式返回结果
    '''
    with MongoConn('Unicom', 'priority') as blacklist:
        return [
            {
                # 电话解码
                'phoneNum': binascii.a2b_hex(result['_source']['phoneNum']).decode(), 
                'allName': result['_source']['allName'].replace(',', ' ').strip(), 
            }
            for result in sorted(data['hits']['hits'], key=lambda d: d['_source']['frequency'])
            # 不显示黑名单中的电话信息
            if blacklist.count_documents({'unitId':result['_source']['unitId']}) == 0
        ]


def replace(words):
    if isinstance(words, str):
        if ',' in words:
            words = words.split(',')
        else:
            words = words.split()

    indexes = []
    print('before replace:', words)
    with MongoConn('Unicom', 'synonym') as synonym:
        for index, word in enumerate(words):
            regex = f'(.*/{word}/.*)|(/{word}$)|(^{word}/.*)|(^{word}$)'
            if synonym.count_documents({'synonyms': {'$regex': regex}}):
                standard = synonym.find_one({'synonyms': {'$regex': regex}})['standard']
                words[index] = standard
                indexes.append(index)
    
    print('after replace:', words)
    return words, indexes


def assignment(fun):
    global query
    query = fun()

query = None
Thread(target=assignment, args=(_search,)).start()
