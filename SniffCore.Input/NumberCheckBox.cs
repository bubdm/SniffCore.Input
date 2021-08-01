//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Windows;
using System.Windows.Controls;

namespace SniffCore.Input
{
    /// <summary>
    ///     Represents the check box shown in the <see cref="NumberBox" />.
    /// </summary>
    public class NumberCheckBox : CheckBox
    {
        static NumberCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NumberCheckBox), new FrameworkPropertyMetadata(typeof(NumberCheckBox)));
        }
    }
}