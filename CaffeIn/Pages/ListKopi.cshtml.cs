using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaffeIn.Models;
using CaffeIn.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaffeIn.Pages
{
    public class ListKopiModel : PageModel
    {
        private readonly IKopiRepository kopiRepository;
        private readonly AppDbContext appDbContext;

        public ListKopiModel(IKopiRepository kopiRepository,
                            AppDbContext appDbContext)
        {
            this.kopiRepository = kopiRepository;
            this.appDbContext = appDbContext;
        }

        public PaginatedList<Kopi> Kopis { get; set; }

        [BindProperty(SupportsGet = true)]
        public string cariKopi { get; set; }

        private IQueryable<Kopi> AllKopi { get; set; }

        /// <summary>
        ///  
        /// Percantik list kopi pages
        /// dan bikin fungsi search
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>

        public async Task OnGetAsync(int? pageIndex)
        {
            AllKopi = kopiRepository.SearchKopi(cariKopi);
            Kopis = await PaginatedList<Kopi>.CreateAsync(
                AllKopi, pageIndex ?? 1, 6);
        }
    }
}