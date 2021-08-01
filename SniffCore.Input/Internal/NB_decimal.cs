//
// Copyright (c) David Wendland. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
//

using System.Globalization;

namespace SniffCore.Input.Internal
{
    internal class NB_decimal : Number<decimal?>
    {
        public override bool CanIncrease => _current + _step <= _maximum;

        public override bool CanDecrease => _current - _step >= _minimum;

        public override bool AcceptNegative => _minimum < 0;

        public override bool NumberIsBelowMinimum => _current < _minimum;

        protected override decimal? GetMinValue()
        {
            return decimal.MinValue;
        }

        protected override decimal? GetMaxValue()
        {
            return decimal.MaxValue;
        }

        protected override decimal? GetDefaultStep()
        {
            return 1;
        }

        protected override void StepUp()
        {
            _current += _step;
        }

        protected override void StepDown()
        {
            _current -= _step;
        }

        protected override bool IsInRange(decimal? parsedNumber)
        {
            if (parsedNumber == null)
                return true;
            return parsedNumber <= _maximum;
        }

        protected override bool TryParse(string numberString, out decimal? parsed)
        {
            if (string.IsNullOrWhiteSpace(numberString))
            {
                parsed = null;
                return true;
            }

            var result = decimal.TryParse(numberString, NumberStyles.Float, _parsingCulture, out var tmp);
            parsed = tmp;
            return result;
        }

        public override string ToString()
        {
            if (_current == null)
                return string.Empty;
            return _current.Value.ToString(_parsingCulture);
        }
    }
}