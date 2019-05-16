using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Java.Lang.Reflect;

namespace LionShares.Android.Helpers
{
    public static class AndroidHelper
    {
        static Class ActionMenuItemViewClass = null;
        static Constructor ActionMenuItemViewConstructor = null;
        static Typeface typeface = null;

        public static View CreateCustomToolbarItem(string name, Context context, IAttributeSet attrs)
        {
            // android.support.v7.widget.Toolbar
            // android.support.v7.view.menu.ActionMenuItemView
            View view = null;

            try
            {
                if (ActionMenuItemViewClass == null)
                    ActionMenuItemViewClass = context.ClassLoader.LoadClass(name);
            }
            catch (ClassNotFoundException ex)
            {
                return null;
            }

            if (ActionMenuItemViewClass == null)
                return null;

            if (ActionMenuItemViewConstructor == null)
            {
                try
                {
                    ActionMenuItemViewConstructor = ActionMenuItemViewClass.GetConstructor(new Class[] {
                            Class.FromType(typeof(Context)),
                                 Class.FromType(typeof(IAttributeSet))
                        });
                }
                catch (SecurityException)
                {
                    return null;
                }
                catch (NoSuchMethodException)
                {
                    return null;
                }
            }
            if (ActionMenuItemViewConstructor == null)
                return null;

            try
            {
                Java.Lang.Object[] args = new Java.Lang.Object[] { context, (Java.Lang.Object)attrs };
                view = (View)(ActionMenuItemViewConstructor.NewInstance(args));
            }
            catch (IllegalArgumentException)
            {
                return null;
            }
            catch (InstantiationException)
            {
                return null;
            }
            catch (IllegalAccessException)
            {
                return null;
            }
            catch (InvocationTargetException)
            {
                return null;
            }
            if (null == view)
                return null;

            View v = view;

            new Handler().Post(() =>
            {

                try
                {
                    // set font
                    if (typeface == null)
                        typeface = Typeface.CreateFromAsset(context.ApplicationContext.Assets, "fontawesome-webfont.ttf");

                    if (v is LinearLayout)
                    {
                        var ll = (LinearLayout)v;
                        for (int i = 0; i < ll.ChildCount; i++)
                        {
                            var button = ll.GetChildAt(i) as Button;

                            if (button != null)
                            {
                                var title = button.Text;

                                if (!string.IsNullOrEmpty(title) && title.Length == 1)
                                {
                                    button.SetTypeface(typeface, TypefaceStyle.Normal);
                                }
                            }
                        }
                    }
                    else if (v is TextView)
                    {
                        var tv = (TextView)v;
                        string title = tv.Text;

                        if (!string.IsNullOrEmpty(title) && title.Length == 1)
                        {
                            tv.SetTypeface(typeface, TypefaceStyle.Normal);
                        }
                    }
                }
                catch (ClassCastException)
                {
                }
            });

            return view;
        }
    }
}