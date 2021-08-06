namespace LojaBlazor.Data.Contracts
{
    using System;

    public abstract class BaseDeletavelModel : BaseModel, IDeletavelEntity
    {
        public bool EstaDeletado { get; set; }

        public DateTime? DeletadoEm { get; set; }
    }
}