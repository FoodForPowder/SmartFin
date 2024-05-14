
using System.ComponentModel.DataAnnotations;

namespace SmartFin.Entities{

    public class Recomendation : IEntity
    {
        [Key]
        public Guid guid { get; set; }

        public string message{ get; set; }

        public DateTime dateOfRecommendation{ get; set; }

        public Guid? goalId{get;set;}
        public Goal? goal { get; set; }

        public Guid userId{get; set;}

        public User? user { get; set; }

    }
}