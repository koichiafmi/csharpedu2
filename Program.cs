using Doukaku.Org;
using System;
using System.Linq;

namespace TodohukenShiritori
{
    class Program
    {
        private static Word startWord;
        private static WordChainSolver wc;
        private static WordChainList ans;

        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            System.Collections.Generic.List<Word> list = WordsFile.GetWordList(120);
            startWord = list[0];
            wc = new WordChainSolver(list);
            ans = wc.Solve(startWord);
            ans.GetWordList().ToList().ForEach(w => Console.WriteLine(w.Text));
            Console.WriteLine("{0}", ans.GetCount());
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadLine();
        }
    }
}
