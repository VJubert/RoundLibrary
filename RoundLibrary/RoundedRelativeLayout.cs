using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Widget;

namespace RoundLibrary
{
	public class RoundedRelativeLayout : FrameLayout
	{
		private float _radius;
		private Path _path = new Path();

		public RoundedRelativeLayout(Context context) : base(context) { }

		public RoundedRelativeLayout(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			Init(context, attrs);
		}

		public RoundedRelativeLayout(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
		{
			Init(context, attrs);
		}

		public RoundedRelativeLayout(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
		{
			Init(context, attrs);
		}

		protected RoundedRelativeLayout(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }

		private void Init(Context context, IAttributeSet attrs)
		{
			CommonHelper.CheckVersion();
			_radius = context.GetRadiusFromResource(attrs);
		}

		protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
		{
			base.OnSizeChanged(w, h, oldw, oldh);
			_path.Reset();
			using (var rect = new RectF())
			{
				rect.Set(0, 0, w, h);
				_path.AddRoundRect(rect, _radius, _radius, Path.Direction.Cw);
			}

			_path.Close();
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
