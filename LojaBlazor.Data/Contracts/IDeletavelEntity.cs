namespace LojaBlazor.Data.Contracts
{
    using System;

    public interface IDeletavelEntity
    {
        bool EstaDeletado { get; set; }

        DateTime? DeletadoEm { get; set; }
    }
}