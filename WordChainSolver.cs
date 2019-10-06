using System.Collections.Generic;
using System.Linq;

namespace Doukaku.Org
{
    public class WordChainSolver
    {
        public List<Word> WordList { get; set; }
        public WordChainSolver(List<Word> wordList)
        {
            int i = 0;
            while (i != wordList.Count)
            {
                if (wordList.Count(n => n.First == wordList[i].Last) == 0 &&
                    wordList.Count(n => n.Last  == wordList[i].First) == 0)
                {
                    wordList.RemoveAt(i);
                }
                else
                {
                    ++i;
                }
            }
            WordList = wordList.ToList();
        }

        private Queue<WordChainList> _queue = new Queue<WordChainList>();
        public WordChainList Solve(Word word)
        {
            WordChainList firstState = new WordChainList(WordList);
            firstState.Add(word);
            WordChainList ans = firstState;
            _queue.Enqueue(firstState);
            while (_queue.Count > 0)
            {
                WordChainList curr = _queue.Dequeue();
                ans = curr;
                foreach (Word w in Candidate(curr.LastWord))
                {
                    if (ans.Find(x => x == w) != null)
                    {
                        continue;
                    }

                    curr.Add(w);
                    _queue.Enqueue(curr.Clone());
                    curr.RemoveAt(curr.GetCount() - 1);
                }

            }
            return ans;
        }
        // 候補の単語を列挙する
        private IEnumerable<Word> Candidate(Word word)
        {
            return WordList.Where(x => word.Last == x.First).ToList();
        }
    }
}