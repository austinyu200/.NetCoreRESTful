using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicArchive.Entities
{
    [Table("Piece")]
    public class Piece
    {
        [Column("ComposerId")]
        public Guid ComposerId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("CreateDate")]
        public DateTime CreateDate { get; set; }

        [Column("Style")]
        public string Style { get; set; }
    }
}
