namespace OhmCalc.Models
{
    public class ColorBandItem
    {
        public string ColorName { get; set; }
        public string DisplayName { get; set; }
        public int? SignificantFigures { get; set; }
        public float? Multiplier { get; set; }
        public float? Tolerance { get; set; }

        public ColorBandItem(string colorName, string displayName, int? significantFigures, float? multiplier, float? tolerance)
        {
            ColorName = colorName;
            DisplayName = displayName;
            SignificantFigures = significantFigures;
            Multiplier = multiplier;
            Tolerance = tolerance;
        }
    }
}