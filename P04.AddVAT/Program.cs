namespace P04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(p => p * 1.2)
                .ToArray();

            foreach (var pr in prices)
            {
                Console.WriteLine($"{pr:f2}");
            }
        }
    }
}