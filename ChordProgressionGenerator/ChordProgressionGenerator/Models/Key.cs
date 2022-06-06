using System;
using System.Collections.Generic;

namespace ChordProgressionGenerator.Models
{
    public class Key
    {
        public int Id { get; set; }
        public string ROOT_NOTE { get; set; }
        public string SCALE_TYPE { get; set; }
        public string NOTES { get; set; }
    }
}
