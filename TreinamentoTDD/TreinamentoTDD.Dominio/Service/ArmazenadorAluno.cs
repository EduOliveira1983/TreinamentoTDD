using TreinamentoTDD.Dominio.DTO;
using TreinamentoTDD.Dominio.Entidades;
using TreinamentoTDD.Dominio.Interface;
using TreinamentoTDD.Dominio.Util;

namespace TreinamentoTDD.Dominio.Service
{
    public class ArmazenadorAluno
    {
        private IAlunoRepositorio alunoRepositorio;
        public ArmazenadorAluno(IAlunoRepositorio a)
        {
            alunoRepositorio = a;
        }

        public void Armazenar(AlunoDTO alunoDTO)
        {
            var alunoCadastrado = alunoRepositorio.ObterPorId(alunoDTO.ID);

            ValidacaoDominio.Validar()
                .Quando(alunoCadastrado != null && alunoDTO.CPF != alunoCadastrado.CPF, MensagensValidacao.CPFJaCdastrado)
                .ProcessarValidacao();

            var aluno = new Aluno(alunoDTO.Nome,
                                  alunoDTO.CPF,
                                  alunoDTO.Email,
                                  alunoDTO.publicoAlvo);

            if (alunoDTO.ID > 0)
            {
                aluno = alunoRepositorio.ObterPorId(alunoDTO.ID);
                aluno.AlterarNome(alunoDTO.Nome);
            }
            else
                alunoRepositorio.Adicionar(aluno);
        }

       
    }
}
