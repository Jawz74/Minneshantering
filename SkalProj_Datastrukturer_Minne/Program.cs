using System;
using System.Collections;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Recursion"
                    + "\n6. Iteration"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        Recursion();
                        break;
                    case '6':
                        Iteration();
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }



        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /* Metoden lägger till och tar bort strängar ur en lista av strängar (List<string>)
             * Implementationen för datastrukturen List<T> använder internt en underliggande array för att lagra listans element.
             * Den underliggande arrayens storlek (.Length) kallas för listans kapacitet (.Capacity)
             * 
             * Fråga 2. När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)
             * Svar: När man försöker lägga till nya element (.Add) i listan och den underliggande arrayen är full,
             * skapas en ny och större array bakom kulisserna, dit de gamla + nya elementen flyttas.
             * 
             * Fråga 3: Med hur mycket ökar kapaciteten?
             * Svar: Den fördubblas (vanligtvis 2x, .NET-optimering).
             * 
             * Fråga 4: Varför ökar inte listans kapacitet i samma takt som element läggs till?
             * Svar: Att skapa en ny array och flytta alla element är kostsamt. Kapaciteten ökas därför med mer än de gamla + nya elementen.
             * Att ha god marginal för fler element minskar då antalet omallokeringar, CPU-tid och döda arrayer på heapen.
             * 
             * Fråga 5. Minskar kapaciteten när element tas bort ur listan?
             * Svar: Nej. .Remove() minskar bara .Count men .Capacity behålls (efterom omallokering är kostsamt). 
             * Capacity minskar endast om man manuellt anropar TrimExcess().
             * 
             * Fråga 6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
             * Svar: När antalet element är känt i förväg eller när performance är extra viktigt och man vill undvika dynamisk omallokering.
             */


            List<string> theList = new List<string>();
            string? input;
            StringBuilder sb = new StringBuilder();
            bool isValidChoice = true;

            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------");

                if (theList.Count > 0)
                {
                    sb.Clear();

                    foreach (string str in theList)
                    {
                        sb.Append(str);
                        if (theList.LastIndexOf(str) < theList.Count - 1) // Skippa ", " för sista elementet i listan
                            sb.Append($", ");
                    }

                    Console.WriteLine($"Listans innehåll: {{{sb}}}");
                }
                else
                    Console.WriteLine("Listan är tom!");

                Console.WriteLine();
                Console.WriteLine($"Listans .Capacity: {theList.Capacity}");
                Console.WriteLine($"Listans .Count: {theList.Count}");
                Console.WriteLine("-----------------------------------------------");

                if (!isValidChoice)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Fel val. Försök igen.");
                    Console.ResetColor();
                    isValidChoice = true;
                }

                Console.WriteLine("'+[sträng]' lägger till en sträng.");
                Console.WriteLine("'-[sträng}' tar bort en sträng.");
                Console.WriteLine("Enter för huvudmeny");

                input = Console.ReadLine() ?? string.Empty;

                if (!string.IsNullOrEmpty(input))
                {
                    char nav = input[0];
                    string value = input.Substring(1);

                    switch (nav)
                    {
                        case '+':
                            theList.Add(value);
                            break;
                        case '-':
                            isValidChoice = theList.Remove(value);
                            break;
                        default:
                            isValidChoice = false;
                            break;
                    }
                }
            } while (!string.IsNullOrEmpty(input));

            Console.Clear();
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /* Datastrukturen kö (implementerad i Queue-klassen) fungerar enligt Först In Först Ut (FIFO) principen. 
             * Alltså att det element som läggs till först kommer vara det som tas bort först.
             * Metoden simulerar hur en kö fungerar genom att tillåta användaren att ställa element i kön (enqueue) och ta bort element ur kön (dequeue). 
             * Queue-klassen används för att implementera metoden. 
             */

            Queue theQueue = new Queue();

            string input;
            int qCounter;
            bool isValidChoice = true;

            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------");

                if (theQueue.Count == 0)
                    Console.WriteLine($"Kön är tom.");
                else
                {

                    Console.Write($"Innehåll i kön: {{");
                    qCounter = 0;
                    foreach (string str in theQueue)
                    {
                        qCounter++;
                        // Vid sista elementet i kön, skippa ", " efter utskrift.
                        if (qCounter == theQueue.Count)
                            Console.Write($"{str}");
                        else
                            Console.Write($"{str}, ");
                    }

                    Console.Write($"}}{Environment.NewLine}");
                }

                Console.WriteLine("-----------------------------------------------");

                if (!isValidChoice)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Fel val. Försök igen.");
                    Console.ResetColor();
                    isValidChoice = true;
                }

                Console.WriteLine("+[sträng] lägger till en sträng i kön");
                Console.WriteLine("- tar bort första strängen ur kön");
                Console.WriteLine("Enter för huvudmeny");

                input = Console.ReadLine() ?? string.Empty;

                if (input == string.Empty)
                    break;

                char nav = input[0];
                string value = input.Substring(1);

                isValidChoice = true;

                switch (nav)
                {
                    case '+':
                        theQueue.Enqueue(value);
                        break;
                    case '-':
                        if (theQueue.Count > 0)
                            theQueue.Dequeue();
                        else
                            isValidChoice = false;
                        break;
                    default:
                        isValidChoice = false;
                        break;
                }

            } while (true);
            Console.Clear();
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {

            /* Metoden läser in en sträng från användaren, vänder ordning på teckenföljden mha en stack, och skriver sedan ut den omvända strängen.
             * Stackar påminner om köer, men en stor skillnad är att stackar använder sig av Först In Sist Ut (FILO) principen. 
             * Alltså gäller att det element som stoppas in först (push) är det som kommer tas bort sist (pop).
            */

            Stack<char> theStack = new Stack<char>();

            string input;
            StringBuilder sb = new StringBuilder();
            bool isValidChoice = true;
            int stackCount;

            do
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------------------");
                stackCount = theStack.Count;

                if (stackCount > 0)
                {
                    while (theStack.Count > 0)
                        sb.Append(theStack.Pop());

                    Console.WriteLine($"Omvänd sträng via en stack: {sb}");
                    sb.Clear();
                }
                else
                    Console.WriteLine("Stacken är tom.");

                Console.WriteLine("---------------------------------------------------------");

                if (!isValidChoice)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Fel val. Försök igen.");
                    Console.ResetColor();
                    isValidChoice = true;
                }

                Console.WriteLine("Ange valfri sträng (>1 tecken), som ska vändas via en stack.");
                Console.WriteLine("Enter för huvudmeny");

                input = Console.ReadLine() ?? string.Empty;

                if (input == string.Empty)
                    break;
                else if (input.Length < 2 || input.Trim().Length == 0)
                    isValidChoice = false;
                else
                {
                    theStack.Clear();

                    foreach (char c in input)
                    {
                        theStack.Push(c);
                    }
                }

            } while (true);

            Console.Clear();
        }

        public static void CheckParanthesis()
        {
            /*
            * Use this method to check if the paranthesis in a string is Correct or incorrect.
            * Example of correct: (()), {}, [({})], ([{}]({})), List<int> list = new List<int>() { 1, 2, 3, 4 };
            * Example of incorrect: ({)}, (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
            */

            bool isWellFormed = false;
            Stack<char> stack = new Stack<char>();

            Console.WriteLine("Ange valfri sträng, som ska kollas om den är välformad:");           

            string input = Console.ReadLine() ?? string.Empty;

            // Loopen lägger antingen starttecken på stacken eller kollar aktuellt sluttecken mot senaste starttecknet 
            foreach (char c in input)
            {
                // Om det är ett starttecken - lägg det på stacken
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                // Om det istället är ett sluttecken, måste det matcha det senaste starttecknet (överst på stacken)
                else if (c == ')' || c == ']' || c == '}')
                {
                    // Stacken är tom, dvs inget matchande starttecken finns - Ej välformad sträng! 
                    if (stack.Count == 0)
                    {
                        isWellFormed = false;
                        break;
                    }

                    // Stacken är inte tom - hämta senaste starttecknet (överst på stacken)
                    char startSymbol = stack.Pop();

                    // Om aktuellt sluttecken inte matchar senaste starttecknet - Ej välformad sträng! 
                    if (!IsMatchingPair(startSymbol, c))
                    {
                        isWellFormed = false;
                        break;
                    }

                    // Allt gick bra, denna inre sekvens av start- och sluttecken är kollad,
                    // starttecknet har tagits bort från stacken och man är förbi sluttecknet i strängen   
                    isWellFormed = true;
                }
            }

            Console.WriteLine(isWellFormed ? "Strängen är välformad!" : "Strängen är inte välformad!");
            Console.WriteLine();
        }

        private static bool IsMatchingPair(char startSymbol, char endSymbol)
        {
            return (startSymbol == '(' && endSymbol == ')') ||
                   (startSymbol == '[' && endSymbol == ']') ||
                   (startSymbol == '{' && endSymbol == '}');
        }


        // ******************* Implementerad med kö ***********************
        //static void CheckParanthesis()
        //{
        /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})], ([{}]({})), List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: ({)}, (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
         */

        //    Queue<char> theQueue = new Queue<char>();      // För första sluttecknet i kön - hitta första sluttecken i strängen. - > Plocka av detta tecken ur strängen OCH det som kommer precis innan. -> Plocka av tecknet från kön. Börja om.

        //    string? input = null, minInput = "";
        //    bool isValidChoice = false, isWellFormed = false;
        //    int queueCount;

        //    do
        //    {
        //        Console.Clear();
        //        Console.WriteLine("---------------------------------------------------------");

        //        Console.WriteLine($"Input string: {input}");

        //        queueCount = theQueue.Count;

        //        if (isValidChoice)
        //        {
        //            isWellFormed = false;

        //            if (queueCount > 0 && (minInput.Length == queueCount * 2))  // Om antalet start+sluttecken i strängen är dubbla antalet sluttecken i kön, kan strängen vara välformad. 
        //            {
        //                foreach (char c in minInput)                            // Loopa igenom den minifierade input-strängen (innehåller bara relevanta tecken)
        //                {
        //                    if (theQueue.Count > 0 && theQueue.Peek().Equals(c))  // För första sluttecknet i kön - gå till samma sluttecken i strängen (dvs det första)
        //                    {
        //                        int charIndex = minInput.IndexOf(c);
        //                        char charBefore = minInput[charIndex - 1];       // Hämta fram tecknet direkt före första sluttecknet i strängen

        //                        if ((c == ')' && charBefore == '(') ||          // Om detta tecken är motsvarande starttecken är denna del av strängen välformad.
        //                            (c == ']' && charBefore == '[') ||
        //                            (c == '}' && charBefore == '{'))
        //                        {
        //                            minInput = minInput.Remove(charIndex, 1);     // Plocka bort sluttecknet från strängen. 
        //                            minInput = minInput.Remove(charIndex - 1, 1); // Plocka bort starttecknet från strängen.
        //                            theQueue.Dequeue();                           // Plocka av sluttecknet från kön. Gå vidare med kvarvarande tecken i strängen och kön.
        //                        }
        //                        else
        //                            break;
        //                    }
        //                }

        //                // Om alla sluttecken i kön har matchat alla starttecken i inputsträngen är kön tom och strängen är välformad
        //                isWellFormed = theQueue.Count == 0;
        //            }

        //            Console.WriteLine(isWellFormed ? "The input string is well-formed!" : "The input string is not well-formed!");
        //        }

        //        Console.WriteLine("-------------------------------------------------------------");

        //        if (!isValidChoice && input != null)
        //        {
        //            Console.ForegroundColor = ConsoleColor.DarkRed;
        //            Console.WriteLine("Fel val. Försök igen.");
        //            Console.ResetColor();
        //        }

        //        Console.WriteLine("Ange valfri sträng, som ska kollas om den är välformad.");
        //        Console.WriteLine("Enter för huvudmeny");

        //        input = Console.ReadLine() ?? string.Empty;

        //        if (input == string.Empty)
        //            break;
        //        else if (input.Length >= 2)  // Inmatad sträng måste vara minst 2 tkn för att kollas om den är välformad.
        //        {
        //            theQueue.Clear();
        //            minInput = "";

        //            foreach (char c in input)
        //            {
        //                // Köa upp alla sluttecken i inputsträngen, i tur och ordning, från första förekomst till sista.
        //                if (c == ')' || c == ']' || c == '}')
        //                {
        //                    theQueue.Enqueue(c);
        //                }

        //                // Minifiera inputsträngen till endast tecken som är relevanta för att kolla om den är välformad. 
        //                if (c == '(' || c == ')' || c == '[' || c == ']' || c == '{' || c == '}')
        //                    minInput += (c);
        //            }

        //            isValidChoice = minInput != ""; // Om inmatad sträng saknar relevanta tecken ska ny sträng efterfrågas. 
        //        }

        //    } while (true);

        //    Console.Clear();
        //}

        private static void Recursion()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("1. Beräkna det n:te jämna talet rekursivt.");
            Console.WriteLine("2. Beräkna det n:te Fibonacci-talet rekursivt.");
            Console.WriteLine("Enter - Återgå till huvudmeny.");
            Console.WriteLine("Ange ett val:");

            string val = Console.ReadLine();
            int tal;

            if ((val == "1") || (val == "2"))
            {
                Console.WriteLine("Ange ett tal:");
                tal = int.Parse(Console.ReadLine());

                if (val == "1")
                {
                    Console.WriteLine($"Rekursiv beräkning av jämt tal nr {tal} ger: " + RecursiveEven(tal));
                }

                else if (val == "2")
                {
                    Console.WriteLine($"Rekursiv beräkning av Fibonacci tal nr {tal} ger: " + Fibonacci(tal));
                }
            }


            //do
            //{
            //    Console.WriteLine("Ange ett tal:");
            //    tal = int.Parse(Console.ReadLine());

            //    Console.WriteLine(InterativeFibonacci(tal));
            //} while (tal != -1);

            Console.WriteLine();
        }

        private static void Iteration()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("1. Beräkna det n:te jämna talet interativt.");
            Console.WriteLine("2. Beräkna det n:te Fibonacci-talet interativt.");
            Console.WriteLine("Enter - Återgå till huvudmeny.");
            Console.WriteLine("Ange ett val:");

            string val = Console.ReadLine();
            int tal;

            if ((val == "1") || (val == "2"))
            {
                Console.WriteLine("Ange ett tal:");
                tal = int.Parse(Console.ReadLine());

                if (val == "1")
                {
                    Console.WriteLine($"Iterativ beräkning av jämt tal nr {tal} ger: " + IterativeEven(tal));
                }

                else if (val == "2")
                {
                    Console.WriteLine($"Iterativ beräkning av Fibonacci-tal nr {tal} ger: " + IterativeFibonacci(tal));
                }
            }


            //do
            //{
            //    Console.WriteLine("Ange ett tal:");
            //    tal = int.Parse(Console.ReadLine());

            //    Console.WriteLine(InterativeFibonacci(tal));
            //} while (tal != -1);
        }

        static int RecursiveEven(int n)
        {
            if (n == 1)
                return 2;

            return (RecursiveEven(n - 1) + 2);
        }

        static int IterativeEven(int n)
        {
            int result = 2;

            for (int i = 0; i < n - 1; i++)
            {
                result += 2;
            }

            return result;
        }

        // Returnerar n:te talet i Fibonacci-sekvensen (0, 1, 1, 2, 3, 5, 8, 13, 21,... osv) genom rekursion
        static int Fibonacci(int n)
        {
            // De två första talen i sekvensen skiljer sig eftersom de inte är resultatet av de två föregående.
            // Därför är dessa tal hårdkodade och används som basfall, dvs returneras direkt av metoden.

            if (n <= 1)    // För enkelhetens skull returnerar även n < 1 första talet i sekvensen.
                return 0;

            if (n == 2)
                return 1;

            // Anropar sig själv tills basfallet nås, då returneras ett resultat till de tidigare anropen.
            return (Fibonacci(n - 1) + Fibonacci(n - 2));
        }


        // Returnerar n:te talet i Fibonacci-sekvensen (0, 1, 1, 2, 3, 5, 8, 13, 21,...) osv iterativt
        static int IterativeFibonacci(int n)
        {
            if (n <= 1)
                return 0;

            if (n == 2)
                return 1;

            int firstFibb = 0;  // Första talet i sekvensen är 0
            int secondFibb = 1; // Andra talet i sekvensen är 1
            int currentFibb = 0; // Mellanlagring av 1:a föregående + 2:a föregående tal i Fibonacci-sekvensen

            // Loopen kör från 3, eftersom 3e talet i sekvensen kan hårdkodas som firstFibb + secondFibb
            //
            // Exempel: Sekvensen fram till 3e talet är: 0, 1, 1
            // I första iterationen har 3e talet i sekvensen resultatet 0 + 1 = 1, lägg detta i currentFibb
            // Värdena flyttas fram: firstFibb får värdet av secondFibb (=1, dvs hela den föregående sekvensens värde)
            // och secondFibb får resultatet av currentFibb (=1, dvs 3e talet ) som nytt resultat
            // Börja om med nästa tal och kör vidare på samma sätt till måltalet (n) är nått. 

            for (int i = 3; i <= n; i++)
            {
                currentFibb = firstFibb + secondFibb;
                firstFibb = secondFibb;
                secondFibb = currentFibb;
            }

            return currentFibb;
        }
    }
}

