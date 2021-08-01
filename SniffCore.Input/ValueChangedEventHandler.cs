//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace SniffCore.Input
{
    /// <summary>
    ///     The event handler for the <see cref="NumberBox.NumberChanged" /> event.
    /// </summary>
    /// <param name="sender">The corresponding NumberBox.</param>
    /// <param name="e">The object with the old and new number.</param>
    public delegate void NumberChangedEventHandler(object sender, NumberChangedEventArgs e);
}