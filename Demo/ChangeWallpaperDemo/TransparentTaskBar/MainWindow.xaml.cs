using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static TransparentTaskBar.Constants;

namespace TransparentTaskBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static Color accentColor = Color.FromArgb(255, 0, 0, 0);
        private static bool alphaDragStarted = false;
        private Taskbar taskbar = new Taskbar(Externals.FindWindow("Shell_TrayWnd", null));
        private Taskbar otherTaskbar = new Taskbar(Externals.FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_SecondaryTrayWnd", ""));

        private List<Taskbar> taskbars = new List<Taskbar>();
        public MainWindow()
        {
            taskbars.Add(taskbar);
            taskbars.Add(otherTaskbar);
            InitializeComponent();
            _ = Task.Run(() =>
            {
                while (true)
                {
                    foreach (Taskbar tb in taskbars)
                    {
                        tb.ApplyStyles();
                    }
                    Thread.Sleep(10);
                }
            });
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            IntPtr mainWindowPtr = new WindowInteropHelper(this).Handle;
            HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
            mainWindowSrc.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_TASKBARCREATED)
            {
                // 当任务栏创建时（重启资源管理器时）进入该处理
            }
            else if (msg == WM_DWMCOLORIZATIONCOLORCHANGED)
            {
                // 切换Windows颜色时进入该处理
            }

            return IntPtr.Zero;
        }


        private void WindowsAccentAlphaSlider_DragCompleted(object sender, RoutedEventArgs e)
        {
            alphaDragStarted = false;
            SetWindowsAccentAlpha((byte)WindowsAccentAlphaSlider.Value);
        }

        private void WindowsAccentAlphaSlider_DragStarted(object sender, RoutedEventArgs e)
        {
            alphaDragStarted = true;
        }
        private void WindowsAccentAlphaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!alphaDragStarted)
            {
                SetWindowsAccentAlpha((byte)WindowsAccentAlphaSlider.Value);
            }
        }

        public void SetWindowsAccentAlpha(byte alpha)
        {
            taskbar.AccentPolicy.GradientColor = GetTaskbarColor(alpha);
            otherTaskbar.AccentPolicy.GradientColor = GetTaskbarColor(alpha);
        }

        public static Int32 GetTaskbarColor(byte alpha)
        {
            UpdateColor();
            var acolor = BitConverter.ToInt32(new byte[] { accentColor.R, accentColor.G, accentColor.B, alpha }, 0);
            byte[] bytes = BitConverter.GetBytes(acolor);
            int colorInt = BitConverter.ToInt32(new byte[] { bytes[0], bytes[1], bytes[2], alpha }, 0);
            return colorInt;
        }
        private static void UpdateColor()
        {
            string keyName = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Accent";
            int keyColor = (int)Microsoft.Win32.Registry.GetValue(keyName, "StartColorMenu", 00000000);

            byte[] bytes = BitConverter.GetBytes(keyColor);

            accentColor = Color.FromArgb(bytes[3], bytes[0], bytes[1], bytes[2]);
        }

    }
}
