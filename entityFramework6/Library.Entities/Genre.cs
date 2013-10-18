using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
     public enum Genre
    {
        [Display(Name="Non Fiction")]
        NonFiction,
        Romance, 
        Action,
        [Display(Name = "Science Fiction")]
        ScienceFiction
    }
}
