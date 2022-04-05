using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Text_Editor.MVVM.View.Pages
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SaveButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var dlg = new SaveFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt";

            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, text.Text);
            }
        }

        private void MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (e.Delta > 0 && text.FontSize < 72)
                {
                    text.FontSize += 1;
                }
                else
                {
                    if (text.FontSize > 1)
                    {
                        text.FontSize -= 1;
                    }
                }
            }
        }
    }
}
