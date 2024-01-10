#-------------------------------------------------------------------------------    
class Filter:
    def filter(self, input_str, criteria_function):
        answer_list = []
        for string in input_str:
            if criteria_function == "start":
                s = self.check_string_starting_with(string)
                answer_list.append(s)
            elif criteria_function == "end":
                s = self.check_string_ending_with(string)
                answer_list.append(s)
        return answer_list
        
    def check_string_starting_with(self, char):
        predicate = lambda string : string[0] == char
        return predicate
    
    def check_string_ending_with(self, char):
        predicate = lambda string : string[-1] == char
        return predicate
#-------------------------------------------------------------------------------
class Printer:
    def printToTerminal(self, output_str_list):
        for string in output_str_list:
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
            result = self.filt.filter(self.array_of_strings, "start")
            self.printer.printToTerminal(result)
        for char in self.charay:
            result = self.filt.filter(self.array_of_strings, "end")
            self.printer.printToTerminal(result)
         
init1 = Initiator()     
init1.dowork()
