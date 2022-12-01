
class Cell:
    def getDistance(self):
        return abs(self.x) + abs(self.y)
    def getSteps(self):
        return self.steps[0] + self.steps[1]

    def __init__(self, x = 0, y = 0):
        self.x = x
        self.y = y
        self.steps = [0, 0]
        self.wires = [ False, False ]
        