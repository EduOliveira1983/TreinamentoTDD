using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreinamentoTDD.Dominio.Entidades;
using TreinamentoTDD.Dominio.DTO;
using TreinamentoTDD.Dominio.Interface;
using TreinamentoTDD.Dominio.Service;
using TreinamentoTDD.Web.Util;

namespace TreinamentoTDD.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ArmazenadorCurso _armazenadorCurso;
        private readonly ICursoRepositorio _cursoRepositorio;

        public CursoController(ArmazenadorCurso armazenadorCurso, ICursoRepositorio cursoRepositorio)
        {
            _armazenadorCurso = armazenadorCurso;
            _cursoRepositorio = cursoRepositorio;
        }

        public IActionResult Index()
        {

            var cursos = _cursoRepositorio.Consultar();
            List<CursoDTO> dtos = null;

            if (cursos.Any())
            {
                dtos = cursos.Select(c => new CursoDTO
                {
                    cargaHoraria = c.CargaHoraria,
                    descricao = c.Descricao,
                    Id = c.Id,
                    nome = c.Nome,
                    publicoAlvo = c.PublicoAlvo,
                    valor = c.Valor
                }).ToList();
            }
            return View("Index", PaginatedList<CursoDTO>.Create(dtos, Request));
        }

        public IActionResult Novo()
        {
            return View("Novo", new CursoDTO());
        }

        [HttpPost]
        public IActionResult Novo(CursoDTO model)
        {
            _armazenadorCurso.Armazenar(model);
            return Index();
        }

        public IActionResult Edit(int id)
        {
            var curso = _cursoRepositorio.ObterPorId(id);

            var CursoEncontrado = new CursoDTO
            {
                cargaHoraria = curso.CargaHoraria,
                descricao = curso.Descricao,
                Id = curso.Id,
                nome = curso.Nome,
                publicoAlvo = curso.PublicoAlvo,
                valor = curso.Valor
            };

            return View("Edit", CursoEncontrado);
        }

        [HttpPost]
        public IActionResult Edit(CursoDTO model)
        {
            _armazenadorCurso.Armazenar(model);
            return Index();
        }



    }
}