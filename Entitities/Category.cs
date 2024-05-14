
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SmartFin.Entities
{
    public class Category : IEntity
    {
        [Key]
        public Guid guid { get; set; }

        public string name { get; set; }

        public decimal planSumm { get; set; }

        public decimal factSumm { get; set; }

        public Guid userId{get; set;}
        public User user { get; set; }

        public List<Expense>? expenses { get; set; } = new List<Expense>();
    }
}