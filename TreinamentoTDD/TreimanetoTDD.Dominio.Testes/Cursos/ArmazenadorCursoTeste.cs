using Bogus;
using Moq;
using TreimanetoTDD.Dominio.Testes._Util;
using TreimanetoTDD.Dominio.Testes.Builders;
using TreinamentoTDD.Dominio.Cursos;
using TreinamentoTDD.Dominio.DTO;
using TreinamentoTDD.Dominio.Interface;
using TreinamentoTDD.Dominio.Service;
using TreinamentoTDD.Dominio.Util;
using Xunit;
using static TreinamentoTDD.Dominio.Enums.Enums;

namespace TreimanetoTDD.Dominio.Testes.Cursos
{
    public class ArmazenadorCursoTeste
    {
        CursoDTO cursoDTO;
        private readonly Mock<ICursoRepositorio> cursoRepositorioMock;
        private ArmazenadorCurso armazenadorCurso;

        public ArmazenadorCursoTeste()
        {
            var fake = new Faker();
            cursoRepositorioMock = new Mock<ICursoRepositorio>();
            armazenadorCurso = new ArmazenadorCurso(cursoRepositorioMock.Object);

            cursoDTO = new CursoDTO
            {
                nome = fake.Random.Words(),
                descricao = fake.Lorem.Paragraph(),
                cargaHoraria = fake.Random.Int(1, 2000),
                publicoAlvo = fake.PickRandomWithout(PublicoAlvo.Professor),
                valor = fake.Random.Decimal(100, 3000)
            };
        }
        [Fact]
        public void DeveAdicionarCurso()
        {   
            armazenadorCurso.Armazenar(cursoDTO);

            cursoRepositorioMock.Verify(r => r.Adicionar(It.Is<Curso>(c => c.Nome == cursoDTO.nome &&
                                                                       c.Descricao == cursoDTO.descricao &&
                                                                       c.CargaHoraria == cursoDTO.cargaHoraria &&
                                                                       c.PublicoAlvo == cursoDTO.publicoAlvo &&
                                                                       c.Valor == cursoDTO.valor)));
        }

        [Fact]
        public void NaoDeveSalvarCursoComMesmoNomedeCursoJaSalvo()
        {
            var cursoSalvo = CursoBuilder.Novo().ComId(2912).ComNome(cursoDTO.nome).Build();
            cursoRepositorioMock.Setup(r => r.ObterPeloNome(cursoDTO.nome)).Returns(cursoSalvo);

            Assert.Throws<DominioException>(() => armazenadorCurso.Armazenar(cursoDTO))
                .ComMensagem(MensagensValidacao.CursoJaCadastrado);
        }

        [Fact]
        public void DeveAlterarCurso()
        {
            cursoDTO.Id = 1309;
            var cursoSalvo = CursoBuilder.Novo().Build();
            cursoRepositorioMock.Setup(m => m.ObterPorId(cursoDTO.Id)).Returns(cursoSalvo);

            armazenadorCurso.Armazenar(cursoDTO);

            Assert.Equal(cursoDTO.nome, cursoSalvo.Nome);
            Assert.Equal(cursoDTO.descricao, cursoSalvo.Descricao);
            Assert.Equal(cursoDTO.cargaHoraria, cursoSalvo.CargaHoraria);
            Assert.Equal(cursoDTO.publicoAlvo, cursoSalvo.PublicoAlvo);
            Assert.Equal(cursoDTO.valor, cursoSalvo.Valor);
                       
        }

        [Fact]
        public void NaoDeveIncluirCursoJaExistente()
        {
            cursoDTO.Id = 1612;
            var curso = CursoBuilder.Novo().Build();

            cursoRepositorioMock.Setup(r => r.ObterPorId(cursoDTO.Id)).Returns(curso);

            armazenadorCurso.Armazenar(cursoDTO);

            cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()), Times.Never);
        }
        
    }
}
