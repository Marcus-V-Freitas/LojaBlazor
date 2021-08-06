namespace LojaBlazor.Data.Models
{
    using System;

    using Microsoft.AspNetCore.Identity;

    using Contracts;

    public class Role : IdentityRole, IAuditInfo, IDeletavelEntity
    {
        public Role()
            : this(null)
        {
        }

        public Role(string name)
            : base(name)
            => this.Id = Guid.NewGuid().ToString();

        public DateTime CriadoEm { get; set; }

        public DateTime? ModificadoEm { get; set; }

        public bool EstaDeletado { get; set; }

        public DateTime? DeletadoEm { get; set; }
    }
}