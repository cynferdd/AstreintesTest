using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controller de redirection vers la page d'accueil si on veut accéder à la racine du server
    /// Affichera une page d'aide décrivant les différentes routes disponibles pour l'API
    /// </summary>
    [Route("")]
    public class HomeController : Controller
    {
        /// <summary>
        /// affichage de /Views/Home/Index.cshtml
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

    }
}
