using System.Collections.Generic;

namespace OhmCalc.Models
{
    public class ColorBandData
    {
        private List<ColorBandItem> colorBandItems = null;
        public List<ColorBandItem> ColorBandItems
        {
            get { return colorBandItems; }
            private set
            {
                colorBandItems = value;
            }
        }

        public ColorBandData()
        {
            ColorBandItems = new List<ColorBandItem>();
            ColorBandItems.Add(new ColorBandItem("Black", "Black", 0, 1, null));
            ColorBandItems.Add(new ColorBandItem("Brown", "Brown", 1, 10, 0.01f));
            ColorBandItems.Add(new ColorBandItem("Red", "Red", 2, 100, 0.02f));
            ColorBandItems.Add(new ColorBandItem("Orange", "Orange", 3, 1000, 0.02f));
            ColorBandItems.Add(new ColorBandItem("Yellow", "Yellow", 4, 10000, 0.05f));
            ColorBandItems.Add(new ColorBandItem("Green", "Green", 5, 100000, 0.005f));
            ColorBandItems.Add(new ColorBandItem("Blue", "Blue", 6, 1000000, 0.025f));
            ColorBandItems.Add(new ColorBandItem("Violet", "Violet", 7, 10000000, 0.001f));
            ColorBandItems.Add(new ColorBandItem("Gray", "Gray", 8, 100000000, 0.10f));
            ColorBandItems.Add(new ColorBandItem("White", "White", 9, 100000000, null));
            ColorBandItems.Add(new ColorBandItem("Gold", "Gold", null, 0.1f, 0.05f));
            ColorBandItems.Add(new ColorBandItem("Silver", "Silver", null, null, 0.1f));
            ColorBandItems.Add(new ColorBandItem(string.Empty, "[None]", null, null, 0.2f));
        }

    }
}