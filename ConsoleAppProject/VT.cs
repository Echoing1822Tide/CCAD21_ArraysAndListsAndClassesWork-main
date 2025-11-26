using System;
using System.Runtime.InteropServices;

public static class VT
{
    // Basic colors (SGR)
    private const string Reset = "\u001b[0m";
    private const string Bold  = "\u001b[1m";
    private const string Red   = "\u001b[31m";
    private const string Cyan  = "\u001b[36m";
    private const string Yellow= "\u001b[33m";

    /// Call once on startup (Windows only needs this).
    public static void EnableIfWindows()
    {
        if (!OperatingSystem.IsWindows()) return;

        IntPtr h = GetStdHandle(STD_OUTPUT_HANDLE);
        if (h == IntPtr.Zero || h == INVALID_HANDLE_VALUE) return;

        if (GetConsoleMode(h, out uint mode))
        {
            // ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004
            const uint ENABLE_VTP = 0x0004;
            SetConsoleMode(h, mode | ENABLE_VTP);
        }
    }

    public static void Alert(string message)
        => WriteLineColored($"⚠ {message}", Red, Bold);

    public static void Cheer(string message)
        => WriteLineColored($"✔ {message}", Cyan, Bold);

    public static void Warn(string message)
        => WriteLineColored($"! {message}", Yellow, Bold);

    public static void WriteLineColored(string text, string color, string style = "")
    {
        Console.Write(style);
        Console.Write(color);
        Console.Write(text);
        Console.WriteLine(Reset);
    }

    // --- Win32 interop for VT enablement ---
    private const int STD_OUTPUT_HANDLE = -11;
    private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
}
