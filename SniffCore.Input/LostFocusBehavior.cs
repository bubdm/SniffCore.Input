//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System;
using System.ComponentModel;
using System.Windows.Markup;

namespace SniffCore.Input
{
    /// <summary>
    ///     Defines the actions which should be done when the <see cref="NumberBox" /> lost the focus.
    /// </summary>
    public class LostFocusBehavior : MarkupExtension
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LostFocusBehavior" /> class.
        /// </summary>
        public LostFocusBehavior()
            : this(ValueBehavior.None)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LostFocusBehavior" /> class.
        /// </summary>
        /// <param name="value">The behavior for the input value when null.</param>
        public LostFocusBehavior(ValueBehavior value)
        {
            Value = value;
            TrimLeadingZero = false;
            FormatText = null;
        }

        /// <summary>
        ///     Gets or sets the behavior to be applied to the NumberBox value when it its empty (null).
        /// </summary>
        /// <remarks>Default value is ValueBehavior.None.</remarks>
        [DefaultValue(ValueBehavior.None)]
        public ValueBehavior Value { get; set; }

        /// <summary>
        ///     Gets or sets a value that indicates if leading zero's should be trimmed from the value or not.
        /// </summary>
        /// <remarks>The default value is false.</remarks>
        [DefaultValue(false)]
        public bool TrimLeadingZero { get; set; }

        /// <summary>
        ///     Gets or sets the format text (string.Format) to be applied to the text.
        /// </summary>
        /// <remarks>The default value is null. No format.</remarks>
        [DefaultValue(null)]
        public string FormatText { get; set; }

        /// <summary>
        ///     Returns the object with its configured behaviors.
        /// </summary>
        /// <param name="serviceProvider">Not Used</param>
        /// <returns>The object with its configured behaviors.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}