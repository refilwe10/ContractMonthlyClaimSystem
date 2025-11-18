using ContractMonthlyClaimSystem.Controllers.Data;
using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET action to display the claim submission form
        [HttpGet]
        public IActionResult SubmitClaim()
        {
            return View();  // Returns the SubmitClaim view
        }

        // POST action to handle form submission
        [HttpPost]
        public IActionResult SubmitClaim(Claim model, IFormFile supportingDocuments)
        {
            if (ModelState.IsValid)
            {
                // Save the uploaded file if it exists
                if (supportingDocuments != null)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", supportingDocuments.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        supportingDocuments.CopyTo(stream);
                    }
                    model.SupportingDocuments = supportingDocuments.FileName;  // Store the file name
                }

                // Save the claim to the database
                _context.Claims.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");  // Redirect to another page after submitting (optional)
            }

            return View(model);  // If the model is not valid, return the same view with errors
        }
    }
}

