using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdventureWorksNS.Data;

namespace AdventureWorksWeb.Pages
{
    public class ClientesModel : PageModel
    {
        private AdventureWorksDB db;
        public IEnumerable<Customer>? Clientes { get; set; }

        [BindProperty]
        public Customer? Cliente { get; set; }
        
        public ClientesModel(AdventureWorksDB injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "AdventureWorks - Clientes";
            Clientes = db.Customers.OrderBy(c => c.LastName);
        }

        public IActionResult OnPost()
        {
            if (Cliente is not null)
            {
                Cliente.PasswordHash = "Temp";
                Cliente.PasswordSalt = "Temp";
                db.Customers.Add(Cliente);
                db.SaveChanges();
                return RedirectToAction("/Clientes");
            }
            else
            {
                return Page();
            }
        }

    }
}
