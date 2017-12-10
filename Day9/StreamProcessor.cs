namespace Day9
{
    public class StreamProcessor
    {
        public int Score(string stream)
        {
            var level = 1;
            var score = 0;
            var mode = '{';
            var garbageCount = 0;

            for (var i = 0; i < stream.ToCharArray().Length; i++)
            {
                var character = stream.ToCharArray()[i];
                if (mode.Equals('<') && !character.Equals('!') && !character.Equals('>'))
                {
                    garbageCount++;
                }

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

            return garbageCount;
        }
    }
}
