using System;
using System.Collections.Generic;
namespace Modern;

using System.Windows;
using System.Windows.Controls;

public class RibbonTitleBar : HeaderedItemsControl {
    static RibbonTitleBar() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(RibbonTitleBar), new FrameworkPropertyMetadata(typeof(RibbonTitleBar)));
    }
}