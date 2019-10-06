using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doukaku.Org;
using System.Linq;
using System.Collections.Generic;

namespace ShiritoriTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Word> list = WordsFile.GetWordList(120);
            WordChainSolver wc = new WordChainSolver(list);
            List<Word> maxList = new List<Word>();
            foreach (Word startWord in list)
            {
                List<Word> temp = wc.Solve(startWord).GetWordList().ToList();
                if (temp.Count > maxList.Count)
                {
                    maxList = temp;
                }
            }
            foreach (Word item in maxList)
            {
                Console.WriteLine(item.Text);
            }
        }
    }
}
