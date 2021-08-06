namespace LojaBlazor.Data.Contracts
{
    using System;

    public interface IAuditInfo
    {
        DateTime CriadoEm { get; set; }

        DateTime? ModificadoEm { get; set; }
    }
}