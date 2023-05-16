﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Models.Servicios;

namespace portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepositorioProyectos repositorioProyectos;

    public HomeController(ILogger<HomeController> logger,IRepositorioProyectos repositorioProyectos)
    {
        _logger = logger;
        this.repositorioProyectos = repositorioProyectos;
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
