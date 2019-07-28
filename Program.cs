using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodohukenShiritori
{
    class Program
    {

        static void Main(string[] args)
        {
            string const start = "ふくい";

            using (var sr = new StreamReader("todohuken.txt"))
            {
                var hoge = sr.ReadToEnd().Split('\n').ToList();
                var todohukenList = hoge.ConvertAll(p => new Todohuken(p));
                todohukenList = todohukenList
                                    .Where(p => todohukenList.Any(q => q.end == p.first))
                                    .Where(p => todohukenList.Any(q => q.first == p.end))
                                    .ToList();

                var table =
            }
        }
    }

    class Todohuken
    {
        public string name;
        public string first;
        public string end;

        public Todohuken(string item)
        {
            name = item;
            first = item[0].ToString();
            end = item[item.Length - 1].ToString();
        }
    }
}