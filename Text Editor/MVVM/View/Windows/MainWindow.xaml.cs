using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Text_Editor.MVVM.Models;

namespace Text_Editor
{
    public partial class MainWindow : Window
    {
        private Point oldPoint;
        private bool isDouble;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.SourceInitialized += new EventHandler(Window_SourceInitialized);
        }

        private void Window_SourceInitialized(object sender, EventArgs e)
        {
            WindowSizing.WindowInitialized(this);
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                maximizeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
                windowChrome.ResizeBorderThickness = new Thickness(5, 5, 5, 5);
                maximizeRestoreButton.ToolTip = "Maximize";
            }
            else if (WindowState == WindowState.Maximized)
            {
                maximizeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowRestore;
                windowChrome.ResizeBorderThickness = new Thickness(5, 0, 5, 5);
                maximizeRestoreButton.ToolTip = "Restore";
            }
        }

        private void TitleMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                isDouble = true;
                if (WindowState == WindowState.Normal)
                    WindowState = WindowState.Maximized;
                else if (WindowState == WindowState.Maximized)
                    WindowState = WindowState.Normal;
            }
            else
            {
                isDouble = false;
                DragMove();
            }
            oldPoint = e.GetPosition(this);
        }
        private void TitleMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var newPoint = e.GetPosition(this);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (WindowState == WindowState.Maximized && !isDouble)
                {
                    if (newPoint.Y > oldPoint.Y)
                    {
                        if (WindowState == WindowState.Normal)
                            WindowState = WindowState.Maximized;
                        else if (WindowState == WindowState.Maximized)
                            WindowState = WindowState.Normal;
                        Left = newPoint.X / 2;
                        Top = newPoint.Y - 20;
                        DragMove();
                    }
                }
            }
        }
    }
}
