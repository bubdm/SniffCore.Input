//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace SniffCore.Input
{
    /// <summary>
    ///     Defines when the <see cref="EnhancedTextBox.InfoText" /> in the <see cref="EnhancedTextBox" /> and its derived
    ///     controls is visible.
    /// </summary>
    public enum InfoAppearance
    {
        /// <summary>
        ///     No info text has to be shown.
        /// </summary>
        None,

        /// <summary>
        ///     The info text is shown when the box is empty, no matter if it has the keyboard focus or not.
        /// </summary>
        OnEmpty,

        /// <summary>
        ///     The info text is shown when the box is empty and does not have the keyboard focus.
        /// </summary>
        OnLostFocus
    }
}