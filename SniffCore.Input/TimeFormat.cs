//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace SniffCore.Input
{
    /// <summary>
    ///     Defines if the <see cref="TimeBox" /> contains a seconds box or not.
    /// </summary>
    public enum TimeFormat
    {
        /// <summary>
        ///     The <see cref="TimeBox" /> contains hours, minutes and seconds.
        /// </summary>
        Long,

        /// <summary>
        ///     The <see cref="TimeBox" /> contains hours and minutes.
        /// </summary>
        Short
    }
}