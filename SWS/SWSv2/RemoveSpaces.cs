using System;
using System.Text.RegularExpressions;

namespace SWSv2
{
    class RemoveSpaces
    {
        public string Remove(string line, string target)
        {
            string pattern = @"\s+";
            Regex regex = new Regex(pattern);
            string temp = regex.Replace(line, target);
            string result = "";
            for (int i = 0; i < temp.Length; i++)
            {
                if (Char.IsUpper(temp, i))
                    result += "| " + temp[i];
                else
                    result += temp[i];
            }
            return result.Remove(0, 4);
        }
    }
}
