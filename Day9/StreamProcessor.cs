namespace Day9
{
    public class StreamProcessor
    {
        public int Score(string stream)
        {
            var level = 1;
            var score = 0;
            var mode = '{';
            for (var i = 0; i < stream.ToCharArray().Length; i++)
            {
                var character = stream.ToCharArray()[i];
                switch (character)
                {
                    case '{' when !mode.Equals('<'):
                        score += level;
                        level++;
                        break;
                    case '}' when !mode.Equals('<'):
                        level--;
                        break;
                    case '<':
                        mode = '<';
                        break;
                    case '>':
                        mode = '{';
                        break;
                    case '!' when mode.Equals('<'):
                        i++;
                        break;
                }
            }

            return score;
        }
    }
}
