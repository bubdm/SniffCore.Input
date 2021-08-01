//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Globalization;

namespace SniffCore.Input.Internal
{
    internal interface INumber
    {
        object CurrentNumber { get; }
        bool CanIncrease { get; }
        bool CanDecrease { get; }
        bool AcceptNegative { get; }
        bool NumberIsBelowMinimum { get; }
        void Initialize(object number, object minimum, object maximum, object step, object defaultNumber, CultureInfo parsingCulture, CultureInfo predefinedCulture);
        void TakeCulture(object culture);
        bool TakeNumber(object newNumber);
        void TakeMinimum(object newMinimum);
        void TakeMaximum(object newMaximum);
        void TakeStep(object newStep);
        void TakeDefaultNumber(object newDefaultValue);
        void Increase();
        void Decrease();
        void Reset();
        void ToMaximum();
        void ToMinimum();
    }
}