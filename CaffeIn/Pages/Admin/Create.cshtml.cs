using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CaffeIn.Models;
using CaffeIn.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CaffeIn.Pages
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IKopiRepository kopiRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CreateModel(IKopiRepository kopiRepository,
                            IWebHostEnvironment webHostEnvironment)
        {
            this.kopiRepository = kopiRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Kopi KopiViewModel { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (KopiViewModel.PhotoPath != null)
                    {
                        string deletePhotoPath = Path.Combine(webHostEnvironment.WebRootPath, "img",
                            KopiViewModel.PhotoPath);
                        System.IO.File.Delete(deletePhotoPath);
                    }

                    KopiViewModel.PhotoPath = UploadPhoto();
                }
                KopiViewModel = kopiRepository.AddKopi(KopiViewModel);
                return RedirectToPage("/Index");
            }
            return Page();
        }


        private string UploadPhoto()
        {
            string namaUnikFile = string.Empty;

            if (Photo != null)
            {
                string folderUpload = Path.Combine(webHostEnvironment.WebRootPath, "img");
                namaUnikFile = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(folderUpload, namaUnikFile);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                };

            }
            return namaUnikFile;
        }
    }
}