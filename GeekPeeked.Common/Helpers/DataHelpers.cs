using System.Text;
using System.Text.RegularExpressions;

namespace GeekPeeked.Common.Helpers
{
    public static class DataHelpers
    {
        public static string ScrubHTML(string value)
        {
            string result = value;

            result = Regex.Replace(result, @"<[^>]+>|&nbsp;", "").Trim();
            result = Regex.Replace(result, @"\s{2,}", " ");

            return result;
        }

        public static string EllipsisTruncate(string value, int length)
        {
            string result = value;

            if (length >= 3 && result.Length > length)
                result = string.Format("{0}...", result.Substring(0, length - 3));

            return result;
        }

        public static string Slugify(this string phrase)
        {
            string str = phrase.RemoveAccent().ToLower();

            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", string.Empty);

            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();

            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();

            str = Regex.Replace(str, @"\s", "-"); // hyphens   

            return str;
        }

        private static string RemoveAccent(this string txt)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(txt);

            return Encoding.ASCII.GetString(bytes);
        }
    }
}
