
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFin.Entities
{

    public class Goal : IEntity
    {
        [Key]
        public Guid guid { get; set; }

        public DateTime startOfPeriod { get; set; }

        public DateTime endOfPeriod { get; set; }

        public string nameOfGoal { get; set; }

        public decimal sum { get; set; }

        public decimal payment { get; set; }

        public Guid userId{get;set;}
        public User user { get; set; }

        public List<Recomendation>? recomendations { get; set; }

    }

}