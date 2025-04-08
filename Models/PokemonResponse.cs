namespace Pokemon.Models
{
    public class PokemonResponse
    {
        public int? Count {get; set;}
        public string? Next {get; set;}
        public string? Previous {get; set;}
        public List<PokemonResult> Results {get; set;}
    }
}