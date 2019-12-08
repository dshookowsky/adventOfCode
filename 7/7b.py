from IntCode import IntCode
from itertools import permutations

with open('7.txt', 'r') as fp:
    line = fp.readline()

#line = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5"
program = line.split(',')

maxThrusterOutput = 0

for input in permutations([5,6,7,8,9]):

    amps = []
    for phase in input:
        amp = IntCode(program.copy())
        amp.input.append(phase)
        amps.append(amp)

    amps[0].outputLocation = amps[1]
    amps[1].outputLocation = amps[2]
    amps[2].outputLocation = amps[3]
    amps[3].outputLocation = amps[4]
    amps[4].outputLocation = amps[0]

    amps[0].input.append(0)

    index = 0
    thrusterOutput = 0
    while any(a.running for a in amps):
        amps[index].tick()
        index = (index + 1) % 5

    thrusterOutput = amps[0].input.pop(0)
    if thrusterOutput > maxThrusterOutput:
        maxThrusterOutput = thrusterOutput
        maxInput = input

print(maxThrusterOutput)
print(maxInput)