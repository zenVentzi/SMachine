namespace SMachine;

public class SymbolGenerator(SymbolConfig sConfig) : ISymbolGenerator
{
    public Symbol[,] Gen()
    {
        const int rows = 4;
        const int columns = 3;
        var random = new Random();
        var allSymbols = new Symbol[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                int rand = random.Next(0, 100);
                Symbol currentSymbol;

                if (rand < sConfig.Wildcard.Probability)
                {
                    currentSymbol = sConfig.Wildcard;
                }
                else if (rand < sConfig.Pineapple.Probability)
                {
                    currentSymbol = sConfig.Pineapple;
                }
                else if (rand < sConfig.Banana.Probability)
                {
                    currentSymbol = sConfig.Banana;
                }
                else
                {
                    currentSymbol = sConfig.Apple;
                }

                allSymbols[row, column] = currentSymbol;
            }
        }

        return allSymbols;
    }
}
