//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SniffCore.Input
{
    /// <summary>
    ///     Enhances the <see cref="TextBox" /> by the possibilities to show background text, drop files and folders and place
    ///     additional controls in.
    /// </summary>
    /// <example>
    ///     <code lang="XAML">
    /// <![CDATA[
    /// <Window>
    ///     <controls:EnhancedTextBox InfoText="Required" AllowedDropType="Files" Separator=";" />
    /// </Window>
    /// ]]>
    /// </code>
    /// </example>
    [TemplatePart(Name = "PART_InfoText", Type = typeof(TextBlock))]
    public class EnhancedTextBox : TextBox
    {
        /// <summary>
        ///     Identifies the <see cref="InfoAppearance" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoAppearanceProperty =
            DependencyProperty.Register("InfoAppearance", typeof(InfoAppearance), typeof(EnhancedTextBox), new UIPropertyMetadata(InfoAppearance.OnLostFocus, OnInfoAppearanceChanged));

        /// <summary>
        ///     Identifies the <see cref="InfoText" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextProperty =
            DependencyProperty.Register("InfoText", typeof(string), typeof(EnhancedTextBox), new UIPropertyMetadata(""));

        /// <summary>
        ///     Identifies the <see cref="InfoTextFontStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextFontStyleProperty =
            DependencyProperty.Register("InfoTextFontStyle", typeof(FontStyle), typeof(EnhancedTextBox), new UIPropertyMetadata(FontStyles.Italic));

        /// <summary>
        ///     Identifies the <see cref="InfoTextForeground" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextForegroundProperty =
            DependencyProperty.Register("InfoTextForeground", typeof(Brush), typeof(EnhancedTextBox), new UIPropertyMetadata(Brushes.Gray));

        /// <summary>
        ///     Identifies the <see cref="InfoTextHorizontalAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextHorizontalAlignmentProperty =
            DependencyProperty.Register("InfoTextHorizontalAlignment", typeof(HorizontalAlignment), typeof(EnhancedTextBox), new UIPropertyMetadata(HorizontalAlignment.Left));

        /// <summary>
        ///     Identifies the <see cref="InfoTextVerticalAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextVerticalAlignmentProperty =
            DependencyProperty.Register("InfoTextVerticalAlignment", typeof(VerticalAlignment), typeof(EnhancedTextBox), new UIPropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        ///     Identifies the <see cref="InfoTextMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextMarginProperty =
            DependencyProperty.Register("InfoTextMargin", typeof(Thickness), typeof(EnhancedTextBox));

        /// <summary>
        ///     Identifies the <see cref="InfoTextStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextStyleProperty =
            DependencyProperty.Register("InfoTextStyle", typeof(Style), typeof(EnhancedTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="FirstControl" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty FirstControlProperty =
            DependencyProperty.Register("FirstControl", typeof(object), typeof(EnhancedTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="FirstControlPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty FirstControlPositionProperty =
            DependencyProperty.Register("FirstControlPosition", typeof(Dock), typeof(EnhancedTextBox), new UIPropertyMetadata(Dock.Left));

        /// <summary>
        ///     Identifies the <see cref="SecondControl" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SecondControlProperty =
            DependencyProperty.Register("SecondControl", typeof(object), typeof(EnhancedTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="SecondControlPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SecondControlPositionProperty =
            DependencyProperty.Register("SecondControlPosition", typeof(Dock), typeof(EnhancedTextBox), new UIPropertyMetadata(Dock.Right));

        /// <summary>
        ///     Identifies the <see cref="AllowedDropType" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty AllowedDropTypeProperty =
            DependencyProperty.Register("AllowedDropType", typeof(DroppableTypes), typeof(EnhancedTextBox), new UIPropertyMetadata(DroppableTypes.File));

        /// <summary>
        ///     Identifies the <see cref="Separator" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SeparatorProperty =
            DependencyProperty.Register("Separator", typeof(string), typeof(EnhancedTextBox), new UIPropertyMetadata("; "));

        /// <summary>
        ///     Identifies the <see cref="DragDropEffect" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DragDropEffectProperty =
            DependencyProperty.Register("DragDropEffect", typeof(DragDropEffects), typeof(EnhancedTextBox), new UIPropertyMetadata(DragDropEffects.Link));

        private TextBlock _infoText;

        static EnhancedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnhancedTextBox), new FrameworkPropertyMetadata(typeof(EnhancedTextBox)));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EnhancedTextBox" /> class.
        /// </summary>
        public EnhancedTextBox()
        {
            Loaded += InfoTextBox_Loaded;
            PreviewDragOver += DroppableTextBox_PreviewDragOver;
            PreviewDrop += DroppableTextBox_PreviewDrop;
        }

        /// <summary>
        ///     Gets or sets a value which indicates when the info text in the background is shown.
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
        ///     Gets or sets the foreground color of the info text shown in the background
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
        ///     Gets or sets the vertical alignment info text shown in the background.
        /// </summary>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment InfoTextVerticalAlignment
        {
            get => (VerticalAlignment) GetValue(InfoTextVerticalAlignmentProperty);
            set => SetValue(InfoTextVerticalAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the margin for the info text shown in the background.
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
        ///     Gets or sets an additional control placed inside the text box.
        /// </summary>
        [DefaultValue(null)]
        public object FirstControl
        {
            get => GetValue(FirstControlProperty);
            set => SetValue(FirstControlProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates where the additional <see cref="FirstControl" /> has to be placed in the text
        ///     box.
        /// </summary>
        [DefaultValue(Dock.Left)]
        public Dock FirstControlPosition
        {
            get => (Dock) GetValue(FirstControlPositionProperty);
            set => SetValue(FirstControlPositionProperty, value);
        }

        /// <summary>
        ///     Gets or sets an second additional control placed inside the text box.
        /// </summary>
        [DefaultValue(null)]
        public object SecondControl
        {
            get => GetValue(SecondControlProperty);
            set => SetValue(SecondControlProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates where the additional <see cref="SecondControl" /> has to be placed in the text
        ///     box.
        /// </summary>
        [DefaultValue(Dock.Right)]
        public Dock SecondControlPosition
        {
            get => (Dock) GetValue(SecondControlPositionProperty);
            set => SetValue(SecondControlPositionProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates what the text box allows to drop in.
        /// </summary>
        [DefaultValue(DroppableTypes.File)]
        public DroppableTypes AllowedDropType
        {
            get => (DroppableTypes) GetValue(AllowedDropTypeProperty);
            set => SetValue(AllowedDropTypeProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which will be used as a separator if multiple elements can be dropped to the textbox. See
        ///     <see cref="AllowedDropType" />.
        /// </summary>
        [DefaultValue("; ")]
        public string Separator
        {
            get => (string) GetValue(SeparatorProperty);
            set => SetValue(SeparatorProperty, value);
        }

        /// <summary>
        ///     Gets or sets the mouse icon when files or folders (See <see cref="AllowedDropType" />) will be dropped into the
        ///     text box.
        /// </summary>
        [DefaultValue(DragDropEffects.Link)]
        public DragDropEffects DragDropEffect
        {
            get => (DragDropEffects) GetValue(DragDropEffectProperty);
            set => SetValue(DragDropEffectProperty, value);
        }

        private void InfoTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshInfoAppearance();
        }

        /// <summary>
        ///     The template gets added to the control.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            RefreshInfoAppearance();
        }

        /// <summary>
        ///     Takes care about hiding the info text in the background depending on the <see cref="InfoAppearance" /> property.
        /// </summary>
        /// <param name="e">The parameter passed by the caller.</param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);

            if (!GetInfoTextBlock())
                return;

            if (InfoAppearance != InfoAppearance.OnEmpty)
                _infoText.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        ///     Takes care about display the info text in the background depending on the <see cref="InfoAppearance" /> property.
        /// </summary>
        /// <param name="e">The parameter passed by the caller.</param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            if (!GetInfoTextBlock())
                return;

            if (InfoAppearance != InfoAppearance.None && string.IsNullOrEmpty(Text))
                _infoText.Visibility = Visibility.Visible;
        }

        /// <summary>
        ///     Takes care about display or hide the info text in the background depending on the <see cref="InfoAppearance" />
        ///     property.
        /// </summary>
        /// <param name="e">The parameter passed by the caller.</param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            if (!GetInfoTextBlock())
                return;

            if (string.IsNullOrEmpty(Text))
            {
                if (InfoAppearance == InfoAppearance.OnEmpty)
                    _infoText.Visibility = Visibility.Visible;
            }
            else if (_infoText.Visibility == Visibility.Visible)
            {
                _infoText.Visibility = Visibility.Collapsed;
            }
        }

        private void RefreshInfoAppearance()
        {
            if (!GetInfoTextBlock())
                return;

            if (InfoAppearance == InfoAppearance.None || !string.IsNullOrEmpty(Text))
                _infoText.Visibility = Visibility.Collapsed;
        }

        private bool GetInfoTextBlock()
        {
            _infoText ??= GetTemplateChild("PART_InfoText") as TextBlock;
            return _infoText != null;
        }

        private void DroppableTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = !string.IsNullOrEmpty(GetContent(e)) ? DragDropEffect : DragDropEffects.None;
            e.Handled = true;
        }

        private void DroppableTextBox_PreviewDrop(object sender, DragEventArgs e)
        {
            e.Handled = true;
            var contentText = GetContent(e);
            if (string.IsNullOrEmpty(contentText))
                return;
            ((TextBox) sender).Text = contentText;
            Focus();
        }

        private string GetContent(DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop, true))
                return null;

            if (!(e.Data.GetData(DataFormats.FileDrop, true) is string[] content))
                return null;

            switch (AllowedDropType)
            {
                case DroppableTypes.File:
                    if (content.Length == 1 &&
                        File.Exists(content[0]))
                        return content[0];
                    break;
                case DroppableTypes.Files:
                    return content.Any(value => !File.Exists(value)) ? null : string.Join(Separator, content);
                case DroppableTypes.FilesFolders:
                    return content.Any(value => !File.Exists(value) && !Directory.Exists(value)) ? null : string.Join(Separator, content);
                case DroppableTypes.Folder:
                    if (content.Length == 1 && Directory.Exists(content[0]))
                        return content[0];
                    break;
                case DroppableTypes.Folders:
                    return content.Any(value => !Directory.Exists(value)) ? null : string.Join(Separator, content);
            }

            return null;
        }

        private static void OnInfoAppearanceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ((EnhancedTextBox) sender).RefreshInfoAppearance();
        }
    }
}