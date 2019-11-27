using System;
using TreinamentoTDD.Dominio.Cursos;
using TreinamentoTDD.Dominio.DTO;
using TreinamentoTDD.Dominio.Interface;

namespace TreinamentoTDD.Dominio.Service
{
    public class ArmazenadorCurso
    {
        private ICursoRepositorio _cursoRepositorio;

        public ArmazenadorCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDTO cursoDTO)
        {
            if (_cursoRepositorio.ObterPeloNome(cursoDTO.nome) != null)
                throw new ArgumentException("Curso já armazenado");

            var curso = new Curso(cursoDTO.nome,
                                  cursoDTO.cargaHoraria,
                                  cursoDTO.publicoAlvo,
                                  cursoDTO.valor,
                                  cursoDTO.descricao);

            _cursoRepositorio.Adicionar(curso);
        }
    }
}
