using MusicArchive.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicArchive.Models
{
    public class AddPieceRequestModel
    {
        public string ComposerName { get; set; }

        [Required]
        public string PieceName { get; set; }

        public DateTime? CreateDate { get; set; }

        [Required]
        public string Style { get; set; }
    }

    public class AddPieceResponseModel
    { 
        public bool IsAddSuccess { get; set; }

        public Piece Piece { get; set; }
    }

    public class GetPiecesByComposerRequestModel
    {
        [Required]
        public string Composer { get; set; }
    }

}
