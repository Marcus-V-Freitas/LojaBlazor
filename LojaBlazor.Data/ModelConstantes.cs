namespace LojaBlazor.Data
{
    public class ModelConstantes
    {
        public class Common
        {
            public const int TamanhoMinNome = 3;
            public const int TamanhoMaxNome = 50;
        }

        public class Identity
        {
            public const int TamanhoMinEmail = 3;
            public const int TamanhoMaxEmail = 50;
            public const int TamanhoMinSenha = 6;
        }

        public class Endereco
        {
            public const int TamanhoMaxPais = 255;
            public const int TamanhoMinCidade = 255;
            public const int TamanhoMaxEstado = 255;
            public const int TamanhoMaxDescricao = 1000;
            public const int TamanhoMaxCodigoPostal = 10;
            public const int TamanhoMinNumeroTelefone = 5;
            public const int TamanhoMaxNumeroTelefone = 20;
            public const string RegexNumeroTelefone = @"\+[0-9]*";
        }

        public class Produto
        {
            public const int QuantidadeMin = 1;
            public const int QuantidadeMax = int.MaxValue;
            public const int TamanhoMaxUrl = 2048;
            public const int TamanhoMaxDescricao = 1000;
            public const string PrecoMin = "1";
            public const string PrecoMax = "100000";
        }
    }
}