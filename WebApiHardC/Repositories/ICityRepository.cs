using WebApiP2.Domain.Model;

namespace WebApiP2.Repositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllAsync();

        Task<City> GetByIDAsync(Guid id);

        Task<City> CreateAsync(City city);

        Task<City?> UpdateAsync(Guid id, City city);

        Task<City?> DeleteAsync(Guid id);
    }
}

/*
 * Repository pattern seperates the data access from the application. creates an abstraction layer.
 *  controller - repository - dbcontext - repository - database
 */
