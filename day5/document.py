from abc import ABC, abstractmethod

class Iconverter:
    def convert(Header head):
        print("Header Tag")
    def convert(Footer foot):
        print("Footer Tag")
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
    @abstractmethod
    def save(self):
        pass
    
class Footer(DocumentPart):
    def paint(self):
        pass
    @abstractmethod
    def save(self):
        pass
    
class Hypertext(DocumentPart):
    def paint(self):
        pass
    @abstractmethod
    def save(self):
        pass
    
class Paragraph(DocumentPart):
    def paint(self):
        pass
    @abstractmethod
    def save(self):
        pass