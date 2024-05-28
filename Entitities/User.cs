using System.ComponentModel.DataAnnotations;

namespace SmartFin.Entities
{

    public class User : IEntity
    {
        [Key]
        public Guid guid { get; set; }

        [Required]  
        public string number { get; set; }

        public decimal income { get; set; }

        public Goal? goal { get; set; }
      
        public List<Expense>? Expenses { get; set; } = new List<Expense>();

        public List<Recomendation> Recomendations { get; set; } = new();

        public List<Category>? Categorys  { get; set; } = new List<Category>();

    }
}