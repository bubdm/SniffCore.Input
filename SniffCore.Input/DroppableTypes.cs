//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

namespace SniffCore.Input
{
    /// <summary>
    ///     Represents what is possible to drop into the <see cref="EnhancedTextBox" />.
    /// </summary>
    public enum DroppableTypes
    {
        /// <summary>
        ///     Just one file can be dropped into the <see cref="EnhancedTextBox" />.
        /// </summary>
        File,

        /// <summary>
        ///     Multiple files can be dropped into the <see cref="EnhancedTextBox" />.
        /// </summary>
        Files,

        /// <summary>
        ///     Multiple files and folders can be dropped into the <see cref="EnhancedTextBox" />.
        /// </summary>
        FilesFolders,

        /// <summary>
        ///     Multiple folders can be dropped into the <see cref="EnhancedTextBox" />.
        /// </summary>
        Folders,

        /// <summary>
        ///     Just one folder can be dropped into the <see cref="EnhancedTextBox" />.
        /// </summary>
        Folder
    }
}