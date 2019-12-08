from cell import Cell

def intersections(c):
    return c.wires[0] == True and c.wires[1] == True

def addWire(x, y, wireId):
    c = map.get(f'{x},{y}', Cell(x, y))

    c.wires[wireId] = True
    map[f'{x},{y}'] = c
    return c

def up(count, position, wireId):
    x = position[0]
    y = position[1]

    for y1 in range(y + 1, y + count):
        addWire(x, y1, wireId)

    return  (x, y + count)

def down(count, position, wireId):
    x = position[0]
    y = position[1]

    for y1 in range(y - 1, y - count, -1):
        addWire(x, y1, wireId)

    return (x, y - count)

def left(count, position, wireId):
    x = position[0]
    y = position[1]

    for x1 in range(x - 1, x - count, -1):
        addWire(x1, y, wireId)

    return  (x - count, y)

def right(count, position, wireId):
    x = position[0]
    y = position[1]

    for x1 in range(x + 1, x + count):
        addWire(x1, y, wireId)

    return  (x + count, y)

def mapWire(wirePath, position, wireId):
    direction = wirePath[0]
    count = int(wirePath[1:])

    splitter = {
        'L' : left,
        'R' : right,
        'U' : up,
        'D' : down
    }
    func = splitter.get(direction)
    return func(count, position, wireId)


##################
origin = Cell(0,0)
map = { "0,0": origin }

with open('d:/projects/advent/3.txt') as fp:
    Wire1 = fp.readline()
    Wire2 = fp.readline()

position = (0,0)
for w in Wire1.split(','):
    position = mapWire(w, position, 0)

position = (0,0)
for w in Wire2.split(','):
    position = mapWire(w, position, 1)

filteredList = list(filter(intersections, map.values()))

filteredList.sort(key=lambda x: x.getDistance())

print(filteredList[0])