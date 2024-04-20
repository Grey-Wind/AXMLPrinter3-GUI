using AXmlColorBugFix;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using Run = RunAXML.Run;

namespace AXMLPrinter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// 写的很烂
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择输入文件的按钮<br></br>
        /// 会获取到文件的路径<br></br>
        /// 然后修改输出路径<br></br>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectInputFileBtn_Click(object sender, RoutedEventArgs e)
        {
            // 选择输入文件，返回文件路径和文件名
            (string filePath, _) = SelectFile();
            // 文件路径
            string path = filePath;
            // 设置输入文件路径文本框的值
            InputFilePath.Text = path;

            // 设置输出文件名
            // string outputFileName = InputFilePath.Text + ".output.xml";
            // 设置输出文件路径文本框的值
            OutputFilePath.Text = GetNewName(InputFilePath.Text);
        }

        /// <summary>
        /// 选择输出文件的按钮<br></br>
        /// 会获取到文件的路径<br></br>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectOutputFileBtn_Click(object sender, RoutedEventArgs e)
        {
            // 选择输出文件，并将文件名赋值给fileName
            (_, string fileName) = SelectFile();
            // 将文件名赋值给name
            string name = fileName;
            // 将文件名显示在输入文件路径框中
            InputFilePath.Text = name;
        }

        /// <summary>
        /// 根据输入文件路径的内容来执行AXML<br></br>
        /// 把输出显示到输出文本框中<br></br>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ViewXmlBtn_Click(object sender, RoutedEventArgs e)
        {
            // 如果输入文件路径框为空
            if (string.IsNullOrEmpty(InputFilePath.Text))
            {
                // 调用Run类中的Test方法，并将结果显示在输出文本框中
                OutputTextBox.Text = Run.Test();
            }
            else
            {
                // 调用Run类中的ViewXml方法，并将结果显示在输出文本框中
                OutputTextBox.Text = Fix.FixColorBug(await Run.ViewXml(InputFilePath.Text));
            }
        }

        /// <summary>
        /// 根据输入文件路径与输出文件路径来转换AXml文件<br></br>
        /// 先显示再转换<br></br>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ExportXmlBtn_Click(object sender, RoutedEventArgs e)
        {
            // 检查输入文件路径是否为空
            if (string.IsNullOrEmpty(InputFilePath.Text))
            {
                MessageBox.Show("未输入需转换文件");
            }
            // 检查输出文件路径是否为空
            if (string.IsNullOrEmpty(OutputFilePath.Text))
            {
                MessageBox.Show("未输入输出文件");
            }
            else
            {
                // 调用Run类中的ViewXml方法，并将结果显示在输出文本框中
                OutputTextBox.Text = Fix.FixColorBug(await Run.ViewXml(InputFilePath.Text));
                // 调用Run类的ExportXml方法，将输入文件转换为XML文件
                await Export.Export.ExportXml(OutputFilePath.Text, OutputTextBox.Text);
            }
        }

        /// <summary>
        /// 普通启动AXML Printer 3<br></br>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TJRBtn_Click(object sender, RoutedEventArgs e)
        {
            // 调用Run类的Test方法，测试运行状态
            string ot = Run.Test();
            // 将测试结果显示在输出文本框中
            OutputTextBox.Text = ot;
        }

        /// <summary>
        /// 清空所有内容<br></br>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleanOutputBtn_Click(object sender, RoutedEventArgs e)
        {
            // 清空输出文本框的内容
            OutputTextBox.Clear();
            // 清空输入文件路径的内容
            InputFilePath.Clear();
            // 清空输出文件路径的内容
            OutputFilePath.Clear();
        }

        /// <summary>
        /// 选择文件的函数<br></br>
        /// 只能输入.xml文件<br></br>
        /// </summary>
        /// <returns>完整文件路径，文件名称</returns>
        private static (string, string) SelectFile()
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "未反编译的Xml文件 (*.xml)|*.xml" // 选择器，筛选
            };

            bool? result = openFileDialog.ShowDialog(); // 显示文件选择对话框

            if (result == true)
            {
                string filePath = openFileDialog.FileName; // 获取选定的文件路径
                string fileName = Path.GetFileName(filePath); // 从完整路径中提取文件名
                return (filePath, fileName); // 返回文件路径和文件名的元组
            }
            else
            {
                return ("获取文件路径失败",""); // 返回错误信息
            }
        }

        /// <summary>
        /// 获取待转换文件文件名称并返回输出文件完整路径
        /// </summary>
        /// <param name="InputFileName">待转换文件路径</param>
        /// <returns>输出文件完整路径</returns>
        private static string GetNewName(string InputFileName)
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

        /// <summary>
        /// 打开多文件转换窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultiFileBtn_Click(object sender, RoutedEventArgs e)
        {
            MultiFile multiFile = new();

            Close();

            multiFile?.Show();
        }
    }
}
