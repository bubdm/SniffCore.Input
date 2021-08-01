//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Windows;
using System.Windows.Controls;

namespace SniffCore.Input
{
    /// <summary>
    ///     The button which calls the search command in the <see cref="SearchTextBox" />.
    /// </summary>
    public class SearchButton : Button
    {
        static SearchButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchButton), new FrameworkPropertyMetadata(typeof(SearchButton)));
        }
    }
}