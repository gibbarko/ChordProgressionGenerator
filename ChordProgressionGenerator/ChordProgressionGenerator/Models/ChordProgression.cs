using System;
namespace ChordProgressionGenerator.Models
{
    public class ChordProgression
    {
        public int ProgressionId { get; set; }
        public Progression Progression { get; set; }

        public int ChordId { get; set; }
        public Chord Chord { get; set; }

        public ChordProgression()
        {
        }
    }
}
