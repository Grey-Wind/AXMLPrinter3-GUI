using Tools.Shell;

namespace RunAXML
{
    public class Run
    {
        public static async Task<string> ViewXml(string inputFile)
        {
            return await ViewAsync(inputFile);
        }

        public static string Test()
        {
            string command = ".\\jre\\bin\\java.exe -jar AXMLPrinter3.jar";
            string output = ShellExecutor.Cmd.User.ExecuteCmdCommand(command) + "\n出现 Usage: AXMLPrinter <binary xml file> 则为正常\n如果没有输出则代表转换核心丢失";
            return output;
        }

        private static async Task<string> ViewAsync(string inputFile)
        {
            string command = ".\\jre\\bin\\java.exe -jar AXMLPrinter3.jar \"" + inputFile + "\"";

            // 异步执行命令
            var output = await Task.Run(() =>
            {
                return ShellExecutor.Cmd.User.ExecuteCmdCommand(command);
            });

            return output;
        }
    }
}
