using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTesteFactory.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o E-mail do cliente")]
        [EmailAddress(ErrorMessage = "E-mail informado não é válido")]
        [StringLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o número de celular do cliente")]
        [Phone(ErrorMessage = "Número informado não é válido")]
        [StringLength(15)]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Digite oas informações de Endereço do cliente")]
        public virtual EnderecoModel Endereco { get; set; }
    }
}
