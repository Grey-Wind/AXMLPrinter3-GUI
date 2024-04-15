using Microsoft.Win32;
using System.IO;
using System.Windows;
using Run = RunAXML.Run;

namespace AXMLPrinter
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectInputFileBtn_Click(object sender, RoutedEventArgs e)
        {
            (string filePath, _) = SelectFile();
            string path = filePath;
            InputFilePath.Text = path;

            string outputFileName = InputFilePath.Text + ".output.xml";
            OutputFilePath.Text = outputFileName;
        }

        private void SelectOutputFileBtn_Click(object sender, RoutedEventArgs e)
        {
            (_, string fileName) = SelectFile();
            string name = fileName;
            InputFilePath.Text = name;
        }

        private void ViewXmlBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputFilePath.Text))
            {
                string ot = Run.Test();
                OutputTextBox.Text = ot;
            }
            else
            {
                string output = Run.ViewXml(InputFilePath.Text);
                OutputTextBox.Text = output;
            }
        }

        private void ExportXmlBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputFilePath.Text))
            {
                MessageBox.Show("未输入需转换文件");
            }
            if (string.IsNullOrEmpty(OutputFilePath.Text))
            {
                MessageBox.Show("未输入输出文件");
            }
            else
            {
                string output = Run.ViewXml(InputFilePath.Text);
                OutputTextBox.Text = output;
                Run.ExportXml(InputFilePath.Text, OutputFilePath.Text);
            }
        }

        private void TJRBtn_Click(object sender, RoutedEventArgs e)
        {
            string ot = Run.Test();
            OutputTextBox.Text = ot;
        }

        private void CleanOutputBtn_Click(object sender, RoutedEventArgs e)
        {
            OutputTextBox.Clear();
            InputFilePath.Clear();
            OutputFilePath.Clear();
        }

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
                Console.WriteLine(filePath);
                Console.WriteLine(fileName);
                return (filePath, fileName); // 返回文件路径和文件名的元组
            }
            else
            {
                return ("获取文件路径失败","");
            }
        }
    }
}
