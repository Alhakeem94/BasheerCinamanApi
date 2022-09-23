using BasheerCinamanApi.Data;
using BasheerCinamanApi.Models;
using BasheerCinamanApi.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BasheerCinamanApi.UnitOfWork.Repos
{
    public class ProvidorRepo : IProvidor
    {

        private ApplicationDbContext _db;

        public ProvidorRepo(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> AddProvidor(ProvidorModel newProvidor)
        {
            try
            {
                var CheckIfProvidorExits = await CheckIfProvidorExistsInDataBase(newProvidor.Name);

                if (CheckIfProvidorExits)
                {
                    return "The Providor exists in the dataBase ";
                }
                else
                {
                    await _db.ProvidorsTable.AddAsync(newProvidor);

                    var Result = await _db.SaveChangesAsync();
                    if (Result == 0)
                    {
                        return "There has been a problem adding the Providor to the database";
                    }
                    else
                    {
                        return "The Providor has Been added to the Database";
                    }
                }

            }
            catch (Exception e)
            {

                return e.Message;
            }

        }

        public async Task<bool> CheckIfProvidorExistsInDataBase(string ProvidorName)
        {
            var CheckIfProvidorExists = await _db.ProvidorsTable.FirstOrDefaultAsync(a => a.Name.ToLower() == ProvidorName.ToLower());

            if (CheckIfProvidorExists is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<List<ProvidorModel>> GetAllProvidors()
        {
            return await _db.ProvidorsTable.ToListAsync();
        }

        public async Task<ProvidorModel> GetProvidorById(int ProvidorId)
        {
            return await _db.ProvidorsTable.FirstOrDefaultAsync(a => a.Id == ProvidorId);
        }
    }
}
