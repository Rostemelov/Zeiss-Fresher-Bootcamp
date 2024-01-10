#-------------------------------------------------------------------------------    
class StartPredicates:
    def __init__(self, startlist):
        self.__startlist = startlist
    def check_string_starting_with(self, string):
        if string[0] in self.__startlist:
            return True
        else:
            return False
#-------------------------------------------------------------------------------
class EndPredicates:
    def __init__(self, endlist):
        self.__endlist = endlist
    def check_string_ending_with(self, string):
        if string[-1] in self.__endlist:
            return True
        else:
            return False
#-------------------------------------------------------------------------------
class Filter:
    def __init__(self, startlist, endlist):
        self.__answer_list = []
        self.__stprd = StartPredicates(startlist)
        self.__stpprd = EndPredicates(endlist)
    def filter(self, input_str, criteria_function):
        for string in input_str:
            if criteria_function == "start":
                if(self.__stprd.check_string_starting_with(string)):
                    self.__answer_list.append(string)
            elif criteria_function == "end":
                if(self.__stpprd.check_string_ending_with(string)):
                    self.__answer_list.append(string)
        return self.__answer_list
#-------------------------------------------------------------------------------
class Printer:
    def __init__(self):
        self.__content = []
    def setContent(self, l):
        self.__content = l
    def printToTerminal(self):
        for string in self.__content:
            print(string)
#-------------------------------------------------------------------------------
class Initiator:
    def __init__(self):
        self.__array_of_strings = ['Abhishek','abhinav','Deepanshu','Vishal','Manisha','Dadlani']
        self.__printer = Printer()
        self.__filt = Filter(['a','A','d','V','p'], ['a','A','d','V','p'])
        
    def doWork(self):
        result = self.__filt.filter(self.__array_of_strings, "start")
        self.__printer.setContent(result)
        self.__printer.printToTerminal()
        result = self.__filt.filter(self.__array_of_strings, "end")
        self.__printer.setContent(result)
        self.__printer.printToTerminal()
         
#-------------------------------------------------------------------------------
init1 = Initiator()     
init1.doWork()
