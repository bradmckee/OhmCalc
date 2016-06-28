using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalc.Models
{
    public class AjaxResponse
    {
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
        public bool Success { get; set; }

        /// <summary>
        /// Default constructor - sets Success initially to false with a null data object
        /// </summary>
        public AjaxResponse() : this(false, null, "Error not specified")
        {

        }

        /// <summary>
        /// Constructor specifying success and data
        /// </summary>
        /// <param name="success">Boolean indicator of success status (true = successful, false = failure)</param>
        /// <param name="data"></param>
        public AjaxResponse(bool success, object data, string errorMessage)
        {
            Success = success;
            ErrorMessage = ErrorMessage;
            Data = data;
        }
    }
}
