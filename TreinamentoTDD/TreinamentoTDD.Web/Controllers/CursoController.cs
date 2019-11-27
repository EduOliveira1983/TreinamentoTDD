using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreinamentoTDD.Dominio.DTO;
using TreinamentoTDD.Dominio.Service;
using TreinamentoTDD.Web.Util;

namespace TreinamentoTDD.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ArmazenadorCurso _armazenadorCurso;

        public CursoController(ArmazenadorCurso armazenadorCurso)
        {
            _armazenadorCurso = armazenadorCurso;
        }

        public IActionResult Index()
        {
            
            var cursos = new List<CursoDTO>();
            return View("Index", PaginatedList<CursoDTO>.Create(cursos,Request));
        }

        public IActionResult Novo()
        {
            return View("Novo", new CursoDTO());
        }

        [HttpPost]
        public IActionResult Novo(CursoDTO model)
        {
            _armazenadorCurso.Armazenar(model);
            return Ok();
        }
    }
}