using System;
namespace ChordProgressionGenerator.Models
{
    public class Progression
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string Name { get; set; }
        public string RootNote { get; set; }
        public string ScaleType { get; set; }
        public string ChordString { get; set; }

        public Progression()
        {
        }

        public Progression(string name)
        {
            Name = name;
        }
    }
}
