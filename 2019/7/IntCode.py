class IntCode:
    def getPositionValue(self, location):
        return int(self.program[int(self.program[location])])

    def getImmediateValue(self, location):
        return int(self.program[location])

    def add(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(3)
        operand1 = self.getValue[parameterMode[2]](instructionPointer + 1)
        operand2 = self.getValue[parameterMode[1]](instructionPointer + 2)

        resultLocation = self.getImmediateValue(instructionPointer + 3)
        result = operand1 + operand2
        self.program[resultLocation] = result
        return instructionPointer + 4

    def multiply(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(3)
        operand1 = self.getValue[parameterMode[2]](instructionPointer + 1)
        operand2 = self.getValue[parameterMode[1]](instructionPointer + 2)
        resultLocation = self.getImmediateValue(instructionPointer + 3)

        result = operand1 * operand2
        self.program[resultLocation] = result

        return instructionPointer + 4

    def getInput(self, instructionPointer, parameterMode):
        if len(self.input) == 0:
            return instructionPointer

        location = self.getImmediateValue(instructionPointer + 1)
        inputValue = self.input.pop(0)
        self.program[location] = inputValue

        return instructionPointer + 2

    def showOutput(self, instructionPointer, parameterMode):
        location = self.getImmediateValue(instructionPointer + 1)
        outputValue = self.program[location]
        self.outputLocation.input.append(outputValue)
        #self.output = outputValue
        #print(f'Output: {outputValue}')
        return instructionPointer + 2

    def jumpIfTrue(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(2)
        operand = self.getValue[parameterMode[1]](instructionPointer + 1)
        if operand != 0:
            return self.getValue[parameterMode[0]](instructionPointer + 2)

        return instructionPointer + 3

    def jumpIfFalse(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(2)
        operand = self.getValue[parameterMode[1]](instructionPointer + 1)
        if operand == 0:
            return self.getValue[parameterMode[0]](instructionPointer + 2)

        return instructionPointer + 3

    def lessThan(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(3)
        operand1 = self.getValue[parameterMode[2]](instructionPointer + 1)
        operand2 = self.getValue[parameterMode[1]](instructionPointer + 2)
        location = self.getImmediateValue(instructionPointer + 3)
        if operand1 < operand2:
            self.program[location] = 1
        else:
            self.program[location] = 0

        return instructionPointer + 4

    def equals(self, instructionPointer, parameterMode):
        parameterMode = parameterMode.zfill(3)
        operand1 = self.getValue[parameterMode[2]](instructionPointer + 1)
        operand2 = self.getValue[parameterMode[1]](instructionPointer + 2)
        location = self.getImmediateValue(instructionPointer + 3)

        if operand1 == operand2:
            self.program[location] = 1
        else:
            self.program[location] = 0

        return instructionPointer + 4

    def tick(self):
        if self.running:
            opcodeString = self.program[self.instructionPointer].rstrip()
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
        self.instructionPointer = 0
        self.input = []
        self.program = program
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
            8 : self.equals
        }

        self.getValue = {
            '0' : self.getPositionValue,
            '1' : self.getImmediateValue
        }