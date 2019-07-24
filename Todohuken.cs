using System;
using Microsoft.VisualBasic;

namespace TodohukenShiritori
{
    public class Todohuken
    {
        public Todohuken(string name,int index)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("名前いれろや！！", nameof(name));
            }

            Name = name;
            Index = index;
        }
        public int Index { get; }
        public string Name { get; }
        public string Kashiramoji => Strings.Left(Name, 1);
        public string Ketsunomoji => Strings.Right(Name, 1);
    }
}
