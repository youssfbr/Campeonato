using System;
using System.Threading.Tasks;
using campeonato.Context;
using campeonato.Entities;
using campeonato.Services.Interfaces;

namespace campeonato.Services
{
    public class CampeonatoService : ICampeonatoService
    {
        private readonly AppDbContext _context;

        public CampeonatoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Campeonato> GetCampeonato(int id)
        {
            return await _context.Campeonatos.FindAsync(id);
        }

        public async Task<bool> AddCampeonato(Campeonato campeonato)
        {
            _context.Campeonatos.Add(campeonato);
            return (await _context.SaveChangesAsync()) > 0;
        }
        
    }
}