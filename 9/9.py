class IntCode:
    def debugMessage(self, msg):
        if self.debug:
            print(msg)
    def getPositionValue(self, location):
        return int(self.program[int(self.program[location])])

    def getImmediateValue(self, location):
        return int(self.program[location])

    def getRelativeValue(self, location):
        return int(self.program[self.getImmediateValue(location) + self.relativeBase])

    def add(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(3)
        operand1 = self.getValue[parameterMode[2]](instructionPointer + 1)
        operand2 = self.getValue[parameterMode[1]](instructionPointer + 2)

        resultLocation = int(self.program[instructionPointer + 3])
        if parameterMode[0] == '2':
            resultLocation += self.relativeBase

        result = operand1 + operand2

        self.debugMessage(f'ADD {operand1} {operand2}')
        self.debugMessage(f'STORE {result} {resultLocation}')

        self.program[resultLocation] = result
        return instructionPointer + 4

    def multiply(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(3)
        operand1 = self.getValue[parameterMode[2]](instructionPointer + 1)
        operand2 = self.getValue[parameterMode[1]](instructionPointer + 2)
        resultLocation = int(self.program[instructionPointer + 3])
        if parameterMode[0] == '2':
            resultLocation += self.relativeBase

        result = operand1 * operand2
        self.debugMessage(f'MULTIPLY {operand1} {operand2}')
        self.debugMessage(f'STORE {result} {resultLocation}')

        self.program[resultLocation] = result

        return instructionPointer + 4

    def getInput(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(1)
        if len(self.input) == 0:
            return instructionPointer

        location = int(self.program[instructionPointer + 1])
        if parameterMode[0] == '2':
            location += self.relativeBase

        inputValue = self.input.pop(0)

        self.debugMessage(f'INPUT {inputValue} ')
        self.debugMessage(f'STORE {inputValue} {location}')

        self.program[location] = inputValue

        return instructionPointer + 2

    def showOutput(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(1)
        outputValue = self.getValue[parameterMode[0]](instructionPointer + 1)

        self.debugMessage(f'OUTPUT {outputValue}')
        print(f'OUTPUT {outputValue}')
        #self.outputLocation.input.append(outputValue)
        #self.output = outputValue
        return instructionPointer + 2

    def jumpIfTrue(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(2)
        operand = self.getValue[parameterMode[1]](instructionPointer + 1)
        self.debugMessage(f'JMPTRUE: {operand}')
        if operand != 0:
            return self.getValue[parameterMode[0]](instructionPointer + 2)

        return instructionPointer + 3

    def jumpIfFalse(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(2)
        operand = self.getValue[parameterMode[1]](instructionPointer + 1)
        self.debugMessage(f'JMPFALSE: {operand}')
        if operand == 0:
            return self.getValue[parameterMode[0]](instructionPointer + 2)

        return instructionPointer + 3

    def lessThan(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(3)
        operand1 = self.getValue[parameterMode[2]](instructionPointer + 1)
        operand2 = self.getValue[parameterMode[1]](instructionPointer + 2)

        location = int(self.program[instructionPointer + 3])
        if parameterMode[0] == '2':
            location += self.relativeBase

        self.debugMessage(f'LESS: {operand1} {operand2}')
        if operand1 < operand2:
            self.debugMessage(f'STORE: 1 {location}')
            self.program[location] = 1
        else:
            self.debugMessage(f'STORE: 0 {location}')
            self.program[location] = 0

        return instructionPointer + 4

    def equals(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(3)
        operand1 = self.getValue[parameterMode[2]](instructionPointer + 1)
        operand2 = self.getValue[parameterMode[1]](instructionPointer + 2)

        location = int(self.program[instructionPointer + 3])
        if parameterMode[0] == '2':
            location += self.relativeBase

        self.debugMessage(f'EQUALS: {operand1} {operand2}')
        if operand1 == operand2:
            self.debugMessage(f'STORE: 1 {location}')
            self.program[location] = 1
        else:
            self.program[location] = 0

        return instructionPointer + 4

    def setRelativeBase(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(1)
        operand1 = self.getValue[parameterMode[0]](instructionPointer + 1)

        self.relativeBase += operand1
        self.debugMessage(f'NEW RELATIVE BASE: {self.relativeBase}')
        return instructionPointer + 2

    def tick(self):
        if self.running:
            opcodeString = str(self.program[self.instructionPointer])
            opcode = int(opcodeString[-2:])
            parameterMode = opcodeString[0:-2]

            if opcode != 99:
                try:
                    operation = self.ops[opcode]
                except KeyError:
                    raise Exception("Unknown Opcode")

                self.instructionPointer = operation(self.instructionPointer, parameterMode)
            else:
                self.running = False

    def __init__(self, program):
        self.debug = False
        self.relativeBase = 0
        self.instructionPointer = 0
        self.input = []

        self.program = program
        [ self.program.append(0) for r in range(10000)]

        self.outputLocation = None
        self.running = True
        self.ops = {
            1 : self.add,
            2 : self.multiply,
            3 : self.getInput,
            4 : self.showOutput,
            5 : self.jumpIfTrue,
            6 : self.jumpIfFalse,
            7 : self.lessThan,
            8 : self.equals,
            9 : self.setRelativeBase
        }

        self.getValue = {
            '0' : self.getPositionValue,
            '1' : self.getImmediateValue,
            '2' : self.getRelativeValue
        }

if __name__ == '__main__':
    with open('d:/projects/advent/9/9.txt', 'r') as fp:
        line = fp.readline().rstrip()

    #line = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99"
    #line = "1102,34915192,34915192,7,4,7,99,0"
    #line = "104,1125899906842624,99"
    program = line.split(',')

    p = IntCode(program)
    p.input.append(2)
    while p.running:
        p.tick()