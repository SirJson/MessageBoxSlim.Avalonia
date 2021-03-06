using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

using System;

namespace MessageBoxSlim.Avalonia
{
    public static class BitmapFactory
    {
        public static Bitmap Load(Uri uri)
        {
            return new Bitmap(AvaloniaLocator
                    .Current
                    .GetService<IAssetLoader>()
                    .Open(uri));
        }

        public static Bitmap Load(string uri)
        {
            return new Bitmap(AvaloniaLocator
                    .Current
                    .GetService<IAssetLoader>()
                    .Open(new Uri(uri)));
        }
    }
}
