
using System.ComponentModel.DataAnnotations;

namespace SmartFin.Entities
{
    public class Expense : IEntity
    {
        [Key]
        public Guid guid { get; set; }

        public decimal sum { get; set; }

        public DateTime dateOfExpense { get; set; }

        public string name { get; set; }

        public Guid categoryId{ get; set; }
        public Category category { get; set; }
        public Guid userId{ get; set; }
        public User user { get; set; }
    }
}