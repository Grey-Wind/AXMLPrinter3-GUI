using System.Text.RegularExpressions;

namespace AXmlColorBugFix
{
    public class Fix
    {
        public static string FixColorBug(string AXmlOutput)
        {
            return RemoveFF(AXmlOutput);
        }

        private static string RemoveFF(string xml)
        {
            // 正则表达式匹配android:fillColor属性中的#FF
            Regex regex = new(@"#FF");

            // 用于构建修改后的完整XML字符串的StringBuilder
            var modifiedXmlBuilder = new System.Text.StringBuilder();

            // 将XML字符串按行分割成数组
            string[] lines = xml.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // 遍历每一行
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                // 查找匹配的属性
                Match match = regex.Match(line);
                if (match.Success)
                {
                    // 替换#FF为#
                    string modifiedLine = regex.Replace(line, "#");

                    // 将修改后的行添加到StringBuilder中
                    modifiedXmlBuilder.AppendLine(modifiedLine);
                }
                else
                {
                    // 将未修改的行添加到StringBuilder中
                    modifiedXmlBuilder.AppendLine(line);
                }
            }

            // 输出修改后的完整XML字符串
            string modifiedXml = modifiedXmlBuilder.ToString();
            Console.WriteLine(modifiedXml);

            return modifiedXml;
        }
    }
}
