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
            var cursoJaSalvo = _cursoRepositorio.ObterPeloNome(cursoDTO.nome);
            
            ValidacaoDominio.Validar()
                .Quando(cursoJaSalvo != null && cursoDTO.Id != cursoJaSalvo.Id , MensagensValidacao.CursoJaCadastrado)
                .ProcessarValidacao();


            var curso = new Curso(cursoDTO.nome,
                                  cursoDTO.cargaHoraria,
                                  cursoDTO.publicoAlvo,
                                  cursoDTO.valor,
                                  cursoDTO.descricao);

            if (cursoDTO.Id > 0)
            {
                curso = _cursoRepositorio.ObterPorId(cursoDTO.Id);
                curso.AlterarNome(cursoDTO.nome);
                curso.AlterarDescricao(cursoDTO.descricao);
                curso.AlterarCargaHoraria(cursoDTO.cargaHoraria);
                curso.AlterarPublicoAlvo(cursoDTO.publicoAlvo);
                curso.AlterarValor(cursoDTO.valor);
            }
            else
            {
                _cursoRepositorio.Adicionar(curso);
            }


        }
    }
}
