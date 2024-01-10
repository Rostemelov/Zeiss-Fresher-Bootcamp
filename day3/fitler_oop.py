#-------------------------------------------------------------------------------


#-------------------------------------------------------------------------------    
class StartWithContainer:
    def search(self, string):
        return string[0]
#-------------------------------------------------------------------------------
class EndWithContainer:
    def search(self, string):
        return string[-1]
#-------------------------------------------------------------------------------
class FilterController:
    def filter(self, input_str, toDo, liststr):
        answer_list = []
        for string in input_str:
            if toDo.search(string) in liststr:
                answer_list.append(string)
        return answer_list
#-------------------------------------------------------------------------------
class Printer:
    def __init__(self):
        self.__content = []
    def setContent(self, inputContent):
        self.__content = inputContent
    def printToTerminal(self):
        for string in self.__content:
            print(string)
#-------------------------------------------------------------------------------
class Initiator:
    def __init__(self):
        self.__array_of_strings = ['Abhishek','abhinav','Deepanshu','Vishal','Manisha','Dadlani']
        self.__printer = Printer()
        self.__filt = FilterController()
        self.__startsWithStrategy = StartWithContainer()
        self.__endsWithStrategy = EndWithContainer()
        
    def doWork(self):
        liststr =  ['a','A','d','V','p']
        result = self.__filt.filter(self.__array_of_strings, self.__startsWithStrategy, liststr)
        self.__printer.setContent(result)
        self.__printer.printToTerminal()
        result = self.__filt.filter(self.__array_of_strings, self.__endsWithStrategy, liststr)
        self.__printer.setContent(result)
        self.__printer.printToTerminal()
         
#-------------------------------------------------------------------------------
init1 = Initiator()     
init1.doWork()
