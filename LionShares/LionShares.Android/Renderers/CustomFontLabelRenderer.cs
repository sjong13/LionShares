using Android.Graphics;
using LionShares.Android.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(Label), typeof(CustomFontLabelRenderer))]
namespace LionShares.Android.Renderers
{
    public class CustomFontLabelRenderer : LabelRenderer
    {
        private Context _context;
        public CustomFontLabelRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var label = Element as Label;
            var fontFamily = label.FontFamily;

            if (!string.IsNullOrEmpty(fontFamily))
            {
                string fontFileName = string.Empty;
                if (!CheckIfCustomFont(fontFamily, FontAttributes.None, out fontFileName))
                    if (!fontFamily.Contains(".ttf")) fontFileName = fontFamily.ToLower() + ".ttf";

                var typeface = Typeface.CreateFromAsset(_context.Assets, fontFileName);

                Control.Typeface = typeface;
            }
        }

        private static readonly string[] CustomFontFamily = new[] { "FontAwesome", "Ionicons" };
        private static readonly Tuple<FontAttributes, string>[][] CustomFontFamilyData = new[] {
            new [] {
                new Tuple<FontAttributes, string>(FontAttributes.None, "fontawesome-webfont.ttf"),
                new Tuple<FontAttributes, string>(FontAttributes.Bold, "fontawesome-webfont.ttf"),
                new Tuple<FontAttributes, string>(FontAttributes.Italic, "fontawesome-webfont.ttf"),
            },
            new [] {
                new Tuple<FontAttributes, string>(FontAttributes.None, "ionicons.ttf"),
                new Tuple<FontAttributes, string>(FontAttributes.Bold, "ionicons.ttf"),
                new Tuple<FontAttributes, string>(FontAttributes.Italic, "ionicons.ttf"),
            },
        };

        protected bool CheckIfCustomFont(string fontFamily, FontAttributes attributes, out string fontFileName)
        {
            for (int i = 0; i < CustomFontFamily.Length; i++)
            {
                if (string.Equals(fontFamily, CustomFontFamily[i], StringComparison.InvariantCulture))
                {
                    var fontFamilyData = CustomFontFamilyData[i];

                    for (int j = 0; j < fontFamilyData.Length; j++)
                    {
                        var data = fontFamilyData[j];
                        if (data.Item1 == attributes)
                        {
                            fontFileName = data.Item2;

                            return true;
                        }
                    }

                    break;
                }
            }

            fontFileName = null;
            return false;
        }
    }
}