#-------------------------------------------------------------------------------    
class StartPredicates:
    def __init__(self, startlist):
        self.startlist = startlist
    def check_string_starting_with(self, string):
        if string[0] in self.startlist:
            return True
        else:
            return False
#-------------------------------------------------------------------------------
class EndPredicates:
    def __init__(self, endlist):
        self.endlist = endlist
    def check_string_ending_with(self, string):
        if string[-1] in self.endlist:
            return True
        else:
            return False
#-------------------------------------------------------------------------------
class Filter:
    def __init__(self, startlist, endlist):
        self.answer_list = []
        self.stprd = StartPredicates(startlist)
        self.stpprd = EndPredicates(endlist)
    def filter(self, input_str, criteria_function):
        for string in input_str:
            if criteria_function == "start":
                if(self.stprd.check_string_starting_with(string)):
                    self.answer_list.append(string)
            elif criteria_function == "end":
                if(self.stpprd.check_string_ending_with(string)):
                    self.answer_list.append(string)
        return self.answer_list
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
        self.printer = Printer()
        self.filt = Filter(['a','A','d','V','p'], ['a','A','d','V','p'])
        
    def dowork(self):
        result = self.filt.filter(self.array_of_strings, "start")
        self.printer.setContent(result)
        self.printer.printToTerminal()
        result = self.filt.filter(self.array_of_strings, "end")
        self.printer.setContent(result)
        self.printer.printToTerminal()
         
#-------------------------------------------------------------------------------
init1 = Initiator()     
init1.dowork()
