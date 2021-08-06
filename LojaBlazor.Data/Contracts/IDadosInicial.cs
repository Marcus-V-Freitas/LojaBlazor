namespace LojaBlazor.Data.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IDadosInicial
    {
        Type TipoEntidade { get; }

        IEnumerable<object> RecuperarDados();
    }
}
