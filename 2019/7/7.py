from IntCode import IntCode

def permutation(lst):
   # If lst is empty then there are no permutations
    if len(lst) == 0:
        return []

    # If there is only one element in lst then, only
    # one permuatation is possible
    if len(lst) == 1:
        return [lst]

    # Find the permutations for lst if there are
    # more than 1 characters

    l = [] # empty list that will store current permutation

    # Iterate the input(lst) and calculate the permutation
    for i in range(len(lst)):
       m = lst[i]

       # Extract lst[i] or m from the list.  remLst is
       # remaining list
       remLst = lst[:i] + lst[i+1:]

       # Generating all permutations where m is first
       # element
       for p in permutation(remLst):
           l.append([m] + p)
    return l



with open('7.txt', 'r') as fp:
    line = fp.readline()

#line = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0"
#line ="3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0"
#line = "3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0"

program = line.split(',')

#input = [4,3,2,1,0]
#input = [0,1,2,3,4]
#input = [1,0,4,3,2]
maxThrusterOutput = 0

for input in permutation([0,1,2,3,4]):
    index = 0
    thrusterOutput = 0
    for i in input:
        c = IntCode()
        programInput =  [input[index], thrusterOutput]
        thrusterOutput = c.runProgram(program, programInput)
        index += 1

    #print(input)
    #print(thrusterOutput)
    if thrusterOutput > maxThrusterOutput:
        maxThrusterOutput = thrusterOutput
        maxInput = input

print(maxThrusterOutput)
print(maxInput)