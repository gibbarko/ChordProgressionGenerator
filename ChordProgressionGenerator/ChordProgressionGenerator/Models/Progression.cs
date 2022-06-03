using System;
using System.Collections.Generic;

namespace ChordProgressionGenerator.Models
{
    public class Progression
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Chord> Chords { get; set; }

        public Progression()
        {
        }

    }
}
