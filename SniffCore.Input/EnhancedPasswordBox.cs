//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SniffCore.Input
{
    /// <summary>
    ///     Hosts and enhances the <see cref="PasswordBox" /> to be able to bind the password value and show info text in the
    ///     background.
    /// </summary>
    /// <example>
    ///     <code lang="XAML">
    /// <![CDATA[
    /// <Window>
    ///     <controls:EnhancedPasswordBox Password="{Binding Password}" InfoText="Required" InfoAppearance="OnEmpty" />
    /// </Window>
    /// ]]>
    /// </code>
    /// </example>
    [TemplatePart(Name = "PART_InfoText", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_PasswordBox", Type = typeof(PasswordBox))]
    public class EnhancedPasswordBox : Control
    {
        /// <summary>
        ///     Identifies the <see cref="InfoAppearance" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoAppearanceProperty =
            DependencyProperty.Register("InfoAppearance", typeof(InfoAppearance), typeof(EnhancedPasswordBox), new UIPropertyMetadata(InfoAppearance.OnLostFocus, OnInfoAppearanceChanged));

        /// <summary>
        ///     Identifies the <see cref="InfoText" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextProperty =
            DependencyProperty.Register("InfoText", typeof(string), typeof(EnhancedPasswordBox), new UIPropertyMetadata(""));

        /// <summary>
        ///     Identifies the <see cref="InfoTextFontStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextFontStyleProperty =
            DependencyProperty.Register("InfoTextFontStyle", typeof(FontStyle), typeof(EnhancedPasswordBox), new UIPropertyMetadata(FontStyles.Italic));

        /// <summary>
        ///     Identifies the <see cref="InfoTextForeground" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextForegroundProperty =
            DependencyProperty.Register("InfoTextForeground", typeof(Brush), typeof(EnhancedPasswordBox), new UIPropertyMetadata(Brushes.Gray));

        /// <summary>
        ///     Identifies the <see cref="InfoTextHorizontalAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextHorizontalAlignmentProperty =
            DependencyProperty.Register("InfoTextHorizontalAlignment", typeof(HorizontalAlignment), typeof(EnhancedPasswordBox), new UIPropertyMetadata(HorizontalAlignment.Left));

        /// <summary>
        ///     Identifies the <see cref="InfoTextVerticalAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextVerticalAlignmentProperty =
            DependencyProperty.Register("InfoTextVerticalAlignment", typeof(VerticalAlignment), typeof(EnhancedPasswordBox), new UIPropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        ///     Identifies the <see cref="InfoTextMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextMarginProperty =
            DependencyProperty.Register("InfoTextMargin", typeof(Thickness), typeof(EnhancedPasswordBox));

        /// <summary>
        ///     Identifies the <see cref="InfoTextStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextStyleProperty =
            DependencyProperty.Register("InfoTextStyle", typeof(Style), typeof(EnhancedPasswordBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="Password" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(EnhancedPasswordBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordChanged));

        private TextBlock _infoText;
        private PasswordBox _innerPasswordBox;

        private bool _selfChange;

        static EnhancedPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnhancedPasswordBox), new FrameworkPropertyMetadata(typeof(EnhancedPasswordBox)));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EnhancedPasswordBox" /> class.
        /// </summary>
        public EnhancedPasswordBox()
        {
            Loaded += InfoTextBox_Loaded;
        }

        /// <summary>
        ///     Gets or sets a value which indicated when the info text in the background is shown.
        /// </summary>
        [DefaultValue(InfoAppearance.OnLostFocus)]
        public InfoAppearance InfoAppearance
        {
            get => (InfoAppearance) GetValue(InfoAppearanceProperty);
            set => SetValue(InfoAppearanceProperty, value);
        }

        /// <summary>
        ///     Gets or sets the info text shown in the background.
        /// </summary>
        [DefaultValue("")]
        public string InfoText
        {
            get => (string) GetValue(InfoTextProperty);
            set => SetValue(InfoTextProperty, value);
        }

        /// <summary>
        ///     Gets or sets the font style of the info text shown in the background.
        /// </summary>
        public FontStyle InfoTextFontStyle
        {
            get => (FontStyle) GetValue(InfoTextFontStyleProperty);
            set => SetValue(InfoTextFontStyleProperty, value);
        }

        /// <summary>
        ///     Gets or sets the foreground color of the info text shown in the background.
        /// </summary>
        public Brush InfoTextForeground
        {
            get => (Brush) GetValue(InfoTextForegroundProperty);
            set => SetValue(InfoTextForegroundProperty, value);
        }

        /// <summary>
        ///     Gets or sets the horizontal alignment of the info text shown in the background.
        /// </summary>
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment InfoTextHorizontalAlignment
        {
            get => (HorizontalAlignment) GetValue(InfoTextHorizontalAlignmentProperty);
            set => SetValue(InfoTextHorizontalAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the vertical alignment of the info text shown in the background
        /// </summary>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment InfoTextVerticalAlignment
        {
            get => (VerticalAlignment) GetValue(InfoTextVerticalAlignmentProperty);
            set => SetValue(InfoTextVerticalAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the margin of the info text shown in the background.
        /// </summary>
        public Thickness InfoTextMargin
        {
            get => (Thickness) GetValue(InfoTextMarginProperty);
            set => SetValue(InfoTextMarginProperty, value);
        }

        /// <summary>
        ///     Gets or sets the style of the info text shown in the background.
        /// </summary>
        [DefaultValue(null)]
        public Style InfoTextStyle
        {
            get => (Style) GetValue(InfoTextStyleProperty);
            set => SetValue(InfoTextStyleProperty, value);
        }

        /// <summary>
        ///     Gets or sets the password typed in the text box.
        /// </summary>
        [DefaultValue("")]
        public string Password
        {
            get => (string) GetValue(PasswordProperty);
            set => SetValue(PasswordProperty, value);
        }

        private void InfoTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshInfoAppearance();
            if (!string.IsNullOrEmpty(Password))
                TakePasswordOver(this, Password);
        }

        /// <summary>
        ///     The template gets added to the control.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _innerPasswordBox = GetTemplateChild("PART_PasswordBox") as PasswordBox;
            if (_innerPasswordBox != null)
            {
                _innerPasswordBox.PasswordChanged += PasswordBox_PasswordChanged;

                _innerPasswordBox.GotFocus += InnerPasswordBox_GotFocus;
                _innerPasswordBox.LostFocus += InnerPasswordBox_LostFocus;
                _innerPasswordBox.PasswordChanged += InnerPasswordBox_PasswordChanged;
            }

            RefreshInfoAppearance();
        }

        private void InnerPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (GetInfoTextBlock())
                if (InfoAppearance != InfoAppearance.OnEmpty)
                    _infoText.Visibility = Visibility.Collapsed;
        }

        private void InnerPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (GetInfoTextBlock())
                if (InfoAppearance != InfoAppearance.None &&
                    string.IsNullOrEmpty(Password))
                    _infoText.Visibility = Visibility.Visible;
        }

        private void InnerPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (GetInfoTextBlock())
            {
                var passwordBox = (PasswordBox) sender;
                if (string.IsNullOrEmpty(passwordBox.Password))
                {
                    if (InfoAppearance == InfoAppearance.OnEmpty)
                        _infoText.Visibility = Visibility.Visible;
                }
                else if (_infoText.Visibility == Visibility.Visible)
                {
                    _infoText.Visibility = Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        ///     Moves the focus into the inner password box if the control got the focus.
        /// </summary>
        /// <param name="e">The parameter passed by the caller.</param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            if (_innerPasswordBox != null)
                _innerPasswordBox.Focus();
            base.OnGotFocus(e);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var box = (PasswordBox) sender;
            _selfChange = true;
            Password = box.Password;
            _selfChange = false;
        }

        private static void OnPasswordChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            TakePasswordOver(o as EnhancedPasswordBox, e.NewValue);
        }

        private static void TakePasswordOver(EnhancedPasswordBox control, object password)
        {
            if (!control._selfChange &&
                password != null &&
                control._innerPasswordBox != null)
            {
                control._innerPasswordBox.PasswordChanged -= control.PasswordBox_PasswordChanged;
                control._innerPasswordBox.Password = password.ToString();
                control._innerPasswordBox.PasswordChanged += control.PasswordBox_PasswordChanged;
            }
        }

        private void RefreshInfoAppearance()
        {
            if (GetInfoTextBlock())
            {
                if (InfoAppearance == InfoAppearance.None)
                    _infoText.Visibility = Visibility.Collapsed;
                if (!string.IsNullOrEmpty(Password))
                    _infoText.Visibility = Visibility.Collapsed;
            }
        }

        private bool GetInfoTextBlock()
        {
            if (_infoText == null)
                _infoText = GetTemplateChild("PART_InfoText") as TextBlock;
            return _infoText != null;
        }

        private static void OnInfoAppearanceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((EnhancedPasswordBox) sender).RefreshInfoAppearance();
        }
    }
}