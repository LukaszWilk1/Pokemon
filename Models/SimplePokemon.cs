using Newtonsoft.Json;

namespace Pokemon.Models
{
    public class SimplePokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<PokemonTypeSlot> Types { get; set; }
    public List<PokemonStat> Stats { get; set; }
    public PokemonSprites Sprites { get; set; }
}

public class PokemonTypeSlot
{
    public int Slot { get; set; }
    public PokemonType Type { get; set; }
}

public class PokemonType
{
    public string Name { get; set; }
}

public class PokemonStat
{
    public int Base_Stat { get; set; }
    public Stat Stat { get; set; }
}

public class Stat
{
    public string Name { get; set; }
}

public class PokemonSprites
{
    public OtherSprites Other { get; set; }
}

public class OtherSprites
{
    [JsonProperty("official-artwork")]
    public OfficialArtwork OfficialArtwork { get; set; }
}

public class OfficialArtwork
{
    public string Front_Default { get; set; }
}

}