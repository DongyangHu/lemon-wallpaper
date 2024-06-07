using System;
using System.IO;

namespace lemon_wallpaper_fix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------- 柠檬壁纸修复程序 -------------");
            Console.WriteLine("该程序会清理所有应用数据，包括壁纸配置信息");
            Console.WriteLine("--------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("请选择操作: 1:清理数据; 其他键:退出");

            Console.ResetColor();
            string input = Console.ReadLine();
            if ("1".Equals(input))
            {
                ClearAppData();
                Console.WriteLine("修复成功!请重启柠檬壁纸程序!\n");
            }
        }


        static void ClearAppData()
        {
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = Path.Combine(appDataFolderPath, "lemon_wallpaper");

            try
            {
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    Console.WriteLine("清理应用缓存数据成功！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("清理应用缓存失败: " + ex.Message);
            }
        }
    }
}
