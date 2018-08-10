using System;
using Android.Content;
using Android.Util;
using Android.Locations;
namespace RoundLibrary
{
	internal static class CommonHelper
	{
		internal static float GetRadiusFromResource(this Context context, IAttributeSet attrs)
		{
			var attributes = context.ObtainStyledAttributes(attrs, Resource.Styleable.RoundedLayout);

			try
			{
				return attributes.GetDimensionPixelSize(Resource.Styleable.RoundedLayout_rounded_radius, 0);
			}
			finally
			{
				attributes.Recycle();
				attributes.Dispose();
			}
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
