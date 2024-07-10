namespace SMachine;

public class SymbolConfig : ISymbolConfig
{
    public Symbol Apple { get; set; } = new("Apple", 'A', 0.4M, 45);
    public Symbol Banana { get; set; } = new("Banana", 'B', 0.6M, 35);
    public Symbol Pineapple { get; set; } = new("Pineapple", 'P', 0.8M, 15);
    public Symbol Wildcard { get; set; } = new("Wildcard", '*', 0M, 5);

    public SymbolConfig() { }
    public SymbolConfig(Symbol apple, Symbol banana, Symbol pineapple, Symbol wildcard)
    {
        Apple = apple;
        Banana = banana;
        Pineapple = pineapple;
        Wildcard = wildcard;
    }
}
