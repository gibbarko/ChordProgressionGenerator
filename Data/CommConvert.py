import numpy as np
import pandas as pd


file = "chord-fingers.csv"

df = pd.read_table(file, delimiter=", ")

print(df.head(10))
