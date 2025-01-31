using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using poe_part2.Data;


namespace poe_part2.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Dashboard (Shows all pending claims for approval or rejection)
        public IActionResult Dashboard()
        {
            var pendingClaims = ClaimStorage.Claims
                .Where(c => c.Status == "Pending") // Get pending claims
                .ToList();

            return View(pendingClaims);
        }

        // POST: Admin/Approve (Approve a specific claim)
        [HttpPost]
        public IActionResult Approve(int id)
        {
            var claim = ClaimStorage.Claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim != null)
            {
                claim.Status = "Approved";  // Update the status to Approved
            }
            return RedirectToAction("Dashboard");
        }

        // POST: Admin/Reject (Reject a specific claim)
        [HttpPost]
        public IActionResult Reject(int id)
        {
            var claim = ClaimStorage.Claims.FirstOrDefault(c => c.ClaimId == id);
            if (claim != null)
            {
                claim.Status = "Rejected";  // Update the status to Rejected
            }
            return RedirectToAction("Dashboard");
        }
    }
}