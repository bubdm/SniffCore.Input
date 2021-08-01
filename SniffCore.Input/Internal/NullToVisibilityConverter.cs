//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SniffCore.Input.Internal
{
    [ValueConversion(typeof(object), typeof(Visibility), ParameterType = typeof(NullToVisibilityDirection))]
    internal sealed class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var direction = NullToVisibilityDirection.NullIsCollapsed;
            if (parameter is NullToVisibilityDirection visibilityDirection)
                direction = visibilityDirection;

            return direction switch
            {
                NullToVisibilityDirection.NullIsVisible => value == null ? Visibility.Visible : Visibility.Collapsed,
                NullToVisibilityDirection.NotNullIsHidden => value == null ? Visibility.Visible : Visibility.Hidden,
                NullToVisibilityDirection.NullIsCollapsed => value == null ? Visibility.Collapsed : Visibility.Visible,
                NullToVisibilityDirection.NullIsHidden => value == null ? Visibility.Hidden : Visibility.Visible,
                _ => Visibility.Collapsed
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}