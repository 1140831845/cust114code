from . import jieba
from .jieba import posseg as pseg
from .jieba import analyse
from mongo import MongoConn

from . import fool


class Segment:
    def __init__(self):
        with MongoConn('Unicom', 'propernouns') as conn, \
                MongoConn('Unicom', 'synonym') as synonym,  \
                MongoConn('Unicom', 'stopwords') as stop:
            count = 0
            for doc in conn.find():
                jieba.add_word(doc['properNouns'], doc['weight'])
                fool.add_word(doc['properNouns'], doc['weight'])
                count += 1
            
            for doc in synonym.find():
                jieba.add_word(doc['standard'], 10)
                fool.add_word(doc['standard'], 10)
                count += 1
          
            print(f'{count} keyword load success!')

            count = 0

            for doc in stop.find():
                self.add_stop_word(doc['stopword'])
                count += 1

            print(f'{count} stopword load success!')




    def use_parallel(self, n=4):
        # jieba并行计算
        try:
            jieba.enable_parallel(n)
        except NotImplementedError as err:
            print(err)

    def get_segmentation(self, line, print_=False):
        '''
        获取分词文本
        '''
        res = jieba.cut(line.strip(), HMM=False)
        if print_:
            print(','.join(list(res)))
        return list(res)

    def get_keywords(self, line):
        '''
        获取句子关键词
        '''
        return jieba.analyse.extract_tags(line, topK=30)

    def get_posseg(self, line):
        return ' '.join(f'{word}/{flag}' for word, flag in pseg.cut(line, HMM=False))

    def fool_get_segmentation(self, line, print_=False):
        '''
        获取分词文本
        '''
        res = fool.cut(line.strip())
        if print_:
            print(','.join(res[0]))
        return res[0]

    def fool_get_keywords(self, line):
        '''
        获取关键词
        '''
        word, keywords = fool.analysis(line)
        return [keyword[3] for keyword in keywords[0]]

    def add_word(self, word, weight):
        '''
        添加词语到词库
        '''
        jieba.add_word(word, weight)
        fool.add_word(word, weight)
    
    def delete_word(self, word):
        '''
        从词库中删除词语
        '''
        jieba.del_word(word)
        fool.del_word(word)
    
    def add_stop_word(self, word):
        analyse.add_stop_word(word)
    
    def delete_stop_word(self, word):
        analyse.delete_stop_word(word)
    

segment_ = Segment()
