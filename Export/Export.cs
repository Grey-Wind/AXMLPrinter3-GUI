namespace Export
{
    public class Export
    {
        public static void ExportXml(string filePath, string inputText)
        {
            // 尝试写入文件
            try
            {
                // 使用 StreamWriter 创建文件并写入内容
                using (StreamWriter writer = new(filePath))
                {
                    writer.WriteLine(inputText);
                }

                Console.WriteLine("文件已成功创建并写入内容。");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误：{ex.Message}");
            }
        }
    }
}
