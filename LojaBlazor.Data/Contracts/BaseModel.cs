namespace LojaBlazor.Data.Contracts
{
    using System;

    public abstract class BaseModel : IAuditInfo
    {
        public DateTime CriadoEm { get; set; }

        public DateTime? ModificadoEm { get; set; }
    }
}