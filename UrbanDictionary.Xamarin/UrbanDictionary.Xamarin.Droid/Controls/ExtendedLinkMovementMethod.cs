using System;
using System.Linq;
using Android.Views;
using Android.Widget;
using Android.Text.Method;
using Android.Text.Style;
using Android.Text;

namespace UrbanDictionary.Xamarin.Droid.Controls
{
    public class ExtendedLinkMovementMethod : LinkMovementMethod
    {
        public event EventHandler<string> LinkClicked;

        public string[] UrlParts { get; }

        public ExtendedLinkMovementMethod(string[] urlParts)
        {
            UrlParts = urlParts;
        }

        public override bool OnTouchEvent(TextView widget, ISpannable buffer, MotionEvent e)
        {
            var action = e.Action;

            if (action == MotionEventActions.Up)
            {
                // Locate the area that was pressed
                var x = e.GetX();
                var y = e.GetY();

                x -= widget.TotalPaddingLeft;
                y -= widget.TotalPaddingTop;
                x += widget.ScrollX;
                y += widget.ScrollY;

                // Locate the URL text
                Layout layout = widget.Layout;
                int line = layout.GetLineForVertical((int)y);
                int off = layout.GetOffsetForHorizontal(line, x);

                // Find the URL that was pressed
                var link = buffer.GetSpans(off, off, Java.Lang.Class.FromType(typeof(URLSpan))).OfType<URLSpan>().ToList();

                if (link.Count > 0 && UrlParts.Any(part => link[0].URL.Contains(part)))
                {
                    LinkClicked?.Invoke(this, link[0].URL);
                    return true;
                }
                else
                {
                    base.OnTouchEvent(widget, buffer, e);
                }
            }

            return base.OnTouchEvent(widget, buffer, e);
        }
    }
}