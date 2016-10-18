using System.Text.RegularExpressions;

namespace WS_Hotline.Framework.Domain.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Extension like as sql Like
        /// Use Like :
        /// bool willBeTrue = "abcdefg".Like("abcd_fg");
        /// bool willAlsoBeTrue = "abcdefg".Like("ab%f%");
        /// bool willBeFalse = "abcdefghi".Like("abcd_fg");
        /// </summary>
        /// <param name="pToSearch"></param>
        /// <param name="pToFind"></param>
        /// <returns></returns>
        public static bool Like(this string pToSearch, string pToFind)
        {
            return new Regex(@"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(pToFind, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") + @"\z", RegexOptions.Singleline).IsMatch(pToSearch);
        }
    }
}
