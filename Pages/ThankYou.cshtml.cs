using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace VismaCarRental.net.Pages
{
    public class ThankYouModel : PageModel
    {
        private readonly ILogger<ThankYouModel> _logger;

        public string FirstName {get; set;}
        public string Email {get; set;}

        public ThankYouModel(ILogger<ThankYouModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet(string car, string fname, string lname, string email)
        {
            this.FirstName = fname;
            this.Email = email;

            // creates an instance of the Visma Sign Class which will handle the communication with Visma Sign
            var vismaSign = new VismaSign(
                "https://vismasign.frakt.io",
                identifier: "{INSERT YOUR IDENTIDIER HERE}", // uuid
                secret: "{INSERT YOUR SECRET HERE}" // in base64
            );

            // Creates a new document in Visma Sign
            var documentUri = await vismaSign.DocumentCreate(
                "{\"document\":{\"name\":\"Car rental contract - " + fname + "." + lname + "\"}}"
            );
           
            // Get the rental contract PDF
            byte[] fileContent = System.IO.File.ReadAllBytes("wwwroot/cont/VismaCarRentals-Contract.pdf");
            
            // Add the PDF-file to the created document in Visma Sign.
            await vismaSign.DocumentAddFile(documentUri, fileContent);
            
            // Create and send invitations to sign document
            var invitations = await vismaSign.DocumentAddInvitations(
                documentUri,
                "[{\"email\":\"" + email + "\"}]"
            );
        }
    }
}
