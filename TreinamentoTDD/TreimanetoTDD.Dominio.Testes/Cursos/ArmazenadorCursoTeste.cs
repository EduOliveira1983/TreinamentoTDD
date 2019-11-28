using Bogus;
using Moq;
using System;
using TreimanetoTDD.Dominio.Testes._Util;
using TreimanetoTDD.Dominio.Testes.Builders;
using TreinamentoTDD.Dominio.Cursos;
using TreinamentoTDD.Dominio.DTO;
using TreinamentoTDD.Dominio.Interface;
using TreinamentoTDD.Dominio.Service;
using TreinamentoTDD.Dominio.Util;
using Xunit;
using static TreinamentoTDD.Dominio.Enums.Enums;
using static TreinamentoTDD.Dominio.Util.ValidacaoDominio;

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
            var cursoSalvo = CursoBuilder.Novo().ComNome(cursoDTO.nome).Build();
            cursoRepositorioMock.Setup(r => r.ObterPeloNome(cursoDTO.nome)).Returns(cursoSalvo);

            Assert.Throws<DominioException>(() => armazenadorCurso.Armazenar(cursoDTO))
                .ComMensagem(MensagensErro.CursoJaCadastrado);
        }

        
    }
}
