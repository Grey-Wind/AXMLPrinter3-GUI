namespace RunAXml.MultiFile
{
    public class OutputName
    {
        public static string GetNewName(string InputFileName)
        {
            // 获取文件路径
            string directory = Path.GetDirectoryName(InputFileName)!;

            // 去除文件扩展名
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(InputFileName);

            // 合并路径和去除扩展名后的文件名
            string newPath = Path.Combine(directory, fileNameWithoutExtension);

            // 拼接文件名称
            string outputName = newPath + ".output.xml";

            // 返回名称
            return outputName;
        }
    }
}
