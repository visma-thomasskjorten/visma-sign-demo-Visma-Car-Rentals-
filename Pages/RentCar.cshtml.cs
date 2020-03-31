using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace VismaCarRental.net.Pages
{
    public class RentCarModel : PageModel
    {
        private readonly ILogger<RentCarModel> _logger;

        public string CarType {get; set;}

        public RentCarModel(ILogger<RentCarModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string cartype)
        {
            CarType = cartype;
        }
    }
}
