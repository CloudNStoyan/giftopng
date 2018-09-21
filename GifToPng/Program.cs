using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GifToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];
            string fileName = filePath.Split('\\')[filePath.Split('\\').Length - 1].Replace(".gif","");

            string directPath = "./" + fileName;
            Directory.CreateDirectory(directPath);

            Console.WriteLine("Getting all frames from " + fileName);
            var gifImg = Image.FromFile(filePath);
            var dimension = new FrameDimension(gifImg.FrameDimensionsList[0]);
            
            int frameCount = gifImg.GetFrameCount(dimension);
            Console.WriteLine("[" + frameCount + "] Frames");

            for (int i = 0; i < frameCount; i++)
            {
                gifImg.SelectActiveFrame(dimension, i);
                var image = (Image)gifImg.Clone();
                image.Save(directPath + "/frame" + i + ".jpeg");
                Console.WriteLine("[" + i + "] Frame exported.");
            }

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }
}
