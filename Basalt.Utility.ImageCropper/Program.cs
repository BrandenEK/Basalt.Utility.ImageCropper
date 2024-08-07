using System.Drawing;

namespace Basalt.Utility.ImageCropper;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
            throw new Exception("Must pass at least one image path as an argument");

        foreach (string path in args)
        {
            Crop(path);
        }
    }

    static void Crop(string path)
    {
        using Bitmap original = new(path);

        if (original.Width != 4080 || original.Height != 3840)
            throw new Exception("Original image must be 4080x3840");

        using Bitmap cropped = new(1920, 1080);
        using Graphics g = Graphics.FromImage(cropped);
        g.DrawImage(original, 0, -2533);

        original.Dispose();
        cropped.Save(path);
    }
}
