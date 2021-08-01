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
    ///     Adds search and cancel buttons to the EnhancedTextBox to represent a search box shown like in the Windows explorer.
    /// </summary>
    /// <example>
    ///     <code lang="XAML">
    /// <![CDATA[
    /// <Window>
    ///     <controls:SearchTextBox ShowSearchButton="True"
    ///                             SearchCommand="{Binding SearchCommand}"
    ///                             IsSearching="{Binding IsSearching}"
    ///                             CancelCommand="{Binding CancelSearchCommand}" />
    /// </Window>
    /// ]]>
    /// </code>
    /// </example>
    public class SearchTextBox : EnhancedTextBox
    {
        /// <summary>
        ///     Identifies the <see cref="SearchButtonPosition" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchButtonPositionProperty =
            DependencyProperty.Register("SearchButtonPosition", typeof(Dock), typeof(SearchTextBox), new UIPropertyMetadata(Dock.Right));

        /// <summary>
        ///     Identifies the <see cref="SearchButtonMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchButtonMarginProperty =
            DependencyProperty.Register("SearchButtonMargin", typeof(Thickness), typeof(SearchTextBox));

        /// <summary>
        ///     Identifies the <see cref="SearchButtonPadding" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchButtonPaddingProperty =
            DependencyProperty.Register("SearchButtonPadding", typeof(Thickness), typeof(SearchTextBox));

        /// <summary>
        ///     Identifies the <see cref="VerticalSearchButtonAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty VerticalSearchButtonAlignmentProperty =
            DependencyProperty.Register("VerticalSearchButtonAlignment", typeof(VerticalAlignment), typeof(SearchTextBox), new UIPropertyMetadata(VerticalAlignment.Stretch));

        /// <summary>
        ///     Identifies the <see cref="HorizontalSearchButtonAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty HorizontalSearchButtonAlignmentProperty =
            DependencyProperty.Register("HorizontalSearchButtonAlignment", typeof(HorizontalAlignment), typeof(SearchTextBox), new UIPropertyMetadata(HorizontalAlignment.Center));

        /// <summary>
        ///     Identifies the <see cref="ShowSearchButton" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ShowSearchButtonProperty =
            DependencyProperty.Register("ShowSearchButton", typeof(bool), typeof(SearchTextBox), new UIPropertyMetadata(true));

        /// <summary>
        ///     Identifies the <see cref="SearchCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(ICommand), typeof(SearchTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="SearchCommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SearchCommandParameterProperty =
            DependencyProperty.Register("SearchCommandParameter", typeof(object), typeof(SearchTextBox), new UIPropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="CancelCommand" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CancelCommandProperty =
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(SearchTextBox), new PropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="CancelCommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CancelCommandParameterProperty =
            DependencyProperty.Register("CancelCommandParameter", typeof(object), typeof(SearchTextBox), new PropertyMetadata(null));

        /// <summary>
        ///     Identifies the <see cref="IsSearching" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsSearchingProperty =
            DependencyProperty.Register("IsSearching", typeof(bool), typeof(SearchTextBox), new UIPropertyMetadata(false));

        static SearchTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextBox), new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }

        /// <summary>
        ///     Gets or sets a value which indicates where the search button has to be placed.
        /// </summary>
        [DefaultValue(Dock.Right)]
        public Dock SearchButtonPosition
        {
            get => (Dock) GetValue(SearchButtonPositionProperty);
            set => SetValue(SearchButtonPositionProperty, value);
        }

        /// <summary>
        ///     Gets or sets the margin of the search button.
        /// </summary>
        public Thickness SearchButtonMargin
        {
            get => (Thickness) GetValue(SearchButtonMarginProperty);
            set => SetValue(SearchButtonMarginProperty, value);
        }

        /// <summary>
        ///     Gets or sets the padding of the search button.
        /// </summary>
        public Thickness SearchButtonPadding
        {
            get => (Thickness) GetValue(SearchButtonPaddingProperty);
            set => SetValue(SearchButtonPaddingProperty, value);
        }

        /// <summary>
        ///     Gets or sets the vertical alignment of the search button.
        /// </summary>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment VerticalSearchButtonAlignment
        {
            get => (VerticalAlignment) GetValue(VerticalSearchButtonAlignmentProperty);
            set => SetValue(VerticalSearchButtonAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the horizontal alignment of the search button.
        /// </summary>
        [DefaultValue(HorizontalAlignment.Center)]
        public HorizontalAlignment HorizontalSearchButtonAlignment
        {
            get => (HorizontalAlignment) GetValue(HorizontalSearchButtonAlignmentProperty);
            set => SetValue(HorizontalSearchButtonAlignmentProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the search button is visible or not. This has effect on the cancel button
        ///     too.
        /// </summary>
        [DefaultValue(true)]
        public bool ShowSearchButton
        {
            get => (bool) GetValue(ShowSearchButtonProperty);
            set => SetValue(ShowSearchButtonProperty, value);
        }

        /// <summary>
        ///     Gets or sets the command to be called by the search button.
        /// </summary>
        [DefaultValue(null)]
        public ICommand SearchCommand
        {
            get => (ICommand) GetValue(SearchCommandProperty);
            set => SetValue(SearchCommandProperty, value);
        }

        /// <summary>
        ///     Gets or sets the parameter to be passed when the <see cref="SearchCommand" /> gets executed.
        /// </summary>
        [DefaultValue(null)]
        public object SearchCommandParameter
        {
            get => GetValue(SearchCommandParameterProperty);
            set => SetValue(SearchCommandParameterProperty, value);
        }

        /// <summary>
        ///     Gets or sets the command to be called by the cancel button.
        /// </summary>
        [DefaultValue(null)]
        public ICommand CancelCommand
        {
            get => (ICommand) GetValue(CancelCommandProperty);
            set => SetValue(CancelCommandProperty, value);
        }

        /// <summary>
        ///     Gets or sets the parameter to be passed when the <see cref="CancelCommand" /> gets executed.
        /// </summary>
        [DefaultValue(null)]
        public object CancelCommandParameter
        {
            get => GetValue(CancelCommandParameterProperty);
            set => SetValue(CancelCommandParameterProperty, value);
        }

        /// <summary>
        ///     Gets or sets a value which indicates if the search or cancel button is visible. If true the cancel button is shown;
        ///     otherwise the search button.
        /// </summary>
        [DefaultValue(false)]
        public bool IsSearching
        {
            get => (bool) GetValue(IsSearchingProperty);
            set => SetValue(IsSearchingProperty, value);
        }
    }
}