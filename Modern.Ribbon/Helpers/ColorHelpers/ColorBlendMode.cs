namespace Modern.Helpers.ColorHelpers;

using System;
using Modern.Internal;

#pragma warning disable CA1308, CA1815, CA1051, CA2231, CA1051, CS1591, SA1602

[Obsolete(Constants.InternalUsageWarning)]
public enum ColorBlendMode {
    Burn,
    Darken,
    Dodge,
    Lighten,
    Multiply,
    Overlay,
    Screen
}