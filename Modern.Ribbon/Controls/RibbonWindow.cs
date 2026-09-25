namespace Modern;

using System.Windows;
using System.Windows.Media;
using ControlzEx;
using Modern.Internal.KnownBoxes;

/// <summary>
/// Ribbon 窗口
/// </summary>
[TemplatePart(Name = PART_Icon, Type = typeof(UIElement))]
[TemplatePart(Name = PART_ContentPresenter, Type = typeof(UIElement))]
[TemplatePart(Name = PART_RibbonTitleBar, Type = typeof(RibbonTitleBar))]
[TemplatePart(Name = PART_WindowCommands, Type = typeof(WindowCommands))]
public class RibbonWindow : WindowChromeWindow {
    private const string PART_Icon = "PART_Icon";
    private const string PART_ContentPresenter = "PART_ContentPresenter";
    private const string PART_RibbonTitleBar = "PART_RibbonTitleBar";
    private const string PART_WindowCommands = "PART_WindowCommands";


    #region 属性
    #region TitelBar
    public RibbonTitleBar? TitleBar {
        get => (RibbonTitleBar?)this.GetValue(TitleBarProperty);
        private set => this.SetValue(TitleBarPropertyKey, value);
    }
    private static readonly DependencyPropertyKey TitleBarPropertyKey = DependencyProperty.RegisterReadOnly(nameof(TitleBar), typeof(RibbonTitleBar), typeof(RibbonWindow), new PropertyMetadata());
    public static readonly DependencyProperty TitleBarProperty = TitleBarPropertyKey.DependencyProperty;
    #endregion
    #region TitleBarHeight
    public double TitleBarHeight {
        get => (double)this.GetValue(TitleBarHeightProperty);
        set => this.SetValue(TitleBarHeightProperty, value);
    }
    public static readonly DependencyProperty TitleBarHeightProperty = DependencyProperty.Register(nameof(TitleBarHeight), typeof(double), typeof(RibbonWindow), new PropertyMetadata(DoubleBoxes.Zero));
    #endregion
    #region TitleBackground
    public Brush? TitleForeground {
        get => (Brush?)this.GetValue(TitleForegroundProperty);
        set => this.SetValue(TitleForegroundProperty, value);
    }

    /// <summary>Identifies the <see cref="TitleForeground"/> dependency property.</summary>
    public static readonly DependencyProperty TitleForegroundProperty = DependencyProperty.Register(nameof(TitleForeground), typeof(Brush), typeof(RibbonWindow), new PropertyMetadata());

    /// <summary>
    /// Gets or sets the <see cref="Brush"/> which is used to render the window title background.
    /// </summary>
    public Brush? TitleBackground {
        get => (Brush?)this.GetValue(TitleBackgroundProperty);
        set => this.SetValue(TitleBackgroundProperty, value);
    }

    /// <summary>Identifies the <see cref="TitleBackground"/> dependency property.</summary>
    public static readonly DependencyProperty TitleBackgroundProperty = DependencyProperty.Register(nameof(TitleBackground), typeof(Brush), typeof(RibbonWindow), new PropertyMetadata());

    /// <summary>Identifies the <see cref="WindowCommands"/> dependency property.</summary>
    public static readonly DependencyProperty WindowCommandsProperty = DependencyProperty.Register(nameof(WindowCommands), typeof(WindowCommands), typeof(RibbonWindow), new PropertyMetadata());

    /// <summary>
    /// Gets or sets the window commands
    /// </summary>
    public WindowCommands? WindowCommands {
        get => (WindowCommands?)this.GetValue(WindowCommandsProperty);
        set => this.SetValue(WindowCommandsProperty, value);
    }
    #endregion
    #region Window-Border-Properties
    public Brush? NonActiveBorderBrush {
        get => (Brush?)this.GetValue(NonActiveBorderBrushProperty);
        set => this.SetValue(NonActiveBorderBrushProperty, value);
    }
    public static readonly DependencyProperty NonActiveBorderBrushProperty = DependencyProperty.Register(nameof(NonActiveBorderBrush), typeof(Brush), typeof(RibbonWindow), new PropertyMetadata(default(Brush)));
    #endregion
    #endregion


    public override void OnApplyTemplate() {
        base.OnApplyTemplate();

        this.TitleBar = this.GetTemplateChild(PART_RibbonTitleBar) as RibbonTitleBar;

        if (this.WindowCommands is null) {
            this.WindowCommands = new WindowCommands();
        }
    }

    static RibbonWindow() {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(RibbonWindow), new FrameworkPropertyMetadata(typeof(RibbonWindow)));
    }
}
