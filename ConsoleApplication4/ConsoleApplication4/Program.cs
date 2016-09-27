/*
* DATA STRUCTURES GROUP PROGRAM
* Section: 1
* Group:   13
* Authors:
*          Dallin      Smith
*          Oliver      Morgan
*          Remington   Steele
*          Matt        Brown
*
* Description:
*          This program utilizes different data structures to perform simple tasks with those data structures.
 *         The purpose is to showcase the utility for each structure and to help users understand the following aspects:
 *              -Add to data structure
 *              -Add a massive group to data structure
 *              -Display a data structure
 *              -Delete from data structure
 *              -Search for an element within a data structure
 *              -Clear the data structure
 *         The program utilizes the following data structures:
 *              -Dictionary
 *              -Stack
 *              -Queue
 *              -LinkedList
*
*
* Above and Beyond:
*     ~*~*~Expanded Scope for Stack, Dictionary, and Queue storage (exit and return; they are still saved)
 *    ~*~*~Adds menu item for LinkedList
 *    *~*~*User can perform all 7 tasks with LinkedList
 *    ~*~*~Exception handling for all user input
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dataStructuresGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runMainProgram = true;
            bool repeat = true; //this will be used for the try-catch to ensure user input is valid; also used to return to main menu
            while (runMainProgram)
            {
                int iMenu = 0;//This will show the user's choice for the menu(s)
                //CREATE NEW Stack, Dictionary, Queue, Linked List
                Stack<string> myStack = new Stack<string>();                           //Instantiates new stack, called myStack
                Dictionary<String, int> myDictionary = new Dictionary<string, int>();  //Instantiates new dictionary, called dictionary
                Queue<String> myQueue = new Queue<string>();                           //Instantiates new queue, called myQueue
                LinkedList<string> myLinkedList = new LinkedList<string>();            //Instantiates new linkedlist, called myLinkedList

                while (repeat) //This while loop requests user input for which element of the menu he/she wants!
                {
                    Console.WriteLine("\n1. Stack  \n2. Queue  \n3. Dictionary  \n4. LinkedList \n5. Exit\n");
                    String sMenuOne = Console.ReadLine();
                    try //check to see if user input is a valid integer
                    {
                        iMenu = Convert.ToInt32(sMenuOne);
                        if (iMenu > 0 && iMenu < 6)//check to make sure input is positive
                        {
                            repeat = false;
                        }
                        else//if not positive, prompt user to enter a non-negative value
                        {
                            Console.WriteLine("Please enter a number between 1 and 4.\n\n");
                        }
                    }
                    catch (FormatException e) //won't allow user to input non-numeric values
                    {
                        Console.WriteLine("Please enter a valid number.\n]n");
                    }
                    catch (OverflowException e) //won't allow user to input numbers larger than int32
                    {
                        Console.WriteLine("Please enter a valid digit smaller than 2,147,483,647.\n\n");
                    }
                    //MAIN MENU CHOICE 1
                    if (iMenu == 1)
                    {
                        //STACK Menu
                        bool repeatStack = true;
                        int iStack = 0;
                        while (repeatStack) //This while loop requests user input for which element of the menu he/she wants!
                        {
                            Console.WriteLine("\n1. Add one item to Stack \n2. Add Huge List of Items to Stack \n3. Display Stack \n4. Delete from Stack \n5. Clear Stack \n6. Search Stack \n7. Return to Main Menu\n");
                            String sStackMenu = Console.ReadLine();
                            try //check to see if user input is a valid integer
                            {
                                iStack = Convert.ToInt32(sStackMenu);
                                if (iStack > 0 && iStack < 8)//check to make sure input is positive
                                {
                                    repeatStack = false;
                                }
                                else//if not positive, prompt user to enter a non-negative value
                                {
                                    Console.WriteLine("Please enter a number between 1 and 7.\n\n");
                                }
                            }
                            catch (FormatException e) //won't allow user to input non-numeric values
                            {
                                Console.WriteLine("Please enter a valid number.\n\n");
                            }
                            catch (OverflowException e) //won't allow user to input numbers larger than int32
                            {
                                Console.WriteLine("Please enter a valid digit smaller than 2,147,483,647.\n\n");
                            }

                            //1. Add one item to myStack
                            if (iStack == 1)
                            {
                                //prompts the user to enter a string and then inserts the input into myStack.
                                Console.WriteLine("\nEnter a string to insert into the data structure.\n");
                                string dData = Console.ReadLine();
                                myStack.Push(dData);
                                Console.WriteLine(dData + " was added to the Stack!\n\n");
                                repeatStack = true; //Return to Stack menu
                            }
                            //2. Add Huge List (2000) of Items to myStack
                            else if (iStack == 2)
                            {
                                myStack.Clear();
                                for (int i = 2000; i >= 1; i--)
                                {
                                    myStack.Push("New Entry " + i);
                                }
                                repeatStack = true; //Return to Stack menu
                            }
                            //3. Display myStack
                            else if (iStack == 3)
                            {
                                foreach (String s in myStack)
                                {
                                    Console.WriteLine(s);
                                }
                                repeatStack = true; //Return to Stack menu
                            }
                            //4. Delete From Stack
                            //NOTE: THIS DOES NOT (YET?) FACTOR IN UPPER/LOWER CASE TEXT
                            else if (iStack == 4)
                            {
                                Console.Write("\nWhich item would you like to delete?\n");
                                String sDelete = Console.ReadLine();//
                                Stack<String> tempStack = new Stack<String>();//creates new temporary Stack, tempStack
                                String sTemp, sReverse;
                                bool bDeleted = false;//boolean will be used to indicate whether searched element was deleted or not
                                if (myStack.Count() < 1)//If the Stack is empty, tell the user that the Stack is empty; return to Stack menu.
                                {
                                    Console.WriteLine("Oops! The Stack is empty!\n\n");
                                    repeatStack = true; //Return to Stack menu
                                }
                                while (myStack.Count() > 0)//As long as the Stack has elements, look for sDelete
                                {
                                    sTemp = myStack.Peek();//see what element is at the top of the stack, assign that to temp string, sTemp
                                    tempStack.Push(sTemp);//push sTemp onto the temporary stack, tempStack
                                    myStack.Pop();//delete the top element from myStack
                                    if (sDelete == sTemp)
                                    {
                                        bDeleted = true;
                                        tempStack.Pop();
                                        break;//stop the while loop from removing elements from myStack
                                    }
                                }
                                if (bDeleted)//if we find a match alert the user
                                {
                                    Console.WriteLine(sDelete + " was removed from the Stack.\n\n");
                                    bDeleted = false;
                                }
                                else//We couldn't find the element; alert user
                                {
                                    Console.WriteLine("System was unable to locate " + sDelete + ". :(\n\n");
                                }
                                while (tempStack.Count() > 0)//Replaces any items from the tempStack to myStack
                                {
                                    sReverse = tempStack.Peek();
                                    myStack.Push(sReverse);
                                    tempStack.Pop();
                                }
                                repeatStack = true; //Return to Stack menu
                            }

                            //5. Clear myStack
                            else if (iStack == 5)
                            {
                                myStack.Clear();
                                repeatStack = true; //Return to Stack menu
                            }

                            //6. Search myStack
                            else if (iStack == 6)
                            {
                                Console.Write("\nPlease enter element that you want to find: \n");
                                String sFind = Console.ReadLine();//
                                Stack<String> tempStack = new Stack<String>();//creates new temporary Stack, tempStack
                                String sTemp, sReverse;
                                bool bFound = false;//boolean will be used to indicate whether searched element was found or not
                                if (myStack.Count() < 1)//If the Stack is empty, tell the user that the Stack is empty; return to Stack menu.
                                {
                                    Console.WriteLine("Oops! The Stack is empty!\n\n");
                                    repeatStack = true; //Return to Stack menu
                                }
                                while (myStack.Count() > 0)//As long as the Stack has elements, look for sFind
                                {
                                    sTemp = myStack.Peek();//see what element is at the top of the stack, assign that to temp string, sTemp
                                    tempStack.Push(sTemp);//push sTemp onto the temporary stack, tempStack
                                    myStack.Pop();//remove the top item from myStack

                                    if (sFind == sTemp)
                                    {
                                        bFound = true;
                                        break;//stop the while loop from removing elements from myStack
                                    }
                                }
                                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();//STOPWATCH
                                sw.Start();
                                if (bFound)//if we find a match alert the user
                                {
                                    Console.WriteLine(sFind + " is in the Stack!\n");
                                    TimeSpan ts = sw.Elapsed;
                                    Console.Write("Time Elapsed: " + ts + "\n\n");
                                }
                                else//We couldn't find the element; alert user
                                {
                                    Console.WriteLine(sFind + " is not in the Stack... :(\n\n");
                                }
                                while (tempStack.Count() > 0)//Replaces any items from the tempStack to myStack
                                {
                                    sReverse = tempStack.Peek();
                                    myStack.Push(sReverse);
                                    tempStack.Pop();
                                }
                                bFound = false;
                                repeatStack = true; //Return to Stack menu
                            }
                            //7. Return to Main Menu
                            else if (iStack == 7)
                            {
                                repeat = true;
                            }
                        }
                    }
                    //MAIN MENU CHOICE 2
                    else if (iMenu == 2)
                    {
                        //QUEUE Menu
                        bool repeatQueue = true;
                        int iQueue = 0;
                        while (repeatQueue) //This while loop requests user input for which element of the menu he/she wants!
                        {
                            Console.WriteLine("\n1. Add one item to Queue \n2. Add Huge List of Items to Queue \n3. Display Queue \n4. Delete from Queue \n5. Clear Queue \n6. Search Queue \n7. Return to Main Menu\n");
                            String sQueueMenu = Console.ReadLine();
                            try //check to see if user input is a valid integer
                            {
                                iQueue = Convert.ToInt32(sQueueMenu);
                                if (iQueue > 0 && iQueue < 8)//check to make sure input is positive
                                {
                                    repeatQueue = false;
                                }
                                else//if not positive, prompt user to enter a non-negative value
                                {
                                    Console.WriteLine("Please enter a number between 1 and 7.\n\n");
                                }
                            }
                            catch (FormatException e) //won't allow user to input non-numeric values
                            {
                                Console.WriteLine("Please enter a valid number.\n\n");
                            }
                            catch (OverflowException e) //won't allow user to input numbers larger than int32
                            {
                                Console.WriteLine("Please enter a valid digit smaller than 2,147,483,647.\n\n");
                            }
                            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                            //myQueue has been instantiated at the top of this program
                            if (iQueue == 1)
                            {
                                Console.WriteLine("\nEnter a string to insert into the data structure.\n");
                                String qData = Console.ReadLine();
                                myQueue.Enqueue(qData);
                                Console.WriteLine(qData + " was added to the Queue!\n\n");
                                repeatQueue = true;//Tells the program to show the Queue menu again
                            }
                            else if (iQueue == 2)
                            {
                                myQueue.Clear();
                                for (int iCount = 0; iCount < 2000; iCount++)
                                {
                                    myQueue.Enqueue("New Entry " + (iCount + 1));
                                }
                                repeatQueue = true;//Tells the program to show the Queue menu again
                            }
                            //outputs the data
                            else if (iQueue == 3)
                            {
                                if (myQueue.Count < 1)
                                {
                                    Console.WriteLine("Oops. The Queue is empty!.\n\n");
                                    repeatQueue = true;//Tells the program to show the Queue menu again

                                }
                                foreach (var s in myQueue)
                                {
                                    Console.WriteLine(s);
                                }
                                repeatQueue = true;//Tells the program to show the Queue menu again
                            }
                            //4. Delete an item from myQueue
                            else if (iQueue == 4)
                            {
                                Queue<string> Queue2 = new Queue<string>();
                                bool Delete = false;
                                String deleteItem;
                                Console.Write("\nWhich item would you like to delete?\n");
                                deleteItem = Console.ReadLine();
                                //lets user know if data is in the queue or not
                                if (myQueue.Count < 1)
                                {
                                    Console.WriteLine("Oops. The Queue is empty!.\n\n");
                                    repeatQueue = true;
                                }
                                else if (myQueue.Count > 0)
                                {
                                    int size = myQueue.Count;
                                    for (int count = 0; count < size; count++)
                                    {
                                        //deletes if delete request matches queue content
                                        if (myQueue.Peek() == deleteItem)
                                        {
                                            myQueue.Dequeue();
                                            Delete = true;
                                        }
                                        else
                                        {
                                            Queue2.Enqueue(myQueue.Dequeue());
                                        }
                                    }
                                }

                                //lets user know whether or not item was deleted
                                if (Delete == false)
                                {
                                    Console.WriteLine("System was unable to locate " + deleteItem + "...\n\n");
                                }
                                else if (Delete == true)
                                {
                                    Console.WriteLine(deleteItem + " was removed from the stack!\n\n");
                                }


                                myQueue = Queue2;
                                repeatQueue = true;//Tells the program to show the Queue menu again
                            }
                            //5. Clear myQueue completely
                            else if (iQueue == 5)
                            {
                                myQueue.Clear();
                                repeatQueue = true;//Tells the program to show the Queue menu again
                            }
                            //6. Search myQueue
                            //ADD A TIMER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!@#$!@#$!@#$!@#$
                            else if (iQueue == 6)
                            {
                                Console.Write("\nPlease enter element that you want to find: \n");
                                String search = (Console.ReadLine());

                                if (myQueue.Count < 1)
                                {
                                    Console.WriteLine("Oops. The Queue is empty!.\n\n");

                                    repeatQueue = true;//Tells the program to show the Queue menu again
                                }

                                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                                sw.Start();

                                if (myQueue.Contains(search))
                                {
                                    Console.WriteLine(search + " is in the stack!\n");
                                    TimeSpan ts = sw.Elapsed;
                                    Console.WriteLine("Time Elapsed: " + ts + "\n\n");
                                }
                                else
                                {
                                    Console.WriteLine(search + " is not in the stack... \n\n");
                                    repeatQueue = true;//Tells the program to show the Queue menu again
                                }



                            }

                            //exits back out to the main menu
                            else if (iQueue == 7)
                            {
                                repeat = true;//Tells the program to show the Main menu again
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                        }
                    }
                    //MAIN MENU CHOICE 3
                    else if (iMenu == 3)
                    {
                        //DICTIONARY Menu
                        bool repeatDictionary = true;
                        int iDictionary = 0;
                        while (repeatDictionary) //This while loop requests user input for which element of the menu he/she wants!
                        {
                            Console.WriteLine("\n1. Add one item to Dictionary \n2. Add Huge List of Items to Dictionary \n3. Display Dictionary \n4. Delete from Dictionary \n5. Clear Dictionary \n6. Search Dictionary \n7. Return to Main Menu\n");
                            String sQueueMenu = Console.ReadLine();
                            try //check to see if user input is a valid integer
                            {
                                iDictionary = Convert.ToInt32(sQueueMenu);
                                if (iDictionary > 0 && iDictionary < 8)//check to make sure input is positive
                                {
                                    repeatDictionary = false;
                                }
                                else//if not positive, prompt user to enter a non-negative value
                                {
                                    Console.WriteLine("Please enter a number between 1 and 7.\n\n");
                                }
                            }
                            catch (FormatException e) //won't allow user to input non-numeric values
                            {
                                Console.WriteLine("Please enter a valid number.\n\n");
                            }
                            catch (OverflowException e) //won't allow user to input numbers larger than int32
                            {
                                Console.WriteLine("Please enter a valid digit smaller than 2,147,483,647.\n\n");
                            }
                            ///////////////////////////////////////////////////////////////////
                            //int dMenu = 2;
                            //1. Add one item to Dictionary
                            if (iDictionary == 1)
                            {
                                //prompts the user to enter a string and then inserts the input into the data structure.
                                Console.WriteLine("\nEnter a string to insert into the data structure.\n");
                                string dData = Console.ReadLine();
                                myDictionary.Add(dData, myDictionary.Count + 1);
                                Console.WriteLine(dData + " was added to the Dictionary!\n\n");
                                repeatDictionary = true;//takes user back to main menu
                            }
                            //2. Add Huge List of Items to Dictionary
                            else if (iDictionary == 2)
                            {
                                myDictionary.Clear();
                                for (int i = 1; i <= 2000; i++)
                                {
                                    myDictionary.Add("New Entry " + i, i);
                                }
                                repeatDictionary = true; //takes user back to main menu
                            }
                            //3. Display Dictionary
                            else if (iDictionary == 3)
                            {
                                foreach (KeyValuePair<string, int> pair in myDictionary)
                                {
                                    Console.WriteLine(pair.Key + "\t\t" + pair.Value);
                                }
                                repeatDictionary = true; //takes user back to main menu
                            }
                            //4. Delete from Dictionary
                            else if (iDictionary == 4)
                            {
                                //prompt for which item to delete from the structure. Handle any errors and inform the user.
                                Console.WriteLine("\nWhich item would you like to delete?\n");
                                string index = Console.ReadLine();
                                if (myDictionary.ContainsKey(index))
                                {
                                    myDictionary.Remove(index);
                                    Console.Write(index + " was deleted from the Dictionary!\n\n");
                                }
                                else
                                {
                                    Console.WriteLine("\nUnable to locate " + index + ".\n\n");
                                }
                                repeatDictionary = true;//takes user back to main menu
                            }
                            //5. Clear Dictionary
                            else if (iDictionary == 5)
                            {
                                //wipe out the contents of the data structure
                                myDictionary.Clear();
                                repeatDictionary = true;//takes user back to main menu
                            }
                            //6. Search Dictionary
                            else if (iDictionary == 6)
                            {
                                /*Search for an item in the data structure and return if it was found or not found 
                                and how long it took to search.*/
                                Console.WriteLine("\nEnter an item you would like to search for:\n");
                                string itemSearch = Console.ReadLine();
                                //You can create a StopWatch object using code like so:
                                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                                sw.Start();
                                if (myDictionary.ContainsKey(itemSearch))
                                {
                                    Console.WriteLine("\nValue for " + itemSearch + " is " + myDictionary[itemSearch] + "\n");
                                    sw.Stop();
                                    // Get the elapsed time as a TimeSpan value.
                                    TimeSpan ts = sw.Elapsed;
                                    Console.WriteLine("Time Elapsed: " + ts + "\n\n");
                                }
                                else
                                {
                                    Console.WriteLine("\nItem not found.\n\n");
                                }
                                repeatDictionary = true;//takes user back to main menu
                            }
                            //7. Return to Main Menu
                            else if (iDictionary == 7)
                            {
                                repeat = true;//takes user back to main menu
                            }
                        }

                    }
                    //MAIN MENU CHOICE 4: LinkedList

                    else if (iMenu == 4)
                    {

                        bool repeatLinkedList = true;

                        int iLinkedList = 0;

                        while (repeatLinkedList) //This while loop requests user input for which element of the menu he/she wants!
                        {

                            Console.WriteLine("\n1. Add one item to LinkedList \n2. Add Huge List of Items to LinkedList \n3. Display LinkedList \n4. Delete from LinkedList \n5. Clear LinkedList \n6. Search LinkedList \n7. Return to Main Menu\n");

                            String sLinkedListMenu = Console.ReadLine();

                            try //check to see if user input is a valid integer
                            {

                                iLinkedList = Convert.ToInt32(sLinkedListMenu);

                                if (iLinkedList > 0 && iLinkedList < 8)//check to make sure input is positive
                                {

                                    repeatLinkedList = false;

                                }

                                else//if not positive, prompt user to enter a non-negative value
                                {

                                    Console.WriteLine("Please enter a number between 1 and 7.\n\n");

                                }

                            }

                            catch (FormatException e) //won't allow user to input non-numeric values
                            {

                                Console.WriteLine("Please enter a valid number.\n\n");

                            }

                            catch (OverflowException e) //won't allow user to input numbers larger than int32
                            {

                                Console.WriteLine("Please enter a valid digit smaller than 2,147,483,647.\n\n");

                            }





                            //1. Add one item to LinkedList

                            if (iLinkedList == 1)
                            {

                                //prompts the user to enter a string and then inserts the input into the data structure.

                                Console.WriteLine("\nEnter a string to insert into the data structure.\n");

                                string dData = Console.ReadLine();

                                myLinkedList.AddFirst(dData);

                                repeatLinkedList = true;//takes user back to main menu

                            }



                            //2. Add huge list of items to LinkedList/////////////////////\\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/

                            else if (iLinkedList == 2)
                            {
                                myLinkedList.Clear();
                                for (int iCount = 2000; iCount >= 1; iCount--)
                                {

                                    myLinkedList.AddFirst("New Entry " + (iCount));

                                }

                                repeatLinkedList = true;//takes user back to main menu

                            }





                            //3. Display LinkedList

                            else if (iLinkedList == 3)
                            {

                                if (myLinkedList.Contains(null))
                                {

                                    Console.WriteLine("Oops. It looks like The LinkedList is empty!\n\n");

                                }



                                else
                                {

                                    foreach (var vLinkedList in myLinkedList)
                                    {

                                        Console.WriteLine(vLinkedList);

                                    }

                                }

                                repeatLinkedList = true;//takes user back to main menu

                            }





                            //4. Delete from LinkedList

                            else if (iLinkedList == 4)
                            {

                                //prompt for which item to delete from the structure. Handle any errors and inform the user.

                                Console.WriteLine("\nWhich item would you like to delete?\n");

                                string deleteLinkedList = Console.ReadLine();



                                if (myLinkedList.Contains(deleteLinkedList))//myLinkedList.Find(deleteLinkedList))
                                {

                                    LinkedListNode<string> deleteNode = myLinkedList.Find(deleteLinkedList);//creates new LinkedListNode "deleteNode" and assigns it the value of deleteLinkedList

                                    myLinkedList.Remove(deleteNode);//removes the element from myLinkedList that has LinkedListNode "deleteNode"; see dotnetperls for info

                                    Console.WriteLine(deleteLinkedList + " has been removed from the LinkedList.\n\n");

                                }

                                else
                                {

                                    Console.WriteLine("\nLinkedList does not contain that item.\n\n");

                                }

                                repeatLinkedList = true;//takes user back to main menu

                            }







                            //5. Clear LinkedList

                            else if (iLinkedList == 5)
                            {

                                myLinkedList.Clear();//clears linkedlist

                                repeatLinkedList = true;//takes user back to main menu

                            }







                            //6. Search LinkedList

                            else if (iLinkedList == 6)
                            {



                                Console.WriteLine("\nEnter an item you would like to search for:\n");//prompts user for input

                                string sLinkedListSearch = Console.ReadLine();





                                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); //Create a StopWatch object

                                sw.Start();//call the stopwatch function

                                if (myLinkedList.Contains(sLinkedListSearch))
                                {

                                    Console.WriteLine("\nItem found.\n");

                                    sw.Stop();

                                    // Get the elapsed time as a TimeSpan value.

                                    TimeSpan ts = sw.Elapsed;

                                    Console.WriteLine("Elapsed time: " + ts + "\n\n");

                                }

                                else
                                {

                                    Console.WriteLine("\nItem not found.\n\n");

                                }



                                repeatLinkedList = true;//takes user back to main menu

                            }







                            //7. Return to Main Menu

                            else if (iLinkedList == 7)
                            {

                                repeat = true;//takes user back to main menu

                            }

                        }

                    }





                    //MAIN MENU CHOICE 5

                    else if (iMenu == 5)
                    {

                        //END PROGRAM

                        runMainProgram = false;

                    }

                }

            }

            Console.WriteLine("\nThanks! Press ENTER to end the program.");//Informs the user that he/she is exiting the program.

            Console.Read();

        }

    }

}