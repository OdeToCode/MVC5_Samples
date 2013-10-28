using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelBinding.Models
{
    public class Manager
    {
        public string Name { get; set; }
        public ManagerType Level { get; set; }
    }

    public enum ManagerType
    {
        Middle,
        Senior,
        [Display(Name="Executive Level")]
        ExecutiveLevel
    }
}