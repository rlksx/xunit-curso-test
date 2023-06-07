namespace Test._Util;
using Xunit;

public static class ArgumentoExtensao
{
   public static void ComMensagem(this ArgumentException exception, string mensagem)
   {
      if (exception.Message == mensagem)
         Assert.True(true);
      else
         Assert.False(true, $"Esperava a mensagem '{mensagem}'");
   }
}