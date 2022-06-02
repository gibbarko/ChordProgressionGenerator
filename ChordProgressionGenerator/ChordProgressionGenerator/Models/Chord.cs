using System;
using System.Collections.Generic;

namespace ChordProgressionGenerator.Models
{
    public class Chord
    {
        public int Id { get; set; }
        public string CHORD_ROOT { get; set; }
        public string CHORD_TYPE { get; set; }
        public string CHORD_STRUCTURE { get; set; }
        public string FINGER_POSITIONS { get; set; }
        public string NOTE_NAMES { get; set; }

        public Chord()
        {

        }
    }
}
