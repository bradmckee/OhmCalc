using System;

namespace OhmCalc.Models
{
    public class Calculator : Interfaces.IOhmValueCalculator
    {

        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            const float DEFAULT_TOLERANCE = 0.2f;
            var invalidInputs = false;
            // Business logic:
            //   BandAColor must be specified
            //   BandBColor must be specified
            //   BandCColor must be specified
            //   BandDColor not required

            var result = -1;  // If result is negative, could not be computed

            // Get value list for colors
            var bdc = new ColorBandData();
            ColorBandItem sigData = null, secondData = null, multData = null, toleranceData = null;
            float multiplier = 0, firstDigit = 0, secondDigit = 0, tolerance = 0;
            if (string.IsNullOrEmpty(bandAColor) || string.IsNullOrEmpty(bandBColor) || string.IsNullOrEmpty(bandCColor)) {
                return result;
            }

            sigData = bdc.ColorBandItems.Find(c => c.ColorName.Equals(bandAColor, StringComparison.InvariantCultureIgnoreCase));
            if (sigData != null && sigData.SignificantFigures.HasValue) { firstDigit = sigData.SignificantFigures.Value; } else
            {
                invalidInputs = true;
            }

            secondData = bdc.ColorBandItems.Find(c => c.ColorName.Equals(bandBColor, StringComparison.InvariantCultureIgnoreCase));
            if (secondData != null && secondData.SignificantFigures.HasValue) { secondDigit = secondData.SignificantFigures.Value; } else
            {
                invalidInputs = true;
            }

            multData = bdc.ColorBandItems.Find(c => c.ColorName.Equals(bandCColor, StringComparison.InvariantCultureIgnoreCase));
            if (multData != null && multData.Multiplier.HasValue) { multiplier = multData.Multiplier.Value; } else
            {
                invalidInputs = true;
            }

            if (!string.IsNullOrEmpty(bandDColor))
            {
                toleranceData = bdc.ColorBandItems.Find(c => c.ColorName.Equals(bandDColor, StringComparison.InvariantCultureIgnoreCase));
                if (toleranceData != null && toleranceData.Tolerance.HasValue) tolerance = toleranceData.Tolerance.Value;
                else tolerance = DEFAULT_TOLERANCE;
            }
            if (!invalidInputs) 
            result = (!invalidInputs) ? Convert.ToInt32(((firstDigit * 10) + secondDigit) * multiplier) : -1;
            return result;
        }
    }
}