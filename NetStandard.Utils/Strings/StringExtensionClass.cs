using System.Collections;
namespace NetStandard.Utils.Strings
{
    public static class StringExtensionClass
    {
        public static string StringReverse(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            var charArray = input.ToCharArray();
            for (int i = 0; i < charArray.Length / 2; i++)
            {
                var temp = charArray[i];
                charArray[i] = charArray[charArray.Length - 1 - i];
                charArray[charArray.Length - 1 - i] = temp;
            }
            return new string(charArray);
        }

        public static IEnumerable StrReverse(this string input)
        {
            if (string.IsNullOrEmpty(input)) yield return input;
            var index = input.Length;
            do
            {
                yield return input[--index];
            } while (index > 0);
        }
        
        public static string InsertAt(this string input, char c, int index ){
            if(input==null) return null;

            var charArray = input.ToCharArray();
            var outArray = new char[input.Length+1];
            for (int i = 0,j=0; i < input.Length; i++,j++)
            {
                if (i == index)
                {
                    outArray[j] = c;
                    j++;
                }
                outArray[j] = charArray[i];
            }

            var result = new string(outArray);
            return result;
        }
        public static IEnumerable AsMyEnumerator(this string input)
        {
            if (input==null)
            {
                yield break;
            }
            foreach (var item in input.ToCharArray())
            {
                yield return item;
            }
        }
    }
}