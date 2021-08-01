//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace SniffCore.Input
{
    /// <summary>
    ///     Defines how the automatic selection of the number in the <see cref="NumberBox" /> should behave.
    /// </summary>
    public enum NumberBoxSelection
    {
        /// <summary>
        ///     No automatic selection will be done.
        /// </summary>
        None,

        /// <summary>
        ///     The number gets selected when the NumberBox got the focus.
        /// </summary>
        OnFocus,

        /// <summary>
        ///     The number will be selected when increment or decrement the value using arrow keys or up/down buttons.
        /// </summary>
        OnUpDown,

        /// <summary>
        ///     The number will be selected when the NumberBox got the focus or the value gets incremented or decremented using the
        ///     arrow keys or up/down buttons.
        /// </summary>
        OnFocusAndUpDown
    }
}