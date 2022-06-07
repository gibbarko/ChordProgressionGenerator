using System;
using System.ComponentModel.DataAnnotations;

namespace ChordProgressionGenerator.ViewModels
{
    public class NewProgressionViewModel
    {
        [Required]
        [Range(2, 10)]
        public int ChordNum { get; set; }

        [Required]
        public string ScaleType { get; set; }

        [Required]
        public string Key { get; set; }

    }
}
