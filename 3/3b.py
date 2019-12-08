from cell import Cell
steps = 0

def intersections(c):
    return c.wires[0] == True and c.wires[1] == True

def addWire(x, y, wireId):
    global steps
    c = map.get(f'{x},{y}', Cell(x, y))
    
    steps += 1
    c.steps[wireId] = steps
        

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
# Wire1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72"
# Wire2 = "U62,R66,U55,R34,D71,R55,D58,R83"

# Wire1 = "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51"
# Wire2 = "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"

position = (0,0)
steps = 0
for w in Wire1.split(','):
    position = mapWire(w, position, 0)
    steps += 1

position = (0,0)
steps = 0
for w in Wire2.split(','):
    position = mapWire(w, position, 1)
    steps += 1


filteredList = list(filter(intersections, map.values()))

filteredList.sort(key=lambda x: x.getSteps())

print(filteredList[0].getSteps())