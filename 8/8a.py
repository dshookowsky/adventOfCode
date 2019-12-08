
def getNumberCount(layer, number):
    numberCount = 0
    for row in layer:
        for cell in row:
            if cell == number:
                numberCount += 1
    return numberCount

width = 25 # 3
height = 6 # 2

with open('d:/projects/advent/8/8.txt','r') as fp:
    data = fp.readline().rstrip()
#data = "123456789012"

layers = []

index = 0
while index < len(data):
    layer = []
    for x in range(height):
        row = []
        for y in range(width):
            row.append(int(data[index]))
            index += 1
        layer.append(row)

    layers.append(layer)


zeroLayer = None
minZeroCount = width * height

for l in layers:
    zeroCount = getNumberCount(l, 0)
    if zeroCount < minZeroCount:
        zeroLayer = l
        minZeroCount = zeroCount

oneCount = getNumberCount(zeroLayer, 1)
twoCount = getNumberCount(zeroLayer, 2)

print (oneCount * twoCount)

