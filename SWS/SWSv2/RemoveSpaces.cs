using System;
using System.Text.RegularExpressions;

namespace SWSv2
{
    class RemoveSpaces
    {
        public string Remove(string symvol, string line, string target , int rStart, int rEnd)
        {
            if (line == null)
            {
                return "null";
            }
            else
            {
                string pattern = @"\s+";
                Regex regex = new Regex(pattern);
                string temp = regex.Replace(line, target);
                string result = "";
                for (int i = 0; i < temp.Length; i++)
                {
                    if (Char.IsUpper(temp, i))
                        result += symvol + temp[i];
                    else
                        result += temp[i];
                }
                return result.Remove(rStart, rEnd).Replace("&laquo;", string.Empty).Replace("На этой странице аниме присутствует неработающий плеер. Он находится в очереди на замену, если не хотите ждать - пишите в поддержку просьбу перезалить это аниме вне очереди. В письме указывайте название аниме и нужный перевод.", "Не лицензировано");
            }
        }
    }
}
