using Microsoft.Win32;
using MultiFileLog;
using RunAXml.MultiFile;
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

            UserNameTextBox.Text = "用户名？没有！";
            UserKeyTextBox.Text = "密码更没有。我还不屑于拿这个捞钱！";
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
        /// <strong>[已停用]</strong>选择输出文件夹
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

        private async void RunBtn_Click(object sender, RoutedEventArgs e)
        {
            if(UseAsyncCheckBox.IsChecked == true)
            {
                LogBox.Text = Log.Add(LogBox.Text, "使用异步模式运行\n运行中");

                await BasicRun.RunAsync(InputFolderPath.Text, OutputFolderPath.Text); // 原理是把 BasicRun.Run 异步运行，写的烂得一批，基本上一堆await乱套

                LogBox.Text = Log.Add(LogBox.Text, "运行结束");
            }
            else
            {
                LogBox.Text = Log.Add(LogBox.Text, "使用同步模式运行\n运行中...");

                BasicRun.Run(InputFolderPath.Text, OutputFolderPath.Text); // 不能加 await ，因为这是同步运行

                LogBox.Text = Log.Add(LogBox.Text, "运行结束");
            }
        }

        /// <summary>
        /// 检测是否取消选择异步模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UseAsyncCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            LogBox.Text = Log.Add(LogBox.Text, "已取消异步模式");
        }

        /// <summary>
        /// 检测是否选中异步模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UseAsyncCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            LogBox.Text = Log.Add(LogBox.Text, "已选择异步模式");
        }

        /// <summary>
        /// 清空所有内容(不包含用户和密码)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            InputFolderPath.Clear();
            OutputFolderPath.Clear();
            LogBox.Clear();
        }
    }
}
