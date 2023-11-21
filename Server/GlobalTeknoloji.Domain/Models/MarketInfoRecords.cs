namespace GlobalTeknoloji.Domain.Models;

public record Market(string Label, String Name, double Price);
public record CoinsInfo(List<Market> Markets);
//public record CoinsInfo(Market[] Markets);

