using System.ComponentModel.DataAnnotations.Schema;

namespace FunSuper.Server.Entities.Base
{
    public abstract class Entity 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}
