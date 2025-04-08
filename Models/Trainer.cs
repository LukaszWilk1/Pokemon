namespace Pokemon.Models
{
    public class Trainer
    {
        public int? Id {get; set;}
        public string Name {get; set;}
        public string Surname {get; set;}
        public int Age {get; set;}
        public DateTime Birthday {get; set;}
        public bool LegalAge {get; set;}
    }
}
