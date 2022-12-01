
with open('6.txt', 'r') as fp:
    lines = fp.readlines()

dict = dict()

lines = [
    "COM)B",
    "B)C",
    "C)D",
    "D)E",
    "E)F",
    "B)G",
    "G)H",
    "D)I",
    "E)J",
    "J)K",
    "K)L"
]

for l in lines:
    c, o = l.split(')')
    dict[c] = o

