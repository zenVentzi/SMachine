namespace SMachine;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please deposit money you'd like to play with:");
        var playerBalance = Convert.ToDecimal(Console.ReadLine());

        while (playerBalance > 0)
        {
            Console.WriteLine("Enter stake amount:");
            var stake = Convert.ToDecimal(Console.ReadLine());

            var sConfig = new SymbolConfig();
            var sGenerator = new SymbolGenerator(sConfig);
            var symbolManager = new SymbolManager(sConfig, sGenerator);

            var totalCoefficient = symbolManager.GetTotalCoefficient();
            var winAmount = stake * totalCoefficient;
            playerBalance = (playerBalance - stake) + winAmount;


            symbolManager.PrintSymbols();
            Console.WriteLine();
            Console.WriteLine($"You have won {winAmount:0.##}");
            Console.WriteLine($"Current balance is {playerBalance:0.##}");
            Console.WriteLine();
        }
    }
}
