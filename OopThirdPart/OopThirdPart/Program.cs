namespace OopThirdPart
{

    class Program
    {

        static void Main(string[] args)
        {
            //node

            Node? node1 = new Node(19);
            Node? node2 = new Node(20, node1);
            Console.WriteLine($"{node1.Value}+{node2.Value}={node1.Value+node2.Value}");
            Console.WriteLine($"{node2}'s next is {node2.Next}");

            //linkedlist
            LinkedList list = new LinkedList();
            LinkedList list2 = new LinkedList();
            for (int i = 0; i < 10; i++) list.Append(i);
            Console.WriteLine(list);
            for (int i = 0; i < 10; i++) if (i % 2 == 0) list2.Append(i); else list2.Prepend(i);
            Console.WriteLine(list2);
            node1 = list2.GetMinNode();
            node2 = list2.GetMaxNode();
            if (node1 != null && node1.Value == 0) Console.WriteLine($"pre-pop min {node1.Value}\n");
            else Console.WriteLine("failed");

            if (node2 != null && node2.Value == 9) Console.WriteLine($"pre-pop max {node2.Value}\n");
            else Console.WriteLine("failed");

            list2.Pop();

            if (node1!.Equals(list2.GetMinNode()) && node2!.Equals(list2.GetMaxNode())) Console.WriteLine("not updating min max in pop succeed!");
            else Console.WriteLine("not updating min max in pop failed!");

            list2.Sort();
            Console.WriteLine(list2);

            Console.WriteLine("checks IsCircular - need false: " + list.IsCircular());
            node1 = list.GetMinNode()!; node2 = list.GetMaxNode()!;
            node2.Next = node1;
            Console.WriteLine("checks IsCircular - need true: " + list.IsCircular());

            node2.Next = null;

            foreach (int number in list2.ToList()) list.Prepend(number);
            node1 = list.GetMinNode()!;
            Console.WriteLine(list);
            list.Remove(node1);
            Console.WriteLine(list);
            list.Sort();
            Console.WriteLine(list);

            if (list.Unqueue() == node1.Value) Console.WriteLine("unqueue succeed!\n"); 
            else Console.WriteLine("unqueue failed!\n");

            Console.WriteLine(list);

            node1 = list.GetMinNode();
            if (node1 != null && node1.Value == 1) Console.WriteLine("update min succeed!\n");
            else Console.WriteLine("update min failed!\n");

            node1 = list.GetMaxNode();
            if (node1 != null && node1.Value == 9) Console.WriteLine($"pre-pop max {node1.Value}\n");
            if (list.Pop() == list.Pop()) Console.WriteLine("pop succeed!\n");
            else Console.WriteLine("pop failed!\n");

            Console.WriteLine(list);

            node1 = list.GetMaxNode();
            if (node1 != null && node1.Value == 8) Console.WriteLine("max update on pop succeed!\n");
            else Console.WriteLine("max update on pop failed!\n");


            //numerical expressions

            NumericalExpression exp1 = new(1000000);
            NumericalExpression exp2 = new(84009513);
            NumericalExpression exp3 = new(19191);
            NumericalExpression exp4 = new(18);
            NumericalExpression exp5 = new(10928324);
            Console.WriteLine($"{exp1.GetValue()} - {exp1}");
            Console.WriteLine($"{exp2.GetValue()} - {exp2}");
            Console.WriteLine($"{exp3.GetValue()} - {exp3}");
            Console.WriteLine($"{exp4.GetValue()} - {exp4}");
            Console.WriteLine($"{exp5.GetValue()} - {exp5}");

            Console.WriteLine($"digits for all numbers up to {exp3.GetValue()}: {NumericalExpression.SumLetters(exp3)}");
            Console.WriteLine($"brute force calc for {exp3.GetValue()}: {BruteForceSumDigits(exp3.GetValue())}");

            Console.WriteLine($"digits for all numbers up to {exp4.GetValue()}: {NumericalExpression.SumLetters(exp4)}");
            Console.WriteLine($"brute force calc for {exp4.GetValue()}: {BruteForceSumDigits(exp4.GetValue())}");

            Console.WriteLine($"digits for all numbers up to {exp5.GetValue()}: {NumericalExpression.SumLetters(exp5)}");
            Console.WriteLine($"brute force calc for {exp5.GetValue()}: {BruteForceSumDigits(exp5.GetValue())}");
        }

        private static ulong BruteForceSumDigits(ulong number)
        {
            ulong sum = 0;
            for (ulong i = 1; i <= number; i++)
                sum += (ulong)new NumericalExpression(i).ToString().Replace("\b", "").Replace(" ", "").Length;
            return sum + 4; //for zero
        }
    }
}
