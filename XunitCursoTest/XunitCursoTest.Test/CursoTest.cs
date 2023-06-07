namespace Recuperacao.Test;
using ExpectedObjects;
using Xunit;
using global::Test._Util;

public class CursoTest
{
   private string _nome, _publico;
   private double _cargaHoraria, _valor;

   public CursoTest()
   {
      _nome = "Banco de dados";
      _cargaHoraria = 80;
      _publico = "Universidade";
      _valor = 150.00;
   }

   [Fact]
   public void CriarCurso()
   {
      var cursoEsperado = new
      {
         Nome = _nome,
         CargaHoraria = _cargaHoraria,
         Publico = _publico,
         Valor = _valor
      };

      Curso novoCurso = new Curso(
          cursoEsperado.Nome,
          cursoEsperado.CargaHoraria,
          cursoEsperado.Publico,
          cursoEsperado.Valor
      );
      cursoEsperado.ToExpectedObject().ShouldMatch(novoCurso);
   }

   [Theory]
   [InlineData("")]
   [InlineData(null)]
   public void CursoNomeVazio(string nome)
   {
      Assert.Throws<ArgumentException>(()
      => new Curso(nome, _cargaHoraria, _publico, _valor));
   }

   [Theory]
   [InlineData(0)]
   [InlineData(-1)]
   public void CursoCargaHorariaInvalida(double cargaHoraria)
   {
      Assert.Throws<ArgumentException>(()
      => new Curso(_nome, cargaHoraria, _publico, _valor)).ComMensagem("Carga horária inválida");
   }
}

public class Curso
{
   private string nome;
   private double cargaHoraria;
   private string publico;
   private double valor;

   public string Nome { get => nome; set => nome = value; }
   public double CargaHoraria { get => cargaHoraria; set => cargaHoraria = value; }
   public string Publico { get => publico; set => publico = value; }
   public double Valor { get => valor; set => valor = value; }

   public Curso(string nome, double cargaHoraria, string publico, double valor)
   {
      if (string.IsNullOrEmpty(nome))
         throw new ArgumentException("Nome inválido");
      if (cargaHoraria <= 0)
         throw new ArgumentException("Carga horária inválida");
      Nome = nome;
      CargaHoraria = cargaHoraria;
      Publico = publico;
      Valor = valor;
   }
}

