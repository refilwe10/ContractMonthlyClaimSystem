using ContractMonthlyClaimSystem.Controllers.Data;
using Microsoft.AspNetCore.Mvc;

public class LecturerController : Controller
{
    private readonly ApplicationDbContext _context;

    public LecturerController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Fetch lecturers or perform other actions
        var lecturers = _context.Lecturers.ToList();
        return View(lecturers);
    }
}

