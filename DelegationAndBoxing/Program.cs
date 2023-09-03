using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegationAndBoxing
{
    public delegate void StringDelegate(string str);//it's a pointer that points to a function
    //Delegates are useful to pass a method call to another method
    internal class Program
    {
        static void Main(string[] args)
        {
            StringDelegate strDelegate = ToUpperCase;

            strDelegate("hey bro");
            strDelegate.Invoke("what's up bro?");

            strDelegate = ToLowerCase;
            strDelegate("CHANGE TO LOWER CASE");
            strDelegate.Invoke("CHANGE TO LOWER CASE AGAIN");

            WriteOutput("FROM METHOD HELL YEAH",strDelegate);

            //Boxing and Unboxing

            int x = 5; //value type
            //after leaving the main method the x variable's value is gone

            object xObject = x; //reference type
            //it's called boxing because in order to put x onto the heap memory you have to wrap it
            //20 times slower than normal assignment

            int xUnboxed = (int)xObject;//back to Value type
            //This is called unboxing
            //4 times slower

            var arrayOfInts = Enumerable.Range(69,420).ToArray();//by default an array is a reference type

            var arrayList = new ArrayList(arrayOfInts);//This is a form of boxing because if you
            //step into the arraylist class you can see it is made up of an object array

            var list = new List<int>(arrayOfInts);
            //making this a generic list solves that boxing and unboxing problem
            //List<T> do not box items.
        }

        static void ToUpperCase(string text)
        {
            Console.WriteLine(text.ToUpper());
        }
        static void ToLowerCase(string text)
        {
            Console.WriteLine(text.ToLower());
        }
        static void WriteOutput(string text, StringDelegate strDelegate)
        {
            Console.WriteLine(text);

            strDelegate("Delegated: "+text);
        }

    }
}
