using System.Collections.Generic;

namespace Day4
{
    public class HighEntropyPassphrases
    {
        public int GetValidPassphraseCount(List<string> passphraseList)
        {
            if (passphraseList == null)
            {
                return 0;
            }

            var validPassphrases = 0;
            foreach (var passphrase in passphraseList)
            {
                if (!string.IsNullOrWhiteSpace(passphrase))
                {
                    if (IsListValid(passphrase))
                    {
                        validPassphrases++;
                    }
                }
            }
            return validPassphrases;
        }

        private bool IsListValid(string passphraseList)
        {
            if (ContainsAnagrams(passphraseList))
            {
                return false;
            }

            var checkedPassPhrases = new HashSet<string>();
            foreach (var passphrase in passphraseList.Split(' '))
            {
                if (checkedPassPhrases.Contains(passphrase))
                {
                    return false;
                }
                checkedPassPhrases.Add(passphrase);
            }

            return true;
        }

        public bool ContainsAnagrams(string passphraseList)
        {
            var checkedPassphrases = new HashSet<SortedSet<char>>();
            foreach (var passphrase in passphraseList.Split(' '))
            {
                var passphraseChars = new SortedSet<char>();
                foreach (var letter in passphrase.ToCharArray())
                {
                    passphraseChars.Add(letter);
                }

                foreach (var checkedPassphrase in checkedPassphrases)
                {
                    if (checkedPassphrase.SetEquals(passphraseChars))
                    {
                        return true;
                    }
                }
                checkedPassphrases.Add(passphraseChars);
            }

            return false;
        }
    }
}
