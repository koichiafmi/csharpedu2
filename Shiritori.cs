using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodohukenShiritori
{
    public class Shiritori
    {
        public List<Todohuken> DoShiritori(string path)
        {
            return ShiritoriCore(ReadTodohukenTxt(path));
        }

        #region Private
        private List<Todohuken> ShiritoriCore(List<Todohuken> list)
        {
            List<Todohuken> result = new List<Todohuken>();

            int i = 0;
            while (i != list.Count)
            {
                if(list.Count(n => n.Kashiramoji == list[i].Ketsunomoji) == 0 && 
                   list.Count(n => n.Ketsunomoji == list[i].Kashiramoji) == 0)
                {
                    list.RemoveAt(i);
                }
                else
                {
                    ++i;
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine(item.Name);
            }



            return result;
        }

        private string GetName(List<Todohuken> list, int index)
        {
            foreach (var item in list)
            {
                if (index == item.Index)
                {
                    return item.Name;
                }
            }
            return string.Empty;
        }

        private List<Todohuken> ReadTodohukenTxt(string path)
        {
            var list = new List<Todohuken>();
            //txt読み込み
            using (var sr = new StreamReader(path))
            {
                int index = 0;
                while (sr.Peek() != -1)
                {
                    var todohuken = new Todohuken(sr.ReadLine(), index);
                    list.Add(todohuken);
                    ++index;
                }
            }
            return list;
        }

        private List<List<int>> CreateSortPatterns(int numberOfIndex)
        {
            List<List<int>> patterns = new List<List<int>>();

            //初期化
            List<int> pattern = new List<int>();
            for (int i = 0; i < numberOfIndex; i++)
            {
                pattern.Add(i);
            }

            //組み合わせの数
            for (int kumiawaseLength = 1; kumiawaseLength < numberOfIndex; kumiawaseLength++)
            {
                for (int index = 0; index < kumiawaseLength; index++)
                {
                }
            }



            for (int i = 0; i < numberOfIndex; i++)
            {
                List<int> list = new List<int>();
                list.Add(i);
                for (int j = 0; j < numberOfIndex; j++)
                {
                    if (!list.Contains(j))
                    {
                        list.Add(j);
                    }
                }
            }





            return patterns;
        }
        #endregion
    }
}
