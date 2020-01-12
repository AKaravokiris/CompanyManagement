using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class ErrorModel
    {
        public string ErrorMessage { get; set; }
        public ErrorModel()
        {
            this.ErrorMessage = string.Empty;
        }
    }
}