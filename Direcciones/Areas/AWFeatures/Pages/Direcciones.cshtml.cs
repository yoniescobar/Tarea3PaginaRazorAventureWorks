using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdventureWorksNS.Data;

namespace AWFeatures.Pages
{
    public class DireccionesModel : PageModel
    {
        private AdventureWorksDB db;
        public Address[]? Direcciones { get; set; } = null;

        public DireccionesModel(AdventureWorksDB injectedContext)
        {
            db = injectedContext;
        }
        public void OnGet()
        {
            ViewData["Title"] = "AdventureWorks - Direcciones";
            Direcciones = db.Addresses.OrderBy(p => p.City).ToArray();
        }
    }
}
