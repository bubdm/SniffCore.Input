//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace SniffCore.Input
{
    /// <summary>
    ///     Represents a up or down button shown in the <see cref="NumberBox" /> control.
    /// </summary>
    public class UpDownButton : RepeatButton
    {
        /// <summary>
        ///     Identifies the <see cref="UpDownButton.Direction" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(UpDownDirections), typeof(UpDownButton), new UIPropertyMetadata(UpDownDirections.Up));

        static UpDownButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UpDownButton), new FrameworkPropertyMetadata(typeof(UpDownButton)));
        }

        /// <summary>
        ///     Gets or sets a value which indicates in which direction the button is pointing to.
        /// </summary>
        [DefaultValue(UpDownDirections.Up)]
        public UpDownDirections Direction
        {
            get => (UpDownDirections) GetValue(DirectionProperty);
            set => SetValue(DirectionProperty, value);
        }
    }
}