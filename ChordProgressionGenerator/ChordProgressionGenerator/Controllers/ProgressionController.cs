using System;
using System.Collections.Generic;
using System.Linq;
using ChordProgressionGenerator.Data;
using ChordProgressionGenerator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChordProgressionGenerator.Controllers
{
    [Authorize]
    public class ProgressionController : Controller
    {
        private ApplicationDbContext context;

        public ProgressionController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        //adds an "m" to root note if chord is minor, checks if chord is in Key
        private bool IsChordInKey(string[] notes, Chord chord)
        {
            string chordString = chord.CHORD_ROOT;

            if (chord.CHORD_TYPE[0] == 'm' && (chord.CHORD_TYPE.Length == 1 || chord.CHORD_TYPE[1] != 'a'))
            {
                chordString += "m";
            }

            return (notes.Contains(chordString));
        }

        public string[] FindKey(string rootNote, string scaleType)
        {
            List<Key> keys = context.Keys.ToList();

            Key key = keys.Find(k => k.ROOT_NOTE == rootNote && k.SCALE_TYPE == scaleType);

            string[] notes = key.NOTES.Split(", ");

            return notes;
        }

        //Main function for generating random chord progression string return string of id numbers
        private string GenerateChordProgression(int chordNum, string rootNote, string scaleType)
        {
            chordNum = 4;
            rootNote = "A";
            scaleType = "Minor";

            string[] key = FindKey(rootNote, scaleType);

            int[] chordId = new int[chordNum];
            Random rnd = new Random();

            for (int i = 0; i < chordNum; i++)
            {
                int randId = rnd.Next(1, 2632);

                while (!(IsChordInKey(key, context.Chords.Find(randId))))
                {
                    randId = rnd.Next(1, 2632);
                }

                chordId[i] = randId;
            }

            string[] result = Array.ConvertAll(chordId, x => x.ToString());
            Console.WriteLine(string.Join(", ", result));
            return string.Join(", ", result);
        }

        //converts chord progression string into chord objects
        private List<Chord> ConvertStringToChords(string chordIds)
        {
            List<Chord> chords = new List<Chord>();
            string[] strArr = chordIds.Split(", ");

            int[] ints = Array.ConvertAll(strArr, s => int.Parse(s));

            foreach (int id in ints)
            {
                Chord chord = context.Chords.Find(id);

                chords.Add(chord);
            };

            return chords;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            string chordString = GenerateChordProgression(4, "A", "Minor");

            List<Chord> chordProgression = ConvertStringToChords(chordString);

            return View(chordProgression);
        }

    }
}
