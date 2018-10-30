from . import jieba
from .jieba import analyse
from .jieba import posseg as pseg


def use_parallel(n=4):
    # 并行计算
    try:
        jieba.enable_parallel(n)
    except NotImplementedError as err:
        print(err)


def get_segmentation(line, print_=False):
    '''
    获取分词文本
    '''
    jieba.load_userdict('wordSegment\\kw.txt')
    res = jieba.cut(line.strip(), HMM=False)
    if print_:
        print(','.join(list(res)))
    return list(res)


def get_keywords(line):
    '''
    获取句子关键词
    '''
    return jieba.analyse.textrank(line)


def get_posseg(line):
    return ' '.join(f'{word}/{flag}' for word, flag in pseg.cut(line, HMM=False))


def load_dict(path):
    with open(path) as file:
        jieba.load_userdict(file)

if __name__ == '__main__':
    pass