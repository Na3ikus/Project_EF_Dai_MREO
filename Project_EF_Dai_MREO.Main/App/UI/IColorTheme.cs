using System;

namespace DAI_MREO.UI.Design
{
    public interface IColorTheme
    {
        ConsoleColor PrimaryColor { get; }

        ConsoleColor SecondaryColor { get; }

        ConsoleColor TextColor { get; }

        ConsoleColor ErrorColor { get; }

        ConsoleColor SuccessColor { get; }

        ConsoleColor BackgroundColor { get; }

        string TopLeft { get; }

        string TopRight { get; }

        string BottomLeft { get; }

        string BottomRight { get; }

        string Horizontal { get; }

        string Vertical { get; }

        string Intersection { get; }
    }
}