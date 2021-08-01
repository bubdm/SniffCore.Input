//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Windows;

namespace SniffCore.Input
{
    /// <summary>
    ///     Holds the data passed when a <see cref="NumberBox" /> has changed its value.
    /// </summary>
    public sealed class NumberChangedEventArgs : RoutedEventArgs
    {
        internal NumberChangedEventArgs(object oldVal, object newVal)
            : base(NumberBox.NumberChangedEvent)
        {
            OldNumber = oldVal;
            NewNumber = newVal;
        }

        /// <summary>
        ///     Gets the old number.
        /// </summary>
        public object OldNumber { get; }

        /// <summary>
        ///     Gets the new number
        /// </summary>
        public object NewNumber { get; }
    }
}