using System;
using System.Collections.Generic;
using System.Linq;

namespace Doukaku.Org
{
    // しりとりした結果を覚えておくクラス
    public class WordChainList
    {
        private List<short> _chain = new List<short>();
        private List<Word> AllWords { get; set; }

        public WordChainList(List<Word> wordList)
        {
            AllWords = wordList;
        }

        public Word LastWord
        {
            get
            {
                int ix = _chain[_chain.Count - 1];
                return AllWords[ix];
            }
        }

        public WordChainList Clone()
        {
            WordChainList wcl = new WordChainList(AllWords)
            {
                _chain = _chain.ToList()
            };
            return wcl;
        }

        public void Add(Word word)
        {
            short ix = (short)AllWords.FindIndex(x => x.Text == word.Text);
            _chain.Add(ix);
        }

        public Word Find(Func<Word, bool> pred)
        {
            foreach (Word w in GetWordList())
            {
                if (pred(w))
                {
                    return w;
                }
            }

            return null;
        }

        public IEnumerable<Word> GetWordList()
        {
            foreach (short ix in _chain)
            {
                yield return AllWords[ix];
            }
        }

        public int GetCount()
        { return _chain.Count; }

        internal void RemoveAt(int index)
        {
            _chain.RemoveAt(index);
        }
    }
}