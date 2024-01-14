def filter(strList, predicateFn):
    result = []
    for string in strList:
        if predicateFn(string):
            result.append(string)
    return result
    
def printToScreen(listToBePrinted):
    for item in listToBePrinted:
        print(item)

def checkStringStartsWith(char):
    result = lambda string : string[0].lower() == char.lower()
    return result
    
def checkStringEndsWith(character):
    def checkString(string):
        return string[-1].lower() == character.lower()
    return checkString
    
    
StringList = ["Carl", "Zeiss", "Ajay", "Air", "Car"]
FilteredList1 = filter(StringList, checkStringStartsWith("a"))

print("Strings starting with 'A': ")
printToScreen(FilteredList1)

FilteredList2 = filter(StringList, checkStringEndsWith("r"))

print("Strings ending with 'R': ")
printToScreen(FilteredList2)