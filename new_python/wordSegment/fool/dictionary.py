#!/usr/bin/env python
# -*-coding:utf-8-*-

from . import trie


class Dictionary():
    def __init__(self):
        self.trie = trie.Trie()
        self.weights = {}
        self.sizes = 0

    def delete_dict(self):
        self.trie = trie.Trie()
        self.weights = {}
        self.sizes = 0
    
    def del_word(self, word):
        if word in self.weights:
            del self.weights[word]
            self.sizes -= 1

    def add_dict(self, path):
        words = []

        with open(path, encoding='utf8') as f:
            for i, line in enumerate(f):
                line = line.strip("\n").strip()
                if not line:
                    continue
                line = line.split()
                word = line[0].strip()
                self.trie.add_keyword(word)
                if len(line) == 1:
                    weight = 1.0
                else:
                    weight = float(line[1])
                weight = float(weight)
                self.weights[word] = weight
                words.append(word)
        self.sizes += len(self.weights)

    def add_word(self, word, weight):

        self.trie.add_keyword(word)
        if word not in self.weights:
            self.sizes += 1
        self.weights[word] = weight

    def parse_words(self, text):
        matchs = self.trie.parse_text(text)
        return matchs

    def get_weight(self, word):
        return self.weights.get(word, 0.1)
