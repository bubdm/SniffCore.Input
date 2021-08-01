//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SniffCore.Input
{
    /// <summary>
    ///     Adds a browse button to the <see cref="EnhancedTextBox" />.
    /// </summary>
    /// <example>
    ///     <code lang="XAML">
    /// <![CDATA[
    /// <Window>
    ///     <controls:BrowseTextBox ShowBrowseButton="True"
    ///                             BrowseCommand="{Binding BrowseCommand}" />
    /// </Window>
    /// ]]>
    /// </code>
    /// </example>
    public class BrowseTextBox : EnhancedTextBox
    {
        /// <summary>
        ///     Identifies the <see cref="BrowseButtonContent" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonContentProperty =
            DependencyProperty.Register("BrowseButtonContent", typeof(object), typeof(BrowseTextBox), new UIPropertyMetadata("..."));

        /// <summary>
        ///     Identifies the <see cref="BrowseButtonPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonPositionProperty =
            DependencyProperty.Register("BrowseButtonPosition", typeof(Dock), typeof(BrowseTextBox), new UIPropertyMetadata(Dock.Right));

        /// <summary>
        ///     Identifies the <see cref="BrowseButtonPadding" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonPaddingProperty =
            DependencyProperty.Register("BrowseButtonPadding", typeof(Thickness), typeof(BrowseTextBox), new UIPropertyMetadata(new Thickness(5, 0, 5, 0)));

        /// <summary>
        ///     Identifies the <see cref="BrowseButtonMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseButtonMarginProperty =
            DependencyProperty.Register("BrowseButtonMargin", typeof(Thickness), typeof(BrowseTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="ShowBrowseButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowBrowseButtonProperty =
            DependencyProperty.Register("ShowBrowseButton", typeof(bool), typeof(BrowseTextBox), new UIPropertyMetadata(true));

        /// <summary>
        ///     Identifies the <see cref="BrowseCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseCommandProperty =
            DependencyProperty.Register("BrowseCommand", typeof(ICommand), typeof(BrowseTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="BrowseCommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BrowseCommandParameterProperty =
            DependencyProperty.Register("BrowseCommandParameter", typeof(object), typeof(BrowseTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="VerticalBrowseButtonAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalBrowseButtonAlignmentProperty =
            DependencyProperty.Register("VerticalBrowseButtonAlignment", typeof(VerticalAlignment), typeof(BrowseTextBox), new UIPropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        ///     Identifies the <see cref="HorizontalBrowseButtonAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalBrowseButtonAlignmentProperty =
            DependencyProperty.Register("HorizontalBrowseButtonAlignment", typeof(HorizontalAlignment), typeof(BrowseTextBox), new UIPropertyMetadata(HorizontalAlignment.Center));

        static BrowseTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BrowseTextBox), new FrameworkPropertyMetadata(typeof(BrowseTextBox)));
        }

        /// <summary>
        ///     Gets or sets the text shown in the browse button.
        /// </summary>
        [DefaultValue("...")]
        public object BrowseButtonContent
        {
            get => GetValue(BrowseButtonContentProperty);
            set => SetValue(BrowseButtonContentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the position where the browse button has to be placed inside the text box.
        /// </summary>
        [DefaultValue(Dock.Right)]
        public Dock BrowseButtonPosition
        {
            get => (Dock) GetValue(BrowseButtonPositionProperty);
            set => SetValue(BrowseButtonPositionProperty, value);
        }

        /// <summary>
        ///     Gets or sets the padding of the browse button.
        /// </summary>
        public Thickness BrowseButtonPadding
        {
            get => (Thickness) GetValue(BrowseButtonPaddingProperty);
            set => SetValue(BrowseButtonPaddingProperty, value);
        }

        /// <summary>
        ///     Gets or sets the margin of the browse button.
        /// </summary>
        public Thickness BrowseButtonMargin
        {
            get => (Thickness) GetValue(BrowseButtonMarginProperty);
            set => SetValue(BrowseButtonMarginProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the browse button is shown or not.
        /// </summary>
        [DefaultValue(true)]
        public bool ShowBrowseButton
        {
            get => (bool) GetValue(ShowBrowseButtonProperty);
            set => SetValue(ShowBrowseButtonProperty, value);
        }

        /// <summary>
        ///     Gets or sets the command to be executed by the browse button.
        /// </summary>
        [DefaultValue(null)]
        public ICommand BrowseCommand
        {
            get => (ICommand) GetValue(BrowseCommandProperty);
            set => SetValue(BrowseCommandProperty, value);
        }

        /// <summary>
        ///     Gets or sets the command passed by the <see cref="BrowseCommand" />.
        /// </summary>
        [DefaultValue(null)]
        public object BrowseCommandParameter
        {
            get => GetValue(BrowseCommandParameterProperty);
            set => SetValue(BrowseCommandParameterProperty, value);
        }

        /// <summary>
        ///     Gets or sets the vertical alignment of the vertical alignment of the browse button.
        /// </summary>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment VerticalBrowseButtonAlignment
        {
            get => (VerticalAlignment) GetValue(VerticalBrowseButtonAlignmentProperty);
            set => SetValue(VerticalBrowseButtonAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the horizontal alignment of the browse button.
        /// </summary>
        [DefaultValue(HorizontalAlignment.Center)]
        public HorizontalAlignment HorizontalBrowseButtonAlignment
        {
            get => (HorizontalAlignment) GetValue(HorizontalBrowseButtonAlignmentProperty);
            set => SetValue(HorizontalBrowseButtonAlignmentProperty, value);
        }
    }
}