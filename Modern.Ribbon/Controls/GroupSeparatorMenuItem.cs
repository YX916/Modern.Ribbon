// ReSharper disable once CheckNamespace
namespace Modern;

using System.Windows;
using System.Windows.Markup;
using Modern.Internal.KnownBoxes;

/// <summary>
/// Represents group separator menu item
/// </summary>
[ContentProperty(nameof(Header))]
public class GroupSeparatorMenuItem : MenuItem {
    static GroupSeparatorMenuItem() {
        var type = typeof(GroupSeparatorMenuItem);
        DefaultStyleKeyProperty.OverrideMetadata(type, new FrameworkPropertyMetadata(type));
        IsEnabledProperty.OverrideMetadata(type, new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, null, CoerceIsEnabledAndTabStop));
        IsTabStopProperty.OverrideMetadata(type, new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, null, CoerceIsEnabledAndTabStop));
    }

    private static object CoerceIsEnabledAndTabStop(DependencyObject d, object? basevalue) {
        return BooleanBoxes.FalseBox;
    }
}