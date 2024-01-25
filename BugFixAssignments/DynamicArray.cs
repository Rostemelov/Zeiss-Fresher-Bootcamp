using System;

public class DynamicArray<T>{
    private T[] array;
    private int capacity;
    private int count;

    public DynamicArray(int initialCapacity){
        if(initialCapacity <= 0){
            throw new ArgumentException("Initial capacity must be greater than 0");
        }

        array = new T[initialCapacity];
        capacity = initialCapacity;
        count = 0;
    }

    public int Count {
        get { return count; }
    }

    public void Add(int index, T item){
        if(index < 0){
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            return;
        }

        while(index>=capacity)
        {
             ResizeArray();
        }

        if(count == capacity){
            // If the array is full, double its capacity
            ResizeArray();
        }


        // Shift elements to make space for the new item
        for(int i = count - 1; i >= index; i--){
            array[i + 1] = array[i];
        }

        array[index] = item;
        count++;
    }

    public T this[int index] {
        get {
            if(index < 0 || index >= count){
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }

            return array[index];
        }
    }

    private void ResizeArray(){
        capacity *= 2;
        T[] newArray = new T[capacity];
        
        // Copy elements to the new array
        Array.Copy(array, newArray, count);

        array = newArray;
    }
}

public class Program{
    static void Main(){
        DynamicArray<int> numbers=new DynamicArray<int>(2);
        numbers.Add(0,100);
        numbers.Add(1,200);
        numbers.Add(2,300);
        numbers.Add(3,400);
        int value=numbers[2];
        System.Console.WriteLine($"Total Number Of Items in Array:{numbers.Count} ,Value:{value} at index:2");

        DynamicArray<string> stringItems=new DynamicArray<string>(2);
        stringItems.Add(0,"100");
        stringItems.Add(1,"200");
        stringItems.Add(2,"300");
        stringItems.Add(3,"400");
        string itemValue=stringItems[3];
        System.Console.WriteLine($"Total Number Of Items in Array:{stringItems.Count} , Value:{itemValue} at index:3");
    }
}
