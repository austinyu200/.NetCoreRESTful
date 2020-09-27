using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicArchive.Entities
{
    [Table("Composer")]
    public class Composer
    {
        [Key]
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("Composer_Name")]
        public string ComposerName { get; set; }

        [Column("Born")]
        public DateTime? Born { get; set; }

        [Column("Passed")]
        public DateTime? Passed { get; set; }

    }
}
