using CrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        ViewBag.Mensaje = "Intento de inicio de sesión";

        var user = _context.Usuarios
            .FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            return RedirectToAction("Index", "Dashboard");
        }

        ViewBag.Error = "Usuario incorrecto";
        return View();
    }
}