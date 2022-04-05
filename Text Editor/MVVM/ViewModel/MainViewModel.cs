using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Text_Editor.MVVM.Infrastructure.Commands;
using Text_Editor.MVVM.Model;
using Text_Editor.MVVM.View.Pages;
using Text_Editor.MVVM.View.Windows;

namespace Text_Editor.MVVM.ViewModel
{
    internal class MainViewModel : ViewModels.Base.ViewModel
    {
        #region Fields

        private Page _mainPage;
        private Page _settingsPage;

        #region View fields

        /// <summary>
        /// Window width
        /// </summary>
        private int _windowWidth = 800;
        public int windowWidth
        {
            get { return _windowWidth; }
            set => Set(ref _windowWidth, value);
        }


        /// <summary>
        /// Window height
        /// </summary>
        private int _windowHeight = 450;
        public int windowHeight
        {
            get { return _windowHeight; }
            set => Set(ref _windowHeight, value);
        }


        /// <summary>
        /// Window title
        /// </summary>
        private string _windowTitle = "Test";
        public string windowTitle
        {
            get { return _windowTitle; }
            set => Set(ref _windowTitle, value);
        }


        /// <summary>
        /// Window state
        /// </summary>
        private WindowState _windowState = WindowState.Normal;
        public WindowState windowState
        {
            get { return _windowState; }
            set => Set(ref _windowState, value);
        }


        /// <summary>
        /// Current page
        /// </summary>
        private Page _currentPage;
        public Page currentPage
        {
            get { return _currentPage; }
            set => Set(ref _currentPage, value);
        }


        /// <summary>
        /// Frame opacity
        /// </summary>
        private float _frameOpacity = 1.0f;
        public float frameOpacity
        {
            get { return _frameOpacity; }
            set => Set(ref _frameOpacity, value);
        }

        #region Colors


        /// <summary>
        /// 
        /// </summary>
        private SolidColorBrush _backgoroundColor = ColorsModel.LightTheme.background;
        public SolidColorBrush backgoroundColor
        {
            get { return _backgoroundColor; }
            set => Set(ref _backgoroundColor, value);
        }


        /// <summary>
        /// Foreground color
        /// </summary>
        private SolidColorBrush _foreground = ColorsModel.LightTheme.foreground;
        public SolidColorBrush foreground
        {
            get { return _foreground; }
            set => Set(ref _foreground, value);
        }

        #endregion

        #endregion 

        #endregion

        public MainViewModel()
        {
            _mainPage = new MainPage();
            _settingsPage = new SettingsPage();

            currentPage = _mainPage;

            CloseCommand = new LambdaCommand(OnCloseCommandExecuted, CanCloseCommandExecute);
            MaximzieRestoreCommand = new LambdaCommand(OnMaximzieRestoreCommandExecuted, CanMaximzieRestoreCommandExecute);
            MinimizeCommand = new LambdaCommand(OnMinimizeCommandExecuted, CanMinimizeCommandExecute);
            SettingsCommand = new LambdaCommand(OnSettingsCommandExecuted, CanSettingsCommandExecute);
        }

        #region Commands

        /// <summary>
        /// Button maximize restore click
        /// </summary>
        public ICommand MaximzieRestoreCommand { get; }

        private bool CanMaximzieRestoreCommandExecute(object p) => true;

        private void OnMaximzieRestoreCommandExecuted(object p)
        {
            if (windowState == WindowState.Normal)
                windowState = WindowState.Maximized;
            else if (windowState == WindowState.Maximized)
                windowState = WindowState.Normal;
        }


        /// <summary>
        /// Window close button click
        /// </summary>
        public ICommand CloseCommand { get; }

        private bool CanCloseCommandExecute(object p) => true;

        private void OnCloseCommandExecuted(object p)
        {
            Environment.Exit(0);
        }


        /// <summary>
        /// Window minimize button click
        /// </summary>
        public ICommand MinimizeCommand { get; }

        private bool CanMinimizeCommandExecute(object p) => true;

        private void OnMinimizeCommandExecuted(object p)
        {
            windowState = WindowState.Minimized;
        }


        /// <summary>
        /// Settings command
        /// </summary>
        public ICommand SettingsCommand { get; }

        private bool CanSettingsCommandExecute(object p) => true;

        private void OnSettingsCommandExecuted(object p)
        {
            FrameAnimation(_settingsPage);
        }

        #endregion

        #region Methods

        private async void FrameAnimation(Page page)
        {
            await Task.Run(() =>
            {
                currentPage = page;
                
                for (int i = 0; i < 100; i++)
                {
                    frameOpacity = i / 100.0f;
                    System.Threading.Thread.Sleep(5);
                }
            });
        }

        #endregion
    }
}
