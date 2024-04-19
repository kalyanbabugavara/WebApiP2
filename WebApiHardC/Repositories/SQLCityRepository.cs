using Microsoft.EntityFrameworkCore;
using WebApiP2.Data;
using WebApiP2.Domain.Model;

namespace WebApiP2.Repositories
{
    //implementing repositoryinterface
    public class SQLCityRepository : ICityRepository
    {
        // injecting dbcontext class
        private readonly CityDbContext dbContext;
        public SQLCityRepository(CityDbContext dbContext)
        { 
            this.dbContext = dbContext;
        }

        public async Task<City> CreateAsync(City city)
        {
            await dbContext.cities.AddAsync(city);
            await dbContext.SaveChangesAsync();
            return city;
        }

        public async Task<City?> DeleteAsync(Guid id)
        {
            var existingCity = await dbContext.cities.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCity == null)
            {
                return null;
            }

            dbContext.cities.Remove(existingCity);
           await dbContext.SaveChangesAsync();

            return existingCity;
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await dbContext.cities.ToListAsync();
        }

        public async Task<City> GetByIDAsync(Guid id)
        {
            return await dbContext.cities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<City?> UpdateAsync(Guid id, City city)
        {
            var existingCity = await dbContext.cities.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCity == null)
            {
                return null;
            }

            existingCity.Rank = city.Rank;
            existingCity.Name = city.Name;
            existingCity.State = city.State;

            await dbContext.SaveChangesAsync();
            return existingCity;

            
        }
    }
}
