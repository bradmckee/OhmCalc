using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace OhmCalc.ViewModel
{
    public class ViewItems
    {
        public SelectList BandAItems { get; internal set; }
        public SelectList BandBItems { get; internal set; }
        public SelectList BandCItems { get; internal set; }
        public SelectList BandDItems { get; internal set; }
        [Required(ErrorMessage = "Please select a color")]
        public string BandAColor { get; set; }
        [Required(ErrorMessage = "Please select a color")]
        public string BandBColor { get; set; }
        [Required(ErrorMessage = "Please select a color")]
        public string BandCColor { get; set; }
        [Required(ErrorMessage = "Please select a color")]
        public string BandDColor { get; set; }
        public string OhmResult { get; set; }
    }
}