import numpy as np
import pandas as pd
import csv

NOTESSHARP = [
    "A",
    "A#",
    "B",
    "C",
    "C#",
    "D",
    "D#",
    "E",
    "F",
    "F#",
    "G",
    "G#",
]

NOTESFLAT = [
    "A",
    "Bb",
    "B",
    "C",
    "Db",
    "D",
    "Eb",
    "E",
    "F",
    "Gb",
    "G",
    "Ab",
]

my_list = []
file = "chord-fingers.csv"
newFile = open("new-file.csv", "w", encoding="UTF8", newline="")
writer = csv.writer(newFile)


with open(file, "r") as file:
    my_file = csv.reader(file, delimiter=";")
    for row in my_file:
        my_list.append(row)


for row in my_list:
    arr = row[4].split(",")
    for i in range(0, len(arr)):
        if arr[i] in NOTESSHARP or arr[i] in NOTESFLAT:
            continue

        if arr[i][1] == "#":
            j = 1

            if arr[i][0:2] in NOTESSHARP:
                j = NOTESSHARP.index(arr[i][0:2])
            else:
                j = NOTESSHARP.index(arr[i][0])

            if arr[i] == "G##":
                arr[i] = "A"
                continue

            if len(arr[i]) == 3:
                arr[i] = NOTESSHARP[j + 2]

            if len(arr[i]) == 2:
                arr[i] = NOTESSHARP[j + 1]

            continue

        if arr[i][1] == "b":
            print(arr[i])
            print(i)
            j = 1

            if arr[i][0:2] in NOTESFLAT:
                j = NOTESFLAT.index(arr[i][0:2])
            else:
                j = NOTESFLAT.index(arr[i][0])

            if arr[i] == "Bbb":
                arr[i] = "A"
                continue

            if len(arr[i]) == 3:
                arr[i] = NOTESFLAT[j - 2]

            if len(arr[i]) == 2:
                arr[i] = NOTESFLAT[j - 1]

            continue

    newRow = row
    newRow[4] = " ".join(arr)
    writer.writerow(row)

newFile.close()
