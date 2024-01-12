from abc import ABC, abstractmethod

class Iconverter:
    def convertHeader(Header head):
        print("Header Tag")
    def convertFooter(Footer foot):
        print("Footer Tag")
    def convertHypertext(Header head):
        print("Hyper Tag")
    def convert(Header head):
        print("Hyper Tag")



class DocumentPart:
    name = ""
    position = ""
    @abstractmethod
    def paint(self):
        pass
    @abstractmethod
    def save(self):
        pass

class Header(DocumentPart):
    def paint(self):
        pass
    def save(self):
        pass
    
class Footer(DocumentPart):
    def paint(self):
        pass
    def save(self):
        pass
    
class Hypertext(DocumentPart):
    def paint(self):
        pass
    def save(self):
        pass
    
class Paragraph(DocumentPart):
    def paint(self):
        pass
    def save(self):
        pass


class WordDocument:
    def __init__(self):
        parts = []
