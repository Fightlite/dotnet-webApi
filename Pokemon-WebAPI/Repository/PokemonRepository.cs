using System;
using Pokemon_WebAPI.Data;
using Pokemon_WebAPI.Interface;
using Pokemon_WebAPI.Models;

namespace Pokemon_WebAPI.Repository
{
	public class PokemonRepository : IPokemonRepository
    {
		private readonly DataContext _context;

        public PokemonRepository(DataContext context)
		{
			_context = context;
		}

		public ICollection<Pokemon> GetPokemons()
		{
			return _context.Pokemon.OrderBy(p => p.Id).ToList();
		}

        Pokemon IPokemonRepository.GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        Pokemon IPokemonRepository.GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        decimal IPokemonRepository.GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.Where(p => p.Id == pokeId);

            if (review.Count() <= 0)
            {
                return 0;
            }

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        bool IPokemonRepository.PokemonExists(int pokeId)
        {
            return _context.Pokemon.Any(p => p.Id == pokeId);
        }
    }
}

