import numpy as np
import pandas as pd
import csv

NOTES = {
    "A": [5, 0, 7, 2, 10, 5],
    "A#": [6, 1, 8, 3, 11, 6],
    "Bb": [6, 1, 8, 3, 11, 6],
    "B": [7, 2, 9, 4, 0, 7],
    "C": [8, 3, 10, 5, 1, 8],
    "C#": [9, 4, 11, 6, 2, 9],
    "Db": [9, 4, 11, 6, 2, 9],
    "D": [10, 5, 0, 7, 3, 10],
    "D#": [11, 6, 1, 8, 4, 11],
    "Eb": [11, 6, 1, 8, 4, 11],
    "E": [0, 7, 2, 9, 5, 0],
    "F": [1, 8, 3, 10, 6, 1],
    "F#": [2, 9, 4, 11, 7, 2],
    "Gb": [2, 9, 4, 11, 7, 2],
    "G": [3, 10, 5, 0, 8, 3],
    "G#": [4, 11, 6, 1, 9, 4],
    "Ab": [4, 11, 6, 1, 9, 4],
}

my_list = []
file = "new-file.csv"
newFile = open("fretted-file.csv", "w", encoding="UTF8", newline="")
writer = csv.writer(newFile)
header = [
    "CHORD_ROOT",
    "CHORD_TYPE",
    "CHORD_STRUCTURE",
    "FINGER_POSITIONS",
    "NOTE_NAMES",
    "FRETS",
]

writer.writerow(header)

with open(file, "r") as file:
    my_file = csv.reader(file, delimiter=",")
    for row in my_file:
        my_list.append(row)

for row in my_list:
    frets = []
    fingers = row[3].split(",")
    curNotes = row[4].split(" ")

    for i in range(0, len(fingers)):
        if fingers[i] == "x":
            frets.append("x")
            continue

        note = curNotes.pop(0)

        frets.append(NOTES[note][i])

    frets = ", ".join(map(lambda x: str(x), frets))
    row.append(frets)
    writer.writerow(row)


newFile.close()
