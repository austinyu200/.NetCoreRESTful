using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MusicArchive.Entities
{
    [Table("Piece")]
    public class Piece
    {
        [Column("Id")]
        public Guid Id { get; set; }

        [Column("ComposerId")]
        public Guid ComposerId { get; set; }

        [NotMapped]
        public string ComposerName { get; set; }

        [Column("Piece_Name")]
        public string PieceName { get; set; }

        [Column("CreateDate")]
        public DateTime? CreateDate { get; set; }

        [Column("Style")]
        public string Style { get; set; }
    }
}
