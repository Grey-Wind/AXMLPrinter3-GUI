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
                    LogBox.Text = Log.Add(LogBox.Text, "您已添加输入文件夹路径，路径为：" + path);
                }
                else
                {
                    LogBox.Text = Log.Add(LogBox.Text, "您已更新输入文件夹路径，路径为：" + path);
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

                if (string.IsNullOrEmpty(OutputFolderPath.Text))
                {
                    LogBox.Text = Log.Add(LogBox.Text, "您已添加输出文件夹路径，路径为：" + path);
                }
                else
                {
                    LogBox.Text = Log.Add(LogBox.Text, "您已更新输出文件夹路径，路径为：" + path);
                }

                OutputFolderPath.Text = path;
            }
            else
            {
                LogBox.Text = Log.Add(LogBox.Text, "选择输出文件夹出错");
            }
        }

        private void RunBtn_Click(object sender, RoutedEventArgs e)
        {
            if(UseAsyncCheckBox.IsChecked == true)
            {
                LogBox.Text = Log.Add(LogBox.Text, "使用异步模式(Beta)运行");
            }
            else
            {
                LogBox.Text = Log.Add(LogBox.Text, "使用同步模式运行");
            }
        }

        private void UseAsyncCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            LogBox.Text = Log.Add(LogBox.Text, "已取消异步模式(Beta)");
        }

        private void UseAsyncCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            LogBox.Text = Log.Add(LogBox.Text, "已选择异步模式(Beta)");
        }
    }
}
