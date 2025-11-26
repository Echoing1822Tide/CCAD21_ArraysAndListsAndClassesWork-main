using System;
using System.Text;
using System.Threading;

namespace Gadgets
{
    public static class BattleUI
    {
        // Big banner box
        public static void Banner(string title, int width = 60)
        {
            if (string.IsNullOrWhiteSpace(title)) title = "";
            string line = new string('*', width);
            Console.WriteLine(line);
            Console.WriteLine($"* {title.PadRight(width - 4)} *");
            Console.WriteLine(line);
        }

        // Typewriter single line
        public static void TypeLine(string text, int delayMs = 15)
        {
            foreach (char ch in text)
            {
                Console.Write(ch);
                Thread.Sleep(delayMs);
            }
            Console.WriteLine();
        }

        // Spinner with a message for a short duration
        public static void Spinner(string message, int durationMs = 900)
        {
            string[] frames = { "O", "o", "-", "\\" };
            Console.Write(message + " ");
            var start = Environment.TickCount;
            int i = 0;

            // hide cursor if the platform allows it
            bool restored = false;
            try { Console.CursorVisible = false; } catch { /* non-Windows may throw */ }

            while (Environment.TickCount - start < durationMs)
            {
                Console.Write(frames[i++ % frames.Length]);
                Thread.Sleep(80);
                Console.Write('\b');
            }

            try { Console.CursorVisible = true; restored = true; } catch { }
            Console.WriteLine(restored ? "" : ""); // move to next line either way
        }

        // Dots pause: "Cooling emitter..."
        public static void PauseDots(string message, int dotCount = 3, int stepMs = 250)
        {
            Console.Write(message + " ");
            for (int i = 0; i < dotCount; i++)
            {
                Console.Write(".");
                Thread.Sleep(stepMs);
            }
            Console.WriteLine();
        }

        // Cute ASCII “beam” between two labels
        public static void Beam(string from, string to, int len = 18, int speedMs = 20)
        {
            Console.WriteLine($"{from}  ─────────────────►  {to}");
            // animate beam growing
            var sb = new StringBuilder();
            sb.Append(from).Append("  ");
            for (int i = 0; i < len; i++)
            {
                sb.Append('─');
                Console.Write("\r" + sb.ToString() + "►  " + to + "  ");
                Thread.Sleep(speedMs);
            }
            Console.WriteLine();
        }

        // Print outcome of an attack
        public static void Outcome(bool hit)
        {
            if (hit)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("HIT! Alien scout disabled.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Miss — target evaded. Reacquiring…");
            }
            Console.ResetColor();
        }
        // ---- Fun add-ons: paste inside BattleUI class ----
        private static readonly Random _funRng = new();

        public static void Divider(string label = "")
        {
            var line = new string('―', 56);
            if (string.IsNullOrWhiteSpace(label)) { Console.WriteLine(line); return; }
            var pad = Math.Max(0, 54 - label.Length);
            Console.WriteLine($"{line}\n[{label}]{new string(' ', pad)}\n{line}");
        }

        public static void Scoreboard(int humans, int aliens)
        {
            var oldFg = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" HUMANS ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{new string('█', Math.Clamp(humans, 0, 10)).PadRight(10, ' ')}]");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("   ALIENS ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{new string('█', Math.Clamp(aliens, 0, 10)).PadRight(10, ' ')}]");
            Console.ForegroundColor = oldFg;
        }

        public static void Comms(string speaker, string message)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            TypeLine($"[{speaker}] {message}");
            Console.ForegroundColor = old;
        }

        public static void Cheer()
        {
            string[] lines =
            {
        "Direct hit—that’ll leave a mark!",
        "Copy that, target smoked.",
        "Clean execution. Next bogey?",
        "Beautiful maneuver. The brass will frame that one."
    };
            TypeLine(lines[_funRng.Next(lines.Length)]);
        }

        public static void Taunt()
        {
            string[] lines =
            {
        "Alien broadwave: *YOU ARE OUTMATCHED, EARTHLINGS.*",
        "Alien drone: *STATISTICAL VICTORY: 99.7% OURS.*",
        "Alien captain: *RETURN YOUR WORLD. FINAL WARNING.*"
    };
            TypeLine(lines[_funRng.Next(lines.Length)]);
        }

    }
}
