using System.Collections.Generic;

namespace campeonato.Entities
{
    public class Campeonato
    {
        public int Id { get; set; }
        public ICollection<Jogo> Jogadas { get; set; }    
    }
}