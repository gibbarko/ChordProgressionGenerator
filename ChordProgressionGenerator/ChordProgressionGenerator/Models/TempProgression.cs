using System;
using System.Collections.Generic;

namespace ChordProgressionGenerator.Models
{
    public class TempProgression
    {
        public int ChordNum { get; set; }
        public string Name { get; set; }
        public string RootNote { get; set; }
        public string ScaleType { get; set; }
        public string ChordString { get; set; }
        public List<Chord> Chords { get; set; }

        public TempProgression()
        {
        }

        public TempProgression(int ChordNum, string RootNote, string ScaleType)
        {
            this.RootNote = RootNote;
            this.ChordNum = ChordNum;
            this.ScaleType = ScaleType;
        }

    }
}
