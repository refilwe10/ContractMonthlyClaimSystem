using ContractMonthlyClaimSystem.Controllers.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class CoordinatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor to inject the DbContext
        public CoordinatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Define the 'ApproveClaims' action to show pending claims
        public IActionResult ApproveClaims()
        {
            var pendingClaims = _context.Claims
                .Where(c => c.Status == "Pending")  // Fetch claims that are pending approval
                .ToList();

            return View(pendingClaims);  // Pass the list of pending claims to the view
        }

        // 2. Define the 'Approve' action to approve a claim
        public IActionResult Approve(int id)
        {
            var claim = _context.Claims.Find(id);  // Find the claim by its ID
            if (claim != null)
            {
                claim.Status = "Approved";  // Update the claim's status to 'Approved'
                _context.SaveChanges();  // Save changes to the database
            }
            return RedirectToAction("ApproveClaims");  // Redirect to the list of claims
        }

        // 3. Define the 'Reject' action to reject a claim
        public IActionResult Reject(int id)
        {
            var claim = _context.Claims.Find(id);  // Find the claim by its ID
            if (claim != null)
            {
                claim.Status = "Rejected";  // Update the claim's status to 'Rejected'
                _context.SaveChanges();  // Save changes to the database
            }
            return RedirectToAction("ApproveClaims");  // Redirect to the list of claims
        }
    }
}
