using System;
using Android.Graphics;

namespace RoundLibrary
{
	internal static class CommonHelper
	{
		internal static void AddRoundedRect(this Path path, int width, int height, float radius)
		{
			path.Reset();
			using (var rect = new RectF())
			{
				rect.Set(0, 0, width, height);
				path.AddRoundRect(rect, radius, radius, Path.Direction.Cw);
			}

			path.Close();
		}

		internal static void CheckVersion()
		{
			if (Android.OS.Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Kitkat)
			{
				throw new NotSupportedException("Unsupported Android Version");
			}
		}
	}
}
