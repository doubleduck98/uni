import numpy as np
import argparse

parser = argparse.ArgumentParser()
parser.add_argument("file")
args = parser.parse_args()

with open(args.file) as f:
    vars = [int(line.rstrip()) for line in f]
    print(np.var(vars))
