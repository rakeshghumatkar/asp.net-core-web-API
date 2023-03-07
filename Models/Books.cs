using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebAPI.Models
{
    public class Books
    {
        public int Id {get; set;}

        //[Required(ErrorMessage ="Enter the Title of Book ")]
        public string Title{get; set;}

        public string Description {get; set;}
    }
}