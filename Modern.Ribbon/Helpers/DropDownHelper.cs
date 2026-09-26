namespace Modern.Helpers;

using System;
using System.Windows;
using System.Windows.Interop;
using System.Runtime.InteropServices;

/// <summary>
/// Helper class for drop downs.
/// </summary>
public static class DropDownHelper {
    [DllImport("user32.dll")]
    private static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

    [DllImport("user32.dll")]
    private static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);
    private const uint MONITOR_DEFAULTTONEAREST = 0x00000002;

    [StructLayout(LayoutKind.Sequential)]
    private struct MONITORINFO {
        public int cbSize;
        public Rect rcMonitor;
        public Rect rcWork;
        public int dwFlags;
    }

    /// <summary>
    /// Coerces the maximum drop down height.
    /// </summary>
    public static object? CoerceMaxDropDownHeight(DependencyObject d, object? baseValue) {
        return baseValue is not double value
            ? baseValue
            : GetMaxDropDownHeight(d, value);
    }

    /// <summary>
    /// Gets the maximum drop down height.
    /// </summary>
    public static double GetMaxDropDownHeight(DependencyObject d, double baseValue) {
        if (double.IsNaN(baseValue) is false) {
            return baseValue;
        }

        var window = Window.GetWindow(d);
        if (window == null) {
            return double.NaN;
        }

        var hwnd = new WindowInteropHelper(window).Handle;
        var hMonitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
        if (hMonitor == IntPtr.Zero)
            return double.NaN;

        MONITORINFO mi = new MONITORINFO();
        mi.cbSize = Marshal.SizeOf(mi);
        if (!GetMonitorInfo(hMonitor, ref mi))
            return double.NaN;

        // rcWork 就是屏幕工作区（排除任务栏）
        double workingAreaHeight = mi.rcWork.Bottom - mi.rcWork.Top;
        return Math.Floor(workingAreaHeight / 3D);
    }
}