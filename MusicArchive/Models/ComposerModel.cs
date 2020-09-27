using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicArchive.Models
{
    public class GetComposerByNameRequestModel
    {
        [Required]
        public string Name { get; set; }
    }

    public class AddComposerRequestModel
    {
        [Required]
        public string ComposerName { get; set; }

        public DateTime? Born { get; set; }

        public DateTime? Passed { get; set; }
    }

    public class RemoveComposerRequestModel
    { 
        public string ComposerName { get; set; }
    }

    public class UpdateComposerRequestModel
    {
        [Required]
        public string Name { get; set; }
        
        public string UpdateName { get; set; }

        public DateTime? Born { get; set; }

        public DateTime? Passed { get; set; }
    }
}
