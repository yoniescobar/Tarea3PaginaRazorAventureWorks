using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdventureWorksNS.Data;

namespace AWFeatures.Pages
{
    public class ProductosModel : PageModel
    {
        private AdventureWorksDB db;
        public Product[]? Productos { get; set; } = null;

        public ProductosModel(AdventureWorksDB injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "AdventureWorks - Produdctos";
            Productos = db.Products.OrderBy(p => p.Name).ToArray();
        }
    }
}
