using TreinamentoTDD.Dominio.Cursos;
using TreinamentoTDD.Dominio.DTO;
using TreinamentoTDD.Dominio.Interface;
using TreinamentoTDD.Dominio.Util;

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
            ValidacaoDominio.Validar()
                .Quando(_cursoRepositorio.ObterPeloNome(cursoDTO.nome) != null, MensagensErro.CursoJaCadastrado)
                .DispararValidacao();
            
            var curso = new Curso(cursoDTO.nome,
                                  cursoDTO.cargaHoraria,
                                  cursoDTO.publicoAlvo,
                                  cursoDTO.valor,
                                  cursoDTO.descricao);

            _cursoRepositorio.Adicionar(curso);
        }
    }
}
