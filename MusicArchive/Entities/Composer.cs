using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicArchive.Entities
{
    [Table("Composer")]
    public class Composer
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Born")]
        public DateTime Born { get; set; }

        [Column("Passed")]
        public DateTime Passed { get; set; }

    }
}
