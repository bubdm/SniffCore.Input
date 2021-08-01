//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Windows;
using System.Windows.Controls;

namespace SniffCore.Input
{
    /// <summary>
    ///     Represents the reset to default button shown in the <see cref="NumberBox" />.
    /// </summary>
    public class NumberResetButton : Button
    {
        static NumberResetButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberResetButton), new FrameworkPropertyMetadata(typeof(NumberResetButton)));
        }
    }
}