extern alias RunShell;

using AXmlColorBugFix;
using RunAXml.MultiFile;
using RunShell::Tools.Shell;

namespace Login
{
    internal class ConvertAXml
    {
        internal static void Convert(string allFilePath, string exportPath)
        {
            // 使用 StringReader 逐行读取多行字符串
            using StringReader reader = new(allFilePath);
            string line;
            while ((line = reader.ReadLine()!) != null)
            {
                // 提取文件名
                string fileName = Path.GetFileName(line);

                // 在这里执行重复的代码，针对每一行
                View.ViewAXmlSync(line, exportPath, fileName);
            }
        }
        internal static async Task ConvertAsync(string allFilePath, string exportPath)
        {
            // 使用 StringReader 逐行读取多行字符串
            using StringReader reader = new(allFilePath);
            string line;
            while ((line = reader.ReadLine()!) != null)
            {
                // 提取文件名
                string fileName = Path.GetFileName(line);

                // 在这里执行重复的代码，针对每一行
                await View.ViewAXmlAsync(line, exportPath, fileName);
            }
        }
    }

    class View
    {
        public static void ViewAXmlSync(string filePath, string exportPath, string fileName)
        {
            string command = ".\\jre\\bin\\java.exe -jar AXMLPrinter3.jar \"" + filePath + "\"";

            string output = ShellExecutor.Cmd.User.ExecuteCmdCommand(command);

            string exportFilePath = exportPath + "\\" + OutputName.GetNewName(fileName);

            output = Fix.FixColorBug(output);

            // 使用文件写入操作
            using StreamWriter writer = new(exportFilePath);
            writer.WriteLineAsync(output);
        }

        public static async Task ViewAXmlAsync(string filePath, string exportPath, string fileName)
        {
            string command = ".\\jre\\bin\\java.exe -jar AXMLPrinter3.jar \"" + filePath + "\"";

            var output = await Task.Run(() =>
            {
                return ShellExecutor.Cmd.User.ExecuteCmdCommand(command);
            });

            string exportFilePath = exportPath + "\\" + OutputName.GetNewName(fileName);

            output = await Fix.FixColorBugAsync(output);

            // 使用异步文件写入操作
            using StreamWriter writer = new(exportFilePath);
            await writer.WriteLineAsync(output);
        }
    }
}
