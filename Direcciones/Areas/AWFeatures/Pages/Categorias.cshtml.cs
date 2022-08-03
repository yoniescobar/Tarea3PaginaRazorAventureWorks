using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdventureWorksNS.Data;

namespace AWFeatures.Pages
{
    public class CategoriasModel : PageModel
    {
        private AdventureWorksDB db;
        public IEnumerable<ProductCategory>? Categorias { get; set; }

        [BindProperty]
        public ProductCategory? Categoria { get; set; }
        
        public CategoriasModel(AdventureWorksDB injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "AdventureWorks - Categoria";
            Categorias = db.ProductCategories.OrderBy(c => c.Name).ToArray();
        }

        public IActionResult OnPost()
        {
            if (Categoria is not null)
            {
               
                db.ProductCategories.Add(Categoria);
                db.SaveChanges();
                return RedirectToAction("/Categorias");
            }
            else
            {
                return Page();
            }
        }

    }
}
