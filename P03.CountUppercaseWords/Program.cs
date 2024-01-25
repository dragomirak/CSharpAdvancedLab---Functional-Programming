namespace P03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> checker = word => char.IsUpper(word[0]);

            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(w => checker(w))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}