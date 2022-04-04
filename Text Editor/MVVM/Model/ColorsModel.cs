using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Text_Editor.MVVM.Model
{
    internal class ColorsModel
    {
        public static class LightTheme
        {
            public static readonly SolidColorBrush background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            public static readonly SolidColorBrush foreground = new SolidColorBrush(Color.FromRgb(85, 85, 85));
            public static readonly SolidColorBrush buttonStatic = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            public static readonly SolidColorBrush buttonHover = new SolidColorBrush(Color.FromRgb(226, 226, 226));
            public static readonly SolidColorBrush buttonPressed = new SolidColorBrush(Color.FromRgb(109, 109, 109));
        }
        public static class DarkTheme 
        {
            public static readonly SolidColorBrush background = new SolidColorBrush(Color.FromRgb(32, 34, 37));
            public static readonly SolidColorBrush foreground = new SolidColorBrush(Color.FromRgb(252, 252, 253));
        }
    }
}
