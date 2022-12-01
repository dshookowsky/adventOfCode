import math
with open('14/input2.txt', 'rt') as fp:
    lines = fp.readlines();

class Reaction:
    def __init__(self, formula):
        self.components = {}

        components, output = formula.split('=>')
        self.parseComponents(components)
        self.quantity, self.reagent = output.strip().split(' ')
        self.quantity = int(self.quantity)

    def parseComponents(self, componentLine):
        for component in componentLine.strip().split(','):
            qty, reagent = component.strip().split(' ')
            self.components[reagent] = int(qty)


def calculateOre(reaction):
    totalOre = 0
    for c in reaction.components.keys():
        if c != 'ORE':

            qty, ore = calculateOre(reactions[c])
            qty += excess.get(c, 0)
            totalOre +=  math.ceil(reaction.components[c]/qty) * ore
            if qty > reaction.components[c]:
                excess[c] = qty - reaction.components[c]
        else:
            return reaction.quantity, reaction.components[c]
    return reaction.quantity, totalOre




reactions = {}
excess = {}

for l in lines:
    r = Reaction(l)
    reactions[r.reagent] = r

print(calculateOre(reactions['FUEL']))

