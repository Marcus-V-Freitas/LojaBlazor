namespace LojaBlazor.Models.Pedidos
{
    using System.ComponentModel.DataAnnotations;

    public class PedidosRequestModel
    {
        [Required]
        public int EnderecoId { get; set; }
    }
}