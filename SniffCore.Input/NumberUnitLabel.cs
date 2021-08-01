//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Windows;
using System.Windows.Controls;

namespace SniffCore.Input
{
    /// <summary>
    ///     Represents the currency symbol shown in the <see cref="NumberBox" />.
    /// </summary>
    public class NumberUnitLabel : Label
    {
        static NumberUnitLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberUnitLabel), new FrameworkPropertyMetadata(typeof(NumberUnitLabel)));
        }
    }
}