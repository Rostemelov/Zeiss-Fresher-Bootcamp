#-------------------------------------------------------------------------------    
class Filter:
    def __init__(self):
        self.answer_list = []
    def filter(self, input_str, criteria_function, char):
        for string in input_str:
            if criteria_function == "start":
                if(self.check_string_starting_with(string, char)):
                    self.answer_list.append(string)
            elif criteria_function == "end":
                if(self.check_string_ending_with(string, char)):
                    self.answer_list.append(string)
        return self.answer_list
        
    def check_string_starting_with(self, string, char):
        if string[0] == char:
            return True
        else:
            return False
    
    def check_string_ending_with(self, string, char):
        if string[-1] == char:
            return True
        else:
            return False
#-------------------------------------------------------------------------------
class Printer:
    def __init__(self):
        self.content = []
    def setContent(self, l):
        self.content = l
    def printToTerminal(self):
        for string in self.content:
            print(string)
#-------------------------------------------------------------------------------
class Initiator:
    def __init__(self):
        self.array_of_strings = ['Abhishek','abhinav','Deepanshu','Vishal','Manisha','Dadlani']
        self.charay = ['a','A','d','V','p']
        self.printer = Printer()
        self.filt = Filter()
        
    def dowork(self):
        for char in self.charay:
            result = self.filt.filter(self.array_of_strings, "start", char)
        self.printer.setContent(result)
        self.printer.printToTerminal()
        for char in self.charay:
            result = self.filt.filter(self.array_of_strings, "end", char)
        self.printer.setContent(result)
        self.printer.printToTerminal()
         
init1 = Initiator()     
init1.dowork()
