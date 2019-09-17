using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shiritori
{
    class Program
    {

        static void Main(string[] args)
        {
            //const string start = "ふくい";

            using (var sr = new StreamReader("todohuken.txt"))
            {
                var hoge = sr.ReadToEnd().Split('\n').ToList();
                var todohukenList = hoge.ConvertAll(p => new Todohuken(p));
                todohukenList = todohukenList
                                    .Where(p => todohukenList.Any(q => (q.end == p.first) || (q.first == p.end)))
                                    .ToList();

                var result = new List<Todohuken>();
                todohukenList.ForEach(a =>
                {
                    var r = new List<Todohuken>(todohukenList);
                    r.Remove(a);
                    var tmpResult = Shiritori(r, a);
                    if (tmpResult.Count > result.Count)
                        result = tmpResult;
                });

            }
        }

        private static List<Todohuken> Shiritori(List<Todohuken> src, Todohuken target)
        {
            var result = new List<Todohuken>();

            src.Where(a => a.first == target.end).ToList().ForEach(a =>
            {
                var r = new List<Todohuken>(src);
                r.Remove(a);
                var tmpResult = Shiritori(r, a);
                if (tmpResult.Count > result.Count)
                {
                    result = tmpResult;
                }

            });

            return result;
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