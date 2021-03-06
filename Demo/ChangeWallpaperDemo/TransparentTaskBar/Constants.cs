using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransparentTaskBar
{
    static class Constants
    {
        // Windows Accent Colour Hook
        public const uint WM_DWMCOLORIZATIONCOLORCHANGED = 0x0320;
        public static readonly uint WM_TASKBARCREATED = Externals.RegisterWindowMessage("TaskbarCreated");

        // Window Location Event Hooks
        public const uint EVENT_MIN = 0x1;
        public const uint EVENT_MAX = 0x7FFFFFFF;
        public const uint EVENT_OBJECT_LOCATIONCHANGE = 0x800B;
        public const uint WINEVENT_OUTOFCONTEXT = 0;

        // Monitor
        public const int MONITOR_DEFAULTTONULL = 0;
        public const int MONITOR_DEFAULTTOPRIMARY = 1;
        public const int MONITOR_DEFAULTTONEAREST = 2;
    }
}
