def getPositionValue(location):
    return int(program[int(program[location])])

def getImmediateValue(location):
    return int(program[location])

def add(instructionPointer, parameterMode):
    operand1 = getValue[parameterMode[2]](instructionPointer + 1)
    operand2 = getValue[parameterMode[1]](instructionPointer + 2)

    resultLocation = getImmediateValue(instructionPointer + 3)
    result = operand1 + operand2
    program[resultLocation] = result
    return instructionPointer + 4

def multiply(instructionPointer,parameterMode):
    operand1 = getValue[parameterMode[2]](instructionPointer + 1)
    operand2 = getValue[parameterMode[1]](instructionPointer + 2)
    resultLocation = getImmediateValue(instructionPointer + 3)

    result = operand1 * operand2
    program[resultLocation] = result

    return instructionPointer + 4

def getInput(instructionPointer, parameterMode, inputValue):           
    location = getImmediateValue(instructionPointer + 1)
    program[location] = inputValue

    return instructionPointer + 2

def showOutput(instructionPointer, parameterMode):
    location = getImmediateValue(instructionPointer + 1)
    outputValue = program[location]

    print(f'Output: {outputValue}')
    return instructionPointer + 2

def jumpIfTrue(instructionPointer, parameterMode):
    operand = getValue[parameterMode[1]](instructionPointer + 1)
    if operand != 0:
        return getValue[parameterMode[0]](instructionPointer + 2)

    return instructionPointer + 3

def jumpIfFalse(instructionPointer, parameterMode):
    operand = getValue[parameterMode[1]](instructionPointer + 1)
    if operand == 0:
        return getValue[parameterMode[0]](instructionPointer + 2)

    return instructionPointer + 3

def lessThan(instructionPointer, parameterMode):
    operand1 = getValue[parameterMode[2]](instructionPointer + 1)
    operand2 = getValue[parameterMode[1]](instructionPointer + 2)
    location = getImmediateValue(instructionPointer + 3)
    if operand1 < operand2:
        program[location] = 1
    else:
        program[location] = 0

    return instructionPointer + 4

def equals(instructionPointer, parameterMode):
    operand1 = getValue[parameterMode[2]](instructionPointer + 1)
    operand2 = getValue[parameterMode[1]](instructionPointer + 2)
    location = getImmediateValue(instructionPointer + 3)

    if operand1 == operand2:    
        program[location] = 1
    else:
        program[location] = 0

    return instructionPointer + 4

def runProgram(program, inputValue):
    instructionPointer = 0
    opcodeString = program[instructionPointer]
    opcode = int(opcodeString[-2:])
    parameterMode = opcodeString[0:-2]

    while opcode != 99:
        if (opcode == 1):
            parameterMode = parameterMode.zfill(3)
            instructionPointer = add(instructionPointer, parameterMode)
 
        elif (opcode == 2):
            parameterMode = parameterMode.zfill(3)
            instructionPointer = multiply(instructionPointer, parameterMode)
 
        elif (opcode == 3):
            parameterMode = parameterMode.zfill(1)
            instructionPointer = getInput(instructionPointer, parameterMode, inputValue)
 
        elif (opcode == 4):
            parameterMode = parameterMode.zfill(1)            
            instructionPointer = showOutput(instructionPointer, parameterMode)
 
        elif (opcode == 5):
            parameterMode = parameterMode.zfill(2)
            instructionPointer = jumpIfTrue(instructionPointer, parameterMode)
 
        elif (opcode == 6):
            parameterMode = parameterMode.zfill(2)
            instructionPointer = jumpIfFalse(instructionPointer, parameterMode)
 
        elif (opcode == 7):
            parameterMode = parameterMode.zfill(3)
            instructionPointer = lessThan(instructionPointer, parameterMode)
 
        elif (opcode == 8):
            parameterMode = parameterMode.zfill(3)
            instructionPointer = equals(instructionPointer, parameterMode)
 
        else:
            print('Unknown Opcode')
        
        opcodeString = str(program[instructionPointer])
        opcode = int(opcodeString[-2:])
        parameterMode = opcodeString[0:-2]
   
    return getImmediateValue(0)
 
with open('5.txt', 'r') as fp:
    line = fp.readline()
#line = "3,9,8,9,10,9,4,9,99,-1,8"
#line = "3,9,7,9,10,9,4,9,99,-1,8"
#line = "3,3,1108,-1,8,3,4,3,99"
#line = "3,3,1107,-1,8,3,4,3,99"
#line = "3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9"
#line = "3,3,1105,-1,9,1101,0,0,12,4,12,99,1"
getValue = {
    '0' : getPositionValue,
    '1' : getImmediateValue
}
 
program = line.split(',')
 
runProgram(program, 5)