//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace SniffCore.Input
{
    /// <summary>
    ///     Defines what should happen to the  <see cref="NumberBox" /> if the internal checkbox is checked.
    /// </summary>
    public enum NumberBoxCheckBoxBehavior
    {
        /// <summary>
        ///     Nothing happens internally.
        /// </summary>
        None,

        /// <summary>
        ///     The <see cref="NumberBox" /> input field is disabled if the box is checked.
        /// </summary>
        DisableIfChecked,

        /// <summary>
        ///     The <see cref="NumberBox" /> input field is enabled if the box is checked.
        /// </summary>
        EnableIfChecked
    }
}