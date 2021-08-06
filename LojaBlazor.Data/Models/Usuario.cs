namespace LojaBlazor.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    using Contracts;

    public class Usuario : IdentityUser, IAuditInfo, IDeletavelEntity
    {
        public Usuario() => this.Id = Guid.NewGuid().ToString();

        public string PrimeiroNome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime CriadoEm { get; set; }

        public DateTime? ModificadoEm { get; set; }

        public bool EstaDeletado { get; set; }

        public DateTime? DeletadoEm { get; set; }

        public ICollection<Endereco> Enderecos { get; } = new HashSet<Endereco>();

        public ICollection<Pedido> Pedidos { get; } = new HashSet<Pedido>();

        public ICollection<ListaDesejos> ListaDesejos { get; } = new HashSet<ListaDesejos>();

        public ICollection<CarrinhoCompras> CarrinhosCompras { get; } = new HashSet<CarrinhoCompras>();
    }
}