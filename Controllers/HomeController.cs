using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Models.Servicios;

namespace portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos repositorioProyectos;
    private readonly IServicioEmail servicioEmail;

    public HomeController(IRepositorioProyectos repositorioProyectos,IServicioEmail servicioEmail)
    {
        this.repositorioProyectos = repositorioProyectos;
        this.servicioEmail = servicioEmail;
    }

    public IActionResult Index()
    {
        var proyectos= repositorioProyectos.ObtenerProyectos().Take(23).ToList();
        var modelo=new HomeIndexViewModel(){Proyectos=proyectos};
        
        return View(modelo);
    }
   
    public IActionResult Proyectos()
    {
        var proyectos = repositorioProyectos.ObtenerProyectos();
        return View(proyectos);
    }
    [HttpGet]
    public IActionResult Contacto(){
        return View();
    }
    //post method
    [HttpPost]
    public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel) 
    {
        await servicioEmail.Enviar(contactoViewModel);
        return RedirectToAction("Thanks");
    }
    public IActionResult Thanks(){
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
