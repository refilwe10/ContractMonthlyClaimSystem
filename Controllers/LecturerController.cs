using ContractMonthlyClaimSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var claims = _context.Claims.Where(c => c.LecturerId == 1).ToList(); // Get lecturer's claims (assuming ID = 1 for the demo)
            return View(claims);
        }

        [HttpPost]
        public IActionResult SubmitClaim(Claim claim)
        {
            claim.TotalAmount = claim.HoursWorked * claim.HourlyRate;
            claim.Status = "Pending"; // Set initial status
            _context.Claims.Add(claim);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
