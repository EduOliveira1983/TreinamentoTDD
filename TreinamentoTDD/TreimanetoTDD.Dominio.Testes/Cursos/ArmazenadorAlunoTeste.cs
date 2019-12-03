using Bogus;
using Moq;
using TreimanetoTDD.Dominio.Testes._Util;
using TreimanetoTDD.Dominio.Testes.Builders;
using TreinamentoTDD.Dominio.DTO;
using TreinamentoTDD.Dominio.Entidades;
using TreinamentoTDD.Dominio.Interface;
using TreinamentoTDD.Dominio.Service;
using TreinamentoTDD.Dominio.Util;
using Xunit;
using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreimanetoTDD.Dominio.Testes.Cursos
{
    public class ArmazenadorAlunoTeste
    {
        private readonly Mock<IAlunoRepositorio> IRepositorioAlunoMock;
        private ArmazenadorAluno armazenadorAluno;
        
        AlunoDTO alunoDTO;
        Faker faker;

        public ArmazenadorAlunoTeste()
        {
            IRepositorioAlunoMock = new Mock<IAlunoRepositorio>();
            armazenadorAluno = new ArmazenadorAluno(IRepositorioAlunoMock.Object);
            faker = new Faker();
            alunoDTO = new AlunoDTO
            {
                CPF = "22018291874",
                Email = faker.Internet.Email(),
                Nome = faker.Person.FullName,                
                publicoAlvo = faker.PickRandomWithout<PublicoAlvo>(PublicoAlvo.Professor)
            };
        }        

        [Fact]
        private void DeveArmazenarAluno()
        {
            armazenadorAluno.Armazenar(alunoDTO);
            IRepositorioAlunoMock.Verify(r => r.Adicionar(It.Is<Aluno>(c => c.CPF == alunoDTO.CPF &&
                                                                            c.Email == alunoDTO.Email &&
                                                                            c.Nome == alunoDTO.Nome &&
                                                                            c.PublicoAlvo == alunoDTO.publicoAlvo)
                                                                        ));
        }

        [Fact]
        private void NaoDeveArmazenarAlunoCPFCadastrado()
        {
            var alunoCadastrado = AlunoBuilder.Novo().ComId(13009).ComCPF("28982283897").Build();
            IRepositorioAlunoMock.Setup(r => r.ObterPorId(alunoDTO.ID)).Returns(alunoCadastrado);

            Assert.Throws<DominioException>(() => armazenadorAluno.Armazenar(alunoDTO))
                .ComMensagem(MensagensValidacao.CPFJaCdastrado);
        }

        [Fact]
        private void DeveAlterarAluno()
        {
            alunoDTO.ID = 1309;
            var alunoSalvo = AlunoBuilder.Novo().Build();
            IRepositorioAlunoMock.Setup(r => r.ObterPorId(alunoDTO.ID)).Returns(alunoSalvo);

            armazenadorAluno.Armazenar(alunoDTO);

            Assert.Equal(alunoDTO.Nome, alunoSalvo.Nome);            
        }

        [Fact]
        private void NaoDeveCadastrarAlunoJaCadastrado()
        {
            alunoDTO.ID = 1612;
            var alunoSalvo = AlunoBuilder.Novo().Build();

            IRepositorioAlunoMock.Setup(r => r.ObterPorId(alunoDTO.ID)).Returns(alunoSalvo);
            armazenadorAluno.Armazenar(alunoDTO);

            IRepositorioAlunoMock.Verify(r => r.Adicionar(It.IsAny<Aluno>()), Times.Never);
        }        
        
    }
}
