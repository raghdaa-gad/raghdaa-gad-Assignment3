//-----------------------------
//Part A — Project & Structure   
//-----------------------------

/*-------------------------------------------
 * 1-Roles of Project Files and Directories
 *-------------------------------------------
 * 1-.csproj:define the project configuration and settings
 *
 * 2-Program.cs: contains the c# source code of app
 *
 * 3-obj/: contains internediate files generated during build process
 *
 * 4-bin/: contains the final build output of the app
 *
 * 
 * --------------------
 * 2-File-Scoped Namespace:
 * --------------------
 *  We do not need braces '{}' around the whole file just put ';' after namespace
 * this keep the code cleaner
 *
 *
 * --------------------------
 * 3. Solution Format Comparison (.sln vs .slnx)
 * ---------------------
 * my project uses the newer .slnx format {XML -BASED}
 * the cons of .sln : has better compatibility with older tools
 *
 * 
 */
namespace  CSharpBasicsAssignment ;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("=== PART A: Project & Structure ===");
        Console.WriteLine("\n=== PART B: Variables, Types & Casting ===");
        RunTypesDemo();
        Console.WriteLine("\n=== PART C: Value vs Reference Types ===");
        RunValueVsReferenceDemo();


        //------------------------------
        //part C — Value vs. Reference Types    
        //------------------------------


        // Class reference 
        Order o1 = new Order
        {
            OrderId = 1,
            CustomerName = "Ali",
            Quantity = 2,
            UnitPrice = 100m,
            TotalPrice = 0m,
            IsPaid = false,
            DiscountPercent = 10,
            ShippingCity = "Zagazig",
            Priority = 'H',
            ItemCode = 10001
        };

        o1.CalculateTotal();

        Order o2 = o1;

        o2.IsPaid = true;

        // Classes are reference types, o1 and o2 refer to the same object
        Console.WriteLine($"o1.IsPaid = {o1.IsPaid}");
        Console.WriteLine($"o2.IsPaid = {o2.IsPaid}");

        object boxedOrder = o1;

        Order o3 = (Order)boxedOrder;

        Console.WriteLine($"ReferenceEquals(o1, o3) = {object.ReferenceEquals(o1, o3)}");

        o2.PrintSummary();

    /*     Value type: copies the value
          Reference type: copies the reference
         Class objects are stored on the heap
         Local value types can be stored on the stack
        object does not create a new object for a reference type*/


    //------------------------------
    //Part D — Scope & Operators  
    //------------------------------


    for (int i = 0; i < 3; i++) //block scope
    {
        int inside= 50;

        Console.WriteLine($"i = {i}, inside = {inside}");
    }
    
    MethodOne();
    MethodTwo();
    MethodThree();
    
    
    // D2 — Compound Assignment

    int total = 100;

    total += 5;
    Console.WriteLine($"After += : {total}"); // total += 5; is the same as: total = total + 5;

    total -= 10;
    Console.WriteLine($"After -= : {total}");

    total *= 2;
    Console.WriteLine($"After *= : {total}");

    total /= 5;
    Console.WriteLine($"After /= : {total}");

    total %= 7;
    Console.WriteLine($"After %= : {total}");
    

    // D3 — Bitwise Operators

        int a = 12;
        int b = 10;

        Console.WriteLine($"\na & b = {a & b}");
        Console.WriteLine($"a | b = {a | b}");
        Console.WriteLine($"a ^ b = {a ^ b}");
        
// & works bit by bit, while && works with true/false conditions
// && uses short-circuit: if the left side is false, the right side is not evaluated

}

    private static void RunTypesDemo()
    {
        #region Variables and Types

        int numInt = 123;
        long numLong = 12213223232;
        double numDou = 12.334d;
        decimal numDec = 13.7687m;
        bool numBool = true;
        char numChar = 'R';
        string numStr = "Raghda";
        var numInter = "Inferred Type";

        Console.WriteLine($"int: {numInt} | Type: {numInt.GetType()}");
        Console.WriteLine($"long: {numLong} | Type: {numLong.GetType()}");
        Console.WriteLine($"double: {numDou} | Type: {numDou.GetType()}");
        Console.WriteLine($"decimal: {numDec} | Type: {numDec.GetType()}");
        Console.WriteLine($"bool: {numBool} | Type: {numBool.GetType()}");
        Console.WriteLine($"char: {numChar} | Type: {numChar.GetType()}");
        Console.WriteLine($"string: {numStr} | Type: {numStr.GetType()}");
        Console.WriteLine($"var: {numInter} | Type: {numInter.GetType()}");

        #endregion


        // 2-Implicit Conversion
        long x = numInt;
        int y = numChar;

        // No cast is needed because these conversions are implicit.
        Console.WriteLine($"int to long :{x}");
        Console.WriteLine($"char to int {y}");



        // 3-Explicit Conversion

        double z = 9.8;
        int zInt = (int)z;
        int zInt32 = Convert.ToInt32(z);


        //cast int --> remove decimal part 
        // converted int32 --> round the value
        Console.WriteLine($"Casted (int): {zInt} , Converted (ToInt32): {zInt32}");


        // 4-Integer division trap
        int intDiv = 5 / 2;
        double doubleDiv = 5.0 / 2;

        // Integer division removes the decimal part, while double division keeps it.
        Console.WriteLine($"Integer division (5 / 2): {intDiv} , Double division (5.0 / 2): {doubleDiv}");


        // 5-Boxing and Unboxing
        object boxed = numInt;
        int unboxed = (int)boxed;
        Console.WriteLine($"Boxed object: {boxed} | Unboxed int: {unboxed}");


        // 6-Parsing
        string text = "42";
        int parsedNumber = int.Parse(text);
        string badText = "abc";
        bool success = int.TryParse(badText, out int result);

        Console.WriteLine($"Parsed number: {parsedNumber}");
        Console.WriteLine($"TryParse succeeded: {success}");
        if (!success)
        {
            Console.WriteLine("The string could not be converted to an integer.");
        }


        // 7-Float to Decimal explicit cast 
        float floatNum = 10.5f;
        decimal decimalNum = (decimal)floatNum;

        // float uses binary floating-point representation while decimal uses Decimal-based representation
        // The conversion may lose precision so C# requires an explicit cast
        Console.WriteLine($"float to decimal: {decimalNum}");

    }

    private static void RunValueVsReferenceDemo()
    {
       
        Point p1 = new Point { X = 1, Y = 2 };
        Point p2 = p1;
        p2.X = 99;
        
        // Structs are value types ,assigning p1 to p2 copies the values
        Console.WriteLine($"p1.X = {p1.X}, p2.X = {p2.X}");
        
        
    }


    private struct Point
    {
        public int X;
        public int Y;
    }
    
    
    private static int number = 60; //field scope 

    static void MethodOne()
    {
        Console.WriteLine($"MethodOne: {number}");
    }

    static void MethodTwo()
    {
        Console.WriteLine($"MethodTwo: {number}");
    }

    static void MethodThree() //method scope
    {
        int localNum = 60;
        

        Console.WriteLine($"Local variable: {localNum}");
    }
}
