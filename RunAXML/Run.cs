using Tools.Shell;

namespace RunAXML
{
    public class Run
    {
        public static void ExportXml(string inputFile, string outputFile)
        {
            string command = ".\\jre\\bin\\java.exe -jar AXMLPrinter3.jar " + "\"" + inputFile + "\"" + " > " + "\"" + outputFile + "\"";
            ShellExecutor.Cmd.User.ExecuteCmdCommand(command);
        }

        public static string ViewXml(string inputFile)
        {
            string command = ".\\jre\\bin\\java.exe -jar AXMLPrinter3.jar " + "\"" + inputFile + "\"";
            string output = ShellExecutor.Cmd.User.ExecuteCmdCommand(command);
            return output;
        }

        public static string Test()
        {
            string command = ".\\jre\\bin\\java.exe -jar AXMLPrinter3.jar";
            string output = ShellExecutor.Cmd.User.ExecuteCmdCommand(command);
            return output;
        }
    }
}
