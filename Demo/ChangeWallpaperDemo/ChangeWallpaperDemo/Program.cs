using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ChangeWallpaperDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("定时更换壁纸程序启动，请录入壁纸图片所在文件夹：");
            var path = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                Console.WriteLine("文件夹不存在！请重新输入：");
                path = Console.ReadLine();
            }
            var imagePaths = new List<string>();
            DirectoryInfo folder = new DirectoryInfo(path);
            foreach (FileInfo file in folder.GetFiles().Where(p => p.FullName.EndsWith(".png") || p.FullName.EndsWith(".jpg")))
            {
                imagePaths.Add(file.FullName);
            }

            if (!imagePaths.Any())
            {
                Console.WriteLine("文件夹中不存在");
            }

            WallpaperHelper wallpaper = new WallpaperHelper();
            var index = 0;
            while (true)
            {
                await Task.Delay(5000);
                wallpaper.SetDestPicture(@$"{imagePaths[index]}");
                index++;
                if (index > imagePaths.Count)
                {
                    index = 0;
                }
            }
        }

    }

    /// <summary>
    /// 更换壁纸
    /// </summary>
    public class WallpaperHelper
    {

        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(
            int uAction,
            int uParam,
            string lpvParam,
            int fuWinIni
        );

        /// <summary>
        /// 设置背景图片
        /// </summary>
        /// <param name="picture">图片路径</param>
        public void SetDestPicture(string picture)
        {
            if (File.Exists(picture))
            {
                Bitmap myBmp = new Bitmap(picture);
                string fileName = Path.Combine(Directory.GetCurrentDirectory(), "wall.bmp");
                myBmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                SystemParametersInfo(20, 0, picture, 0x2);
            }
        }


    }

}
