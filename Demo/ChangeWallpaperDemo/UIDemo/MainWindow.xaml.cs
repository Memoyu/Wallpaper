using System;
using System.Windows;
using System.Windows.Interop;
using UIDemo.Views;
using UIDemo.ViewModels;

namespace UIDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangedContent(string name)
        {
            var  mainViewModel = DataContext as MainViewModel;
            mainViewModel?.OpenPage(name);
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            IntPtr mainWindowPtr = new WindowInteropHelper(this).Handle;
            HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
            mainWindowSrc?.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                // 捕获系统命令，禁用移动窗体
                case WM_SYSCOMMAND:
                    int command = wParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                    {
                        handled = true;
                    }
                    break;
            }
            return IntPtr.Zero;
        }
    }
}
