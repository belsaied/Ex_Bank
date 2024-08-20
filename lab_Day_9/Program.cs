using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Diagnostics;
namespace lab_Day_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Ex input 2 ints
            while (true)
            {
                try
                {
                    Console.Write("Enter the first integer: ");
                    int num1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter the second integer: ");
                    int num2 = Convert.ToInt32(Console.ReadLine());

                    int result = num1 / num2;
                    Console.WriteLine($"Result: {result}");
                    break; // Exit the loop if no exception occurs
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    LogError(ex);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Error: Invalid input. Please enter valid integers.");
                    LogError(ex);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Error: The number entered is too large or too small.");
                    LogError(ex);
                }
            }
            #endregion

            #region InsufficientBalanceException
            BankAccount account = new BankAccount();
            bool continueTransaction = true;

            while (continueTransaction)
            {
                try
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Exit");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter amount to deposit: ");
                            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                            account.Deposit(depositAmount);
                            Console.WriteLine($"Deposit successful. New balance: {account.Balance}");
                            break;
                        case 2:
                            Console.Write("Enter amount to withdraw: ");
                            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                            account.Withdraw(withdrawAmount);
                            Console.WriteLine($"Withdrawal successful. New balance: {account.Balance}");
                            break;
                        case 3:
                            continueTransaction = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (InsufficientBalanceException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            #endregion

            #region ArrayList with Different Data Types
            // Create an ArrayList and add elements of different data types
            ArrayList arrayList = new ArrayList();
            arrayList.Add(10);
            arrayList.Add("Belal");
            arrayList.Add(3.14);
            arrayList.Add(20);
            arrayList.Add("Saied");
            arrayList.Add(2.71);

            // Iterate and print each element
            Console.WriteLine("ArrayList elements:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // Create Lists for each type
            List<int> intList = new List<int>();
            List<string> stringList = new List<string>();
            List<double> doubleList = new List<double>();

            // Map data from ArrayList to respective Lists
            foreach (var item in arrayList)
            {
                if (item is int)
                {
                    intList.Add((int)item);
                }
                else if (item is string)
                {
                    stringList.Add((string)item);
                }
                else if (item is double)
                {
                    doubleList.Add((double)item);
                }
            }

            // Print the Lists
            Console.WriteLine("\nList<int> elements:");
            intList.ForEach(Console.WriteLine);

            Console.WriteLine("\nList<string> elements:");
            stringList.ForEach(Console.WriteLine);

            Console.WriteLine("\nList<double> elements:");
            doubleList.ForEach(Console.WriteLine);
            #endregion

            #region Hashtable for Employee Records
            // Create a Hashtable to store employee information
            Hashtable employees = new Hashtable();

            // Add entries to the Hashtable
            employees.Add(1, "hazem");
            employees.Add(2, "ahmed");
            employees.Add(3, "mohamed");
            employees.Add(4, "maryem");
            employees.Add(5, "ali");

            // Retrieve and display the name of a specific employee using their ID
            int employeeIdToRetrieve = 3;
            if (employees.ContainsKey(employeeIdToRetrieve))
            {
                Console.WriteLine($"\nEmployee with ID {employeeIdToRetrieve}: {employees[employeeIdToRetrieve]}");
            }
            else
            {
                Console.WriteLine($"\nEmployee with ID {employeeIdToRetrieve} not found.");
            }

            // Remove an employee record from the Hashtable using their ID
            int employeeIdToRemove = 2;
            if (employees.ContainsKey(employeeIdToRemove))
            {
                employees.Remove(employeeIdToRemove);
                Console.WriteLine($"\nEmployee with ID {employeeIdToRemove} removed.");
            }
            else
            {
                Console.WriteLine($"\nEmployee with ID {employeeIdToRemove} not found.");
            }

            // Iterate over the Hashtable and display all key-value pairs
            Console.WriteLine("\nAll employee records:");
            foreach (DictionaryEntry entry in employees)
            {
                Console.WriteLine($"ID: {entry.Key}, Name: {entry.Value}");
            }
            #endregion

            #region Non-Generic SortedList Operations
            //// 1. Create a SortedList
            //SortedList productList = new SortedList();

            //// 2. Add Entries
            //productList.Add(101, "Laptop");
            //productList.Add(102, "Smartphone");
            //productList.Add(103, "Tablet");
            //productList.Add(104, "Monitor");
            //productList.Add(105, "Keyboard");

            //// 3. Sort Order (SortedList automatically sorts by key)
            //Console.WriteLine("SortedList automatically sorts by key:");

            //// 4. Access Value by Key
            //int productId = 103;
            //if (productList.ContainsKey(productId))
            //{
            //    Console.WriteLine($"Product with ID {productId}: {productList[productId]}");
            //}
            //else
            //{
            //    Console.WriteLine($"Product with ID {productId} not found.");
            //}

            //// 5. Iterate and Display
            //Console.WriteLine("\nAll products in the SortedList:");
            //foreach (DictionaryEntry entry in productList)
            //{
            //    Console.WriteLine($"Product ID: {entry.Key}, Product Name: {entry.Value}");
            //}

            #endregion

            #region  Dictionary<TKey, TValue> Operations
            // 1. Create a Dictionary
            Dictionary<int, string> studentDictionary = new Dictionary<int, string>();

            // 2. Add Entries
            studentDictionary.Add(1, "Ahmed");
            studentDictionary.Add(2, "Belal");
            studentDictionary.Add(3, "hazem");
            studentDictionary.Add(4, "maryem");
            studentDictionary.Add(5, "maged");

            // 3. Update Value
            int updateId = 3;
            if (studentDictionary.ContainsKey(updateId))
            {
                studentDictionary[updateId] = "yaser";
                Console.WriteLine($"Updated student ID {updateId} to {studentDictionary[updateId]}");
            }

            // 4. Check Existence
            int checkId = 2;
            if (studentDictionary.ContainsKey(checkId))
            {
                Console.WriteLine($"Student ID {checkId} exists: {studentDictionary[checkId]}");
            }
            else
            {
                Console.WriteLine($"Student ID {checkId} does not exist.");
            }

            // 5. Iterate and Display
            Console.WriteLine("\nAll students in the Dictionary:");
            foreach (var entry in studentDictionary)
            {
                Console.WriteLine($"Student ID: {entry.Key}, Student Name: {entry.Value}");
            }
            #endregion

            #region Generic SortedList<TKey, TValue> Operations
            // 1. Create a SortedList
            SortedList<string, double> productList = new SortedList<string, double>();

            // 2. Add Entries
            productList.Add("Laptop", 999.99);
            productList.Add("Smartphone", 699.99);
            productList.Add("Tablet", 399.99);
            productList.Add("Monitor", 199.99);
            productList.Add("Keyboard", 49.99);

            // 3. Sort Order (SortedList automatically sorts by key)
            Console.WriteLine("SortedList automatically sorts by product name:");

            // 4. Access Value by Key
            string productName = "Smartphone";
            if (productList.ContainsKey(productName))
            {
                Console.WriteLine($"Price of {productName}: ${productList[productName]}");
            }
            else
            {
                Console.WriteLine($"Product {productName} not found.");
            }

            // 5. Iterate and Display
            Console.WriteLine("\nAll products in the SortedList:");
            foreach (var entry in productList)
            {
                Console.WriteLine($"Product Name: {entry.Key}, Product Price: ${entry.Value}");
            }
            #endregion

            #region  Comparison of Generic and Non-Generic Collections
            // Non-generic Hashtable
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, "Rawda");
            hashtable.Add(2, "nour");
            hashtable.Add(3, "maaloul");

            // Generic Dictionary<int, string>
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Rawda");
            dictionary.Add(2, "nour");
            dictionary.Add(3, "maaloul");

            // Performance Test
            PerformanceTest(hashtable, dictionary);

            // Type Safety
            TypeSafetyTest(dictionary);

            // Memory Usage
            MemoryUsageDiscussion();
            #endregion
        }
        #region LogError using StreamWriter
        static void LogError(Exception ex)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Admin\Documents\error_log.txt", true))
            {
                writer.WriteLine($"{DateTime.Now}: {ex.GetType()} - {ex.Message}");
            }
        }
        #endregion

        #region PerformanceTest method
        static void PerformanceTest(Hashtable hashtable, Dictionary<int, string> dictionary)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Adding elements
            stopwatch.Start();
            for (int i = 4; i <= 10000; i++)
            {
                hashtable.Add(i, "Employee" + i);
            }
            stopwatch.Stop();
            Console.WriteLine("Hashtable Add: " + stopwatch.ElapsedMilliseconds + " ms");

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 4; i <= 10000; i++)
            {
                dictionary.Add(i, "Employee" + i);
            }
            stopwatch.Stop();
            Console.WriteLine("Dictionary Add: " + stopwatch.ElapsedMilliseconds + " ms");

            // Retrieving elements
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 1; i <= 10000; i++)
            {
                var value = hashtable[i];
            }
            stopwatch.Stop();
            Console.WriteLine("Hashtable Retrieve: " + stopwatch.ElapsedMilliseconds + " ms");

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 1; i <= 10000; i++)
            {
                var value = dictionary[i];
            }
            stopwatch.Stop();
            Console.WriteLine("Dictionary Retrieve: " + stopwatch.ElapsedMilliseconds + " ms");

            // Removing elements
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 1; i <= 10000; i++)
            {
                hashtable.Remove(i);
            }
            stopwatch.Stop();
            Console.WriteLine("Hashtable Remove: " + stopwatch.ElapsedMilliseconds + " ms");

            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 1; i <= 10000; i++)
            {
                dictionary.Remove(i);
            }
            stopwatch.Stop();
            Console.WriteLine("Dictionary Remove: " + stopwatch.ElapsedMilliseconds + " ms");
        }
        #endregion

        #region TypeSafetyTest method
        static void TypeSafetyTest(Dictionary<int, string> dictionary)
        {
           
        }
        #endregion

        #region MemoryUsageDiscussion()
        static void MemoryUsageDiscussion()
        {
            Console.WriteLine("Memory Usage Discussion:");
            Console.WriteLine("Generic collections like Dictionary<int, string> are type-safe and avoid boxing/unboxing, leading to better performance and lower memory usage.");
            Console.WriteLine("Non-generic collections like Hashtable store objects, which can lead to higher memory usage due to boxing/unboxing and lack of type safety.");
        }
        #endregion

    }
}



