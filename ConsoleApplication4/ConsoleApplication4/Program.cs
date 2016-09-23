using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
 
       
        {
            int queueMenu = 0;
            Queue<String> myQueue = new Queue<string>();
            Console.WriteLine("1. Add one time to queue    \n2. Add huge list to queue   \n3. Display queue   \n4. Delete from queue    \n5. Clear queue  \n6. Search queue    \n7. Return to main menu");
            queueMenu = Convert.ToInt16(Console.ReadLine());
            while (queueMenu > 0 && queueMenu < 7)
            
            {


                if (queueMenu == 1)
                {
                    Console.WriteLine("Enter a string to insert into the data structure.");
                    String qData = Console.ReadLine();
                    myQueue.Enqueue(qData);
                    Console.WriteLine(qData + "was added to the queue!");
                }
                else if (queueMenu == 2)
                {
                    for (int iCount = 0; iCount < 2000; iCount++)
                    {
                        myQueue.Enqueue("New Entry " + (iCount + 1));
                    }

                }
               //outputs the data
                else if (queueMenu == 3)
                {
                    foreach (var s in myQueue)
                    {
                        Console.WriteLine(s);
                    }
                }

                else if (queueMenu == 4)
                {
                    Console.WriteLine("Which item would you like to delete?");
                    int deleteItem = Convert.ToInt32(Console.ReadLine());
                    Queue<string> Queue2 = new Queue<string>();
                    int size = myQueue.Count;
                    for (int count = 0; count < size; count++)
                    
                    {
                        
                        if (count == (deleteItem - 1))
                        {
                            myQueue.Dequeue();
                        }
                        else
                        {
                            Queue2.Enqueue(myQueue.Dequeue());
                        }
                        
                    }
                    myQueue = Queue2;
                    

                }
                else if (queueMenu == 5)
                {
                    myQueue.Clear();
                }
                else if (queueMenu == 6)
                {
                
                    Console.WriteLine("What entry would you like to see?");
                    String search = (Console.ReadLine());
                    
                    if (myQueue.Contains(search))
                    {
                        Console.WriteLine("Item Found");
                    }
                    else
                    {
                        Console.WriteLine("item not found");
                    }
                    

                }
                else if (queueMenu == 7)
                {
                
                }
                else
                {
                    Console.WriteLine();
                }

                Console.WriteLine("1.Add one time to queue    \n2. Add huge list to queue   \n3. Display queue   \n4. Delete from queue    \n5. Clear queue  \n6. Search queue    \n7. Return to main menu");
                queueMenu = Convert.ToInt16(Console.ReadLine());
            }
            }
        }
    }


        }
    

