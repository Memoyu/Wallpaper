using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static TransparentTaskBar.Constants;

namespace TransparentTaskBar
{
    public class Taskbar
    {

        public IntPtr HWND { get; set; }
        public IntPtr Monitor { get; set; }
        public bool HasMaximizedWindow { get; set; }
        public AccentPolicy AccentPolicy;

        public Taskbar(IntPtr hwnd)
        {
            HWND = hwnd;
            Monitor = Externals.MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
            AccentPolicy = new AccentPolicy
            {
                AccentFlags = 2,
                AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND,
                AnimationId = 0
            };
        }

        public void ApplyStyles()
        {
            int sizeOfPolicy = Marshal.SizeOf(this.AccentPolicy);
            IntPtr policyPtr = Marshal.AllocHGlobal(sizeOfPolicy);
            Marshal.StructureToPtr(this.AccentPolicy, policyPtr, false);

            WinCompatTrData data = new WinCompatTrData(WindowCompositionAttribute.WCA_ACCENT_POLICY, policyPtr, sizeOfPolicy);

            Externals.SetWindowCompositionAttribute(this.HWND, ref data);

            Marshal.FreeHGlobal(policyPtr); 
        }
    }
}
