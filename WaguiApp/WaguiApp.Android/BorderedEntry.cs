using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics.Drawables;
using WaguiApp;
using WaguiApp.Droid;

[assembly: ExportRenderer(typeof(BorderedEntryApp), typeof(BorderedEntry))]

namespace WaguiApp.Droid
{
   public class BorderedEntry : EntryRenderer
    {
        public BorderedEntry(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetStroke(3, Android.Graphics.Color.ParseColor("#009999"));
                gradientDrawable.SetColor(Android.Graphics.Color.White);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(25, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
            }
        }
    }
}