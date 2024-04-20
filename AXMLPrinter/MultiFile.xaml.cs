using Microsoft.Win32;
using MultiFileLog;
using System.Windows;

namespace AXMLPrinter
{
    /// <summary>
    /// MultiFile.xaml 的交互逻辑
    /// </summary>
    public partial class MultiFile : Window
    {
        public MultiFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择输入文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputFolderPathBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new();

            bool? result = openFolderDialog.ShowDialog();

            if (result == true)
            {
                string path = openFolderDialog.FolderName;

                if (string.IsNullOrEmpty(InputFolderPath.Text))
                {
                    LogBox.Text = Log.Add(LogBox.Text, "您已添加文件夹路径，路径为：" + path);
                }
                else
                {
                    LogBox.Text = Log.Add(LogBox.Text, "您已更新文件夹路径，路径为：" + path);
                }

                InputFolderPath.Text = path;
            }
            else
            {
                LogBox.Text = Log.Add(LogBox.Text, "选择输入文件夹出错");
            }
        }

        /// <summary>
        /// 选择输出文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputFolderPathBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new();

            bool? result = openFolderDialog.ShowDialog();

            if (result == true)
            {
                string path = openFolderDialog.FolderName;
                OutputFolderPath.Text = path;
            }
            else
            {
                LogBox.Text = Log.Add(LogBox.Text, "选择输出文件夹出错");
            }
        }
    }
}
