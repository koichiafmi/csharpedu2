using Doukaku.Org;
using System;
using System.Linq;

namespace TodohukenShiritori
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;
            System.Collections.Generic.List<Word> list = WordsFile.GetWordList(120);
            Word startWord = list[0];
            WordChainSolver wc = new WordChainSolver(list);
            WordChainList ans = wc.Solve(startWord);
            ans.GetWordList().ToList().ForEach(w => Console.WriteLine(w.Text));
            Console.WriteLine("{0}", ans.GetCount());
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadLine();
        }
    }
}
