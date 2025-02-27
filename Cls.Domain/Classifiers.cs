using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classifiers.Domain
{
    public class Classifier
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        public string? Name { get; set; }

        public virtual Classifier? Parent { get; set; }

        // Навигационное свойство для дочерних элементов
        public virtual ICollection<Classifier> Children { get; set; } = [];
    }
}
