using System;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Text;
using Android.Util;
using UrbanDictionary.Xamarin.Droid.Controls;
using System.Windows.Input;

namespace UrbanDictionary.Xamarin.Droid
{
    public class HtmlTextBlock : TextView
    {
        private string html;
        private readonly ExtendedLinkMovementMethod extendedLinkMovementMethod;

        public HtmlTextBlock(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            extendedLinkMovementMethod = new ExtendedLinkMovementMethod(new string[] { "define" });
            extendedLinkMovementMethod.LinkClicked += OnLinkClicked;
            MovementMethod = extendedLinkMovementMethod;
        }

        public ICommand LinkClickCommand { get; set; }

        private void OnLinkClicked(object sender, string e)
        {
            if (LinkClickCommand?.CanExecute(e) ?? false)
            {
                LinkClickCommand?.Execute(e);
            }
        }

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