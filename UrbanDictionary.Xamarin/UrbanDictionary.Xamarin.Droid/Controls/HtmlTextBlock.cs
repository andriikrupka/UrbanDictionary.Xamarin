using System;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Text;
using Android.Util;

namespace UrbanDictionary.Xamarin.Droid
{
    public class HtmlTextBlock : TextView
    {
        private string html;


        public HtmlTextBlock(Context context)
            : base(context)
        { }

        public HtmlTextBlock(Context context, IAttributeSet attrs)
            : base(context, attrs)
        { }

        public HtmlTextBlock(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        { }

        public HtmlTextBlock(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        { }

        protected HtmlTextBlock(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public string Html
        {
            get { return html; }
            set
            {
                html = value;
                UpdateHtml();
            }
        }

        private void UpdateHtml()
        {
            if (!string.IsNullOrEmpty(Html))
            {
                if (Android.OS.Build.VERSION.SdkInt >= BuildVersionCodes.N)
                {
                    TextFormatted = Android.Text.Html.FromHtml(Html, FromHtmlOptions.ModeLegacy);
                }
                else
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    TextFormatted = Android.Text.Html.FromHtml(Html);
#pragma warning restore CS0618 // Type or member is obsolete
                }
            }
            else
            {
                Text = string.Empty;
            }
        }
    }
}