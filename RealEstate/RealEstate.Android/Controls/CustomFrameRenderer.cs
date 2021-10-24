using System.Collections.Generic;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;
using Java.Lang;
using RealEstate.Controls;
using RealEstate.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using FrameRenderer = Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace RealEstate.Droid.Controls
{
    public class CustomFrameRenderer : FrameRenderer
    {
        public CustomFrameRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control != null)
            {
                UpdateCornerRadius();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(CustomFrame.CornerRadius) ||
                e.PropertyName == nameof(CustomFrame))
            {
                UpdateCornerRadius();
            }
        }

        private void UpdateCornerRadius()
        {
            if (Control.Background is GradientDrawable backgroundGradient)
            {
                var cornerRadius = (Element as CustomFrame)?.CornerRadius;
                if (!cornerRadius.HasValue)
                {
                    return;
                }

                var topLeftCorner = Context.ToPixels(cornerRadius.Value.TopLeft);
                var topRightCorner = Context.ToPixels(cornerRadius.Value.TopRight);
                var bottomLeftCorner = Context.ToPixels(cornerRadius.Value.BottomLeft);
                var bottomRightCorner = Context.ToPixels(cornerRadius.Value.BottomRight);

                var cornerRadii = new[]
                {
                    topLeftCorner,
                    topLeftCorner,

                    topRightCorner,
                    topRightCorner,

                    bottomRightCorner,
                    bottomRightCorner,

                    bottomLeftCorner,
                    bottomLeftCorner,
                };

                backgroundGradient.SetCornerRadii(cornerRadii);

                //var a = GetAllChildrenBFS(Control);
                //a[1].ClipToOutline = true;
            }
        }

        protected override void OnDraw(Canvas canvas)
        {
            if (Element != null)
            {
                var element = Element as CustomFrame;

                var mClipPath = new Path();
                mClipPath.Reset();

                var topLeft = new Android.Graphics.Point(0, 0);
                var topRight = new Android.Graphics.Point(MeasuredWidth, 0);
                var bottomLeft = new Android.Graphics.Point(0, MeasuredHeight);
                var bottomRight = new Android.Graphics.Point(MeasuredWidth, MeasuredHeight);

                var topLeftRadius = (float)element.CornerRadius.TopLeft;
                var topRightRadius = (float)element.CornerRadius.TopRight;
                var bottomLeftRadius = (float)element.CornerRadius.BottomLeft;
                var bottomRightRadius = (float)element.CornerRadius.BottomRight;

                mClipPath.MoveTo(topLeft.X + topLeftRadius, topLeft.Y);

                mClipPath.LineTo(topRight.X - topRightRadius, topRight.Y);
                mClipPath.ArcTo(topRight.X - topRightRadius, topRight.Y, topRight.X, topRight.Y + topLeftRadius, 90f, 0f, true);

                mClipPath.LineTo(bottomRight.X, bottomRight.Y - bottomRightRadius);
                mClipPath.ArcTo(bottomRight.X - bottomRightRadius, bottomRight.Y - bottomRightRadius, bottomRight.X, bottomRight.Y, 0f, -90f, true);

                mClipPath.LineTo(bottomLeft.X - bottomLeftRadius, bottomLeft.Y);
                mClipPath.ArcTo(bottomLeft.X, bottomLeft.Y - bottomLeftRadius, bottomLeft.X + bottomLeftRadius, bottomLeft.Y, 180f, 270f, true);

                mClipPath.LineTo(topLeft.X, topLeft.Y + topLeftRadius);
                mClipPath.ArcTo(topLeft.X, topLeft.Y, topLeft.X + topLeftRadius, topLeft.Y + topLeftRadius, 180f, 90f, true);

                canvas.ClipPath(mClipPath);
                base.DispatchDraw(canvas);
            }
        }

        private List<Android.Views.View> GetAllChildrenBFS(Android.Views.View v)
        {
            List<Android.Views.View> visited = new List<Android.Views.View>();
            List<Android.Views.View> unvisited = new List<Android.Views.View>();
            unvisited.Add(v);

            while (unvisited.Count > 0)
            {
                Android.Views.View child = unvisited[0];
                unvisited.RemoveAt(0);
                visited.Add(child);
                if (!(child is ViewGroup)) continue;
                ViewGroup group = (ViewGroup)child;
                int childCount = group.ChildCount;
                for (int i = 0; i < childCount; i++) unvisited.Add(group.GetChildAt(i));
            }

            return visited;
        }
    }
}
