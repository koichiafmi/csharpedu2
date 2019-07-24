using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Doukaku.Org
{
    // 単語ファイルの読み込み
    // tab, カンマ、空白で区切る。
    public static class WordsFile
    {
        public static List<Word> GetWordList(int count)
        {
            List<Word> list = new List<Word>();
            using (StreamReader sr = new StreamReader(@"todohuken.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    string[] words = s.Split('\t', ' ', ',');
                    list.AddRange(words.Where(t => !string.IsNullOrEmpty(t)).Select(w => new Word(w)));
                }
            }
            return list.Take(count).ToList();
        }
    }
}