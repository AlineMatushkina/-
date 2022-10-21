using PluginInterface;
using System.Drawing;

namespace BlurFilter
{
    [Version(2, 1)]
    public class Blur : IPlugin
    {
        public string Name
        {
            get
            {
                return "Размытие изображения";
            }
        }

        public string Author
        {
            get
            {
                return "Алина";
            }
        }

        public void Transform(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            Bitmap result = new Bitmap(width, height);
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    float newR = 0.0f;
                    float newG = 0.0f;
                    float newB = 0.0f;
                    int pixelCount = 0;
                    for (int k = -2; k <= 2; k++)
                        for(int m = -2; m <= 2; m++)
                            if (i+k>=0 && j+m>=0 && i + k < width && j + m <height)
                            {
                                Color color = bitmap.GetPixel(i + k, j + m);
                                pixelCount++;
                                newR += color.R;
                                newG += color.G;
                                newB += color.B;
                            }
                    newR /= pixelCount;
                    newG /= pixelCount;
                    newB /= pixelCount;
                    Color newColor = Color.FromArgb((byte)newR, (byte)newG, (byte)newB);
                    result.SetPixel(i, j, newColor);
                }
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    bitmap.SetPixel(i, j, result.GetPixel(i, j));
  
        }
    }
}
