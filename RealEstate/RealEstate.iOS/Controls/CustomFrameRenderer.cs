using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using RealEstate.Controls;
using RealEstate.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace RealEstate.iOS.Controls
{
    public class CustomFrameRenderer : FrameRenderer
    {
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            UpdateCornerRadius();
        }

        private void UpdateCornerRadius()
        {
            if (Element != null)
            {
                var element = Element as CustomFrame;

                var bezierPath = new UIBezierPath();

                var path = new CGPath();

                var topLeft = new CGPoint(Bounds.Left, Bounds.Top);
                var topRight = new CGPoint(Bounds.Right, Bounds.Top);
                var bottomLeft = new CGPoint(Bounds.Left, Bounds.Bottom);
                var bottomRight = new CGPoint(Bounds.Right, Bounds.Bottom);

                var topLeftRadius = (nfloat)element.CornerRadius.TopLeft;
                var topRightRadius = (nfloat)element.CornerRadius.TopRight;
                var bottomLeftRadius = (nfloat)element.CornerRadius.BottomLeft;
                var bottomRightRadius = (nfloat)element.CornerRadius.BottomRight;

                path.MoveToPoint(topLeft.X + topLeftRadius, topLeft.Y);

                path.AddLineToPoint(new CGPoint(topRight.X - topRightRadius, topRight.Y));
                path.AddCurveToPoint(new CGPoint(topRight.X, topRight.Y),
                                    new CGPoint(topRight.X, topRight.Y + topRightRadius),
                                    new CGPoint(topRight.X, topRight.Y + topRightRadius));

                path.AddLineToPoint(new CGPoint(bottomRight.X, bottomRight.Y - bottomRightRadius));
                path.AddCurveToPoint(new CGPoint(bottomRight.X, bottomRight.Y),
                                    new CGPoint(bottomRight.X - bottomRightRadius, bottomRight.Y),
                                    new CGPoint(bottomRight.X - bottomRightRadius, bottomRight.Y));

                path.AddLineToPoint(new CGPoint(bottomLeft.X + bottomLeftRadius, bottomLeft.Y));
                path.AddCurveToPoint(new CGPoint(bottomLeft.X, bottomLeft.Y),
                                    new CGPoint(bottomLeft.X, bottomLeft.Y - bottomLeftRadius),
                                    new CGPoint(bottomLeft.X, bottomLeft.Y - bottomLeftRadius));

                path.AddLineToPoint(new CGPoint(topLeft.X, topLeft.Y + topLeftRadius));
                path.AddCurveToPoint(new CGPoint(topLeft.X, topLeft.Y),
                                    new CGPoint(topLeft.X + topLeftRadius, topLeft.Y),
                                    new CGPoint(topLeft.X + topLeftRadius, topLeft.Y));

                path.CloseSubpath();

                bezierPath.CGPath = path;

                var mask = new CAShapeLayer
                {
                    Path = bezierPath.CGPath
                };
                Layer.Mask = mask;
            };
        }
    }
}
