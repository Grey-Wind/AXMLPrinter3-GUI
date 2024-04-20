namespace Export
{
    public class Export
    {
        public static async Task ExportXml(string filePath, string inputText)
        {
            try
            {
                // 使用异步文件写入操作
                using (StreamWriter writer = new(filePath))
                {
                    await writer.WriteLineAsync(inputText);
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
