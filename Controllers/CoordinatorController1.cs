using ContractMonthlyClaimSystem.Controllers.Data;
using Microsoft.AspNetCore.Mvc;

public class CoordinatorController : Controller
{
    private readonly ApplicationDbContext _context;

    public CoordinatorController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Fetch coordinators or perform other actions

        var coordinators = _context.ProgrammeCoordinators.ToList();
        return View(coordinators);
    }
}

