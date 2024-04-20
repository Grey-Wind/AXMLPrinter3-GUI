namespace MultiFileLog
{
    public class Log
    {
        /// <summary>
        /// 传入两个字符串，如果是空的或null，则直接返回单行新字符串<br></br>
        /// 如果原字符串有内容，则直接换行添加新字符串并返回<br></br>
        /// </summary>
        /// <param name="origin">原字符串</param>
        /// <param name="newText">需要添加的字符串</param>
        /// <returns>返回的单行/多行字符串</returns>
        public static string Add(string origin, string newText)
        {
            if (string.IsNullOrEmpty(origin))
            {
                return newText;
            }
            else
            {
                return origin + "\n" + newText;
            }
        }
    }
}
