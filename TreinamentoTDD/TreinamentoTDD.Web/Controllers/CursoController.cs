﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreinamentoTDD.Dominio.Cursos;
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
    }
}