namespace Doukaku.Org
{
    // 単語を表すクラス （最初と最後の文字を取得する機能がある）
    // ちょうちょ、きしゃ などは、「や」が最後の文字とする。
    public class Word
    {
        public string Text { get; set; }

        public Word(string word)
        {
            Text = word;
            First = ToChokuon(Text[0]);
            Last = ToChokuon(Text[Text.Length - 1]);
        }
        public char First { get; }
        public char Last { get; }

        // ッは促音だが、拗音(Youon)という変数名とする
        private const string Youon = "ァィゥェォヵヶッャュョヮ";
        private const string Chokuon = "アイウエオカケツヤユヨワ";
        private char ToChokuon(char c)
        {
            int ix = Youon.IndexOf(c);
            return ix > 0 ? Chokuon[ix] : c;
        }
    }
}