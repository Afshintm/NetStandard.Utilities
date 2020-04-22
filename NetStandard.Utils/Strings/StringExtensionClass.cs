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
    }
}