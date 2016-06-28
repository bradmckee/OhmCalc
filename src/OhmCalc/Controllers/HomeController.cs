using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OhmCalc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var bdc = new Models.ColorBandData();
            var result = new ViewResult();
            List<SelectListItem> list = new List<SelectListItem>();
            List<SelectListItem> listNoNone = new List<SelectListItem>();
            foreach (var itm in bdc.ColorBandItems)
            {
                if (!string.IsNullOrEmpty(itm.ColorName)) listNoNone.Add(new SelectListItem() { Text = itm.DisplayName, Value = itm.ColorName });
                list.Add(new SelectListItem() { Text = itm.DisplayName, Value = itm.ColorName });
            }
            var colorBandItems = new ViewModel.ViewItems()
            {
                BandAItems = new SelectList(listNoNone, "Value", "Text"),
                BandBItems = new SelectList(listNoNone, "Value", "Text"),
                BandCItems = new SelectList(listNoNone, "Value", "Text"),
                BandDItems = new SelectList(list, "Value", "Text"),
            };
            ViewData.Model = colorBandItems;
            return View();
        }

        public IActionResult Calculate(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            var response = new Models.AjaxResponse();
            var ohmResultStr = string.Empty;
            if (ModelState.IsValid && bandAColor != null && bandBColor != null && bandCColor != null)
            {
                var calc = new Models.Calculator();
                var ohmResult = calc.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor);
                if (ohmResult != -1)
                {
                    ohmResultStr = ohmResult.ToString() + " ohms";
                }
                response.Success = true;
                response.Data = ohmResultStr;
                response.ErrorMessage = null;
            }
            else
            {
                response.Success = false;
                response.Data = null;
                response.ErrorMessage = (!ModelState.IsValid) ? "Invalid model state" : "Please provide required input colors";
            }
            return Json(response);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
