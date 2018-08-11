﻿using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Widget;

namespace RoundLibrary
{
	public class RoundedFrameLayout : FrameLayout
	{
		private float _radius;
		private Path _path = new Path();

		public RoundedFrameLayout(Context context) : base(context) { }

		public RoundedFrameLayout(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			Init(context, attrs);
		}

		public RoundedFrameLayout(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
		{
			Init(context, attrs);
		}

		public RoundedFrameLayout(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
		{
			Init(context, attrs);
		}

		protected RoundedFrameLayout(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

		private void Init(Context context, IAttributeSet attrs)
		{
			CommonHelper.CheckVersion();
			var attributes = context.ObtainStyledAttributes(attrs, Resource.Styleable.RoundedFrameLayout);

			try
			{
				_radius = attributes.GetDimensionPixelSize(Resource.Styleable.RoundedFrameLayout_corners_radius, 0);
			}
			finally
			{
				attributes.Recycle();
				attributes.Dispose();
			}
		}

		protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged(w, h, oldw, oldh);
			_path.AddRoundedRect(w, h, _radius);
		}

		protected override void DispatchDraw(Canvas canvas)
		{
			int save = canvas.Save();
			canvas.ClipPath(_path);
			base.DispatchDraw(canvas);
			canvas.RestoreToCount(save);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_path?.Dispose();
				_path = null;
			}
			base.Dispose(disposing);
		}
	}
}
