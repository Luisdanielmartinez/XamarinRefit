using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Xamarin.Refit.Models
{
    public class ImagenViewModel:Product
    {
        //esto hace que podamos suvirlo al servidor
        [Display(Name="Image")]
        public IFormFile ImageFile { get; set; }
    }
}
