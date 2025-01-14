using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace CardapioMVC.Models
{
    public class Prato
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Preencha esse campo com o nome")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Preencha esse campo com a descricao")]
        public required string Description { get; set; }
        [Required(ErrorMessage = "Preencha esse campo com o valor")]
        public double Preco { get; set; }
        [Required(ErrorMessage = "Selecione uma categoria.")]
        public Categoria CategoriaString { get; set; }
        [Required(ErrorMessage = "Preencha esse campo, se tem bebida inclusa")]
        public bool Bebida { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Categorias { get; set; }


    }


    public enum Categoria
    {
        Carnes = 0,
        Aves = 1,
        Vegetariano = 2
    }
}
