#-------------------------------------------------------------------------------    
class Filter:
    def filter(self, input_str, criteria_function, char):
        answer_list = []
        for string in input_str:
            if criteria_function == "start":
                if(self.check_string_starting_with(string, char)):
                    answer_list.append(string)
            elif criteria_function == "end":
                if(self.check_string_ending_with(string, char)):
                    answer_list.append(string)
        return answer_list
        
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
            result = self.filt.filter(self.array_of_strings, "start", char)
            self.printer.printToTerminal(result)
        for char in self.charay:
            result = self.filt.filter(self.array_of_strings, "end", char)
            self.printer.printToTerminal(result)
         
init1 = Initiator()     
init1.dowork()
