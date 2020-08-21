using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaffeIn.Models;
using CaffeIn.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaffeIn.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IKopiRepository kopiRepository;

        public IndexModel(IKopiRepository kopiRepository)
        {
            this.kopiRepository = kopiRepository;
        }

        // Display Model

        public IEnumerable<Kopi> Kopis { get; set; }

        public void OnGet()
        {
            Kopis = kopiRepository.GetAllKopi();
        }

        public IActionResult OnPostHapusKopi(int Id)
        {
            kopiRepository.HapusKopi(Id);
            return RedirectToPage("Index");
        }
    }
}