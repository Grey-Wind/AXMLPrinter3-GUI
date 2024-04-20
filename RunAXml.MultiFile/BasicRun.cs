using Login;

namespace RunAXml.MultiFile
{
    public class BasicRun
    {
        /// <summary>
        /// 同步运行AXML
        /// </summary>
        /// <param name="folderPath">输入文件夹路径</param>
        public static async Task<string> RunAsync(string inputFolderPath, string outputFolderPath, bool Async = false)
        {
            string allFilePath = GetFile(inputFolderPath);
            
            if(Async == true)
            {
                await ConvertAXml.ConvertAsync(allFilePath, outputFolderPath);
            }
            else
            {
                ConvertAXml.Convert(allFilePath, outputFolderPath);
            }

            return null!;
        }


        public static async Task RunAsync(string inputFolderPath, string outputFolderPath)
        {
            await Task.Run(() => RunAsync(inputFolderPath, outputFolderPath, true));
        }

        private static string GetFile(string folderPath)
        {
            try
            {
                // 获取文件夹中所有文件的路径
                string[] files = Directory.GetFiles(folderPath, "*.xml", SearchOption.AllDirectories);

                // 用于存储文件路径的列表
                List<string> filePaths = [];

                // 遍历文件路径并输出文件名
                foreach (string filePath in files)
                {
                    // 使用FileInfo类获取文件信息
                    FileInfo fileInfo = new(filePath);

                    // 将文件路径添加到列表中
                    filePaths.Add(fileInfo.FullName);
                }

                if (filePaths.Count == 0)
                {
                    return "未寻找到任何Xml文件";
                }

                // 将文件路径列表合并成一个字符串，每个路径占据一行
                string combinedPaths = string.Join(Environment.NewLine, filePaths);

                // 返回合并后的路径字符串
                return combinedPaths;
            }
            catch (Exception ex)
            {
                Console.WriteLine("发生错误：" + ex.Message);
                return ex.Message;
            }
        }
    }
}
