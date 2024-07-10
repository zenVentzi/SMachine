namespace SMachine;

public class SymbolManager(ISymbolConfig sConfig, ISymbolGenerator gen)
{
    private Symbol[,] Symbols { get; set; } = gen.Gen();

    public decimal GetTotalCoefficient()
    {
        Symbol? TryGetFirstNonWildcard(int row)
        {
            for (int i = 0; i < Symbols.GetLength(1); i++)
            {
                if (Symbols[row, i] != sConfig.Wildcard)
                {
                    return Symbols[row, i];
                }
            }

            return null;
        }

        decimal totalCoefficient = 0;

        for (int row = 0; row < Symbols.GetLength(0); row++)
        {
            Symbol? firstNonWildcard = TryGetFirstNonWildcard(row);

            if (firstNonWildcard == null) continue;
            decimal rowCoefficient = 0;

            for (int column = 0; column < Symbols.GetLength(1); column++)
            {
                Symbol current = Symbols[row, column];

                if (current.Equals(sConfig.Wildcard))
                {
                    continue;
                }

                if (!current.Equals(firstNonWildcard))
                {
                    rowCoefficient = 0;
                    break;
                }
                else { rowCoefficient += current.Coefficient; }

            }

            totalCoefficient += rowCoefficient;
        }

        return totalCoefficient;
    }

    public void PrintSymbols()
    {
        Console.WriteLine();

        for (int row = 0; row < Symbols.GetLength(0); row++)
        {
            for (int column = 0; column < Symbols.GetLength(1); column++)
            {
                Console.Write(Symbols[row, column].Character);
            }

            Console.WriteLine();
        }
    }
}
