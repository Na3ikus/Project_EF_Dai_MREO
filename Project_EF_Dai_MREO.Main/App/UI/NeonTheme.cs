using System;

namespace DAI_MREO.UI.Design
{
    public class NeonTheme : IColorTheme
    {
        public ConsoleColor PrimaryColor => ConsoleColor.Cyan;

        public ConsoleColor SecondaryColor => ConsoleColor.White;

        public ConsoleColor TextColor => ConsoleColor.White;

        public ConsoleColor ErrorColor => ConsoleColor.Red;

        public ConsoleColor SuccessColor => ConsoleColor.Green;

        public ConsoleColor BackgroundColor => ConsoleColor.Black;

        public string TopLeft => "╔";

        public string TopRight => "╗";

        public string BottomLeft => "╚";

        public string BottomRight => "╝";

        public string Horizontal => "═";

        public string Vertical => "║";

        public string Intersection => "╬";
    }
}