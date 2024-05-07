namespace OopThirdPart
{

    class Program
    {

        static void Main(string[] args)
        {
            NumericalExpression myNumExp = new NumericalExpression(10922293);
            NumericalExpression mySecondExp = new NumericalExpression(703831343932);
            Console.WriteLine(myNumExp);
            Console.WriteLine(mySecondExp);
            Console.WriteLine($"digits to write {mySecondExp.Number}: {NumericalExpression.SumLetters(mySecondExp)}");
            Console.WriteLine("digits to write 129: " + NumericalExpression.SumLetters(129));
            Console.WriteLine($"digits to write {myNumExp.Number}: {NumericalExpression.SumLetters(myNumExp)}");
        }
    }
}
