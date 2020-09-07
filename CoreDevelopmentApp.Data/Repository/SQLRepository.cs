using CoreDevelopmentApp.Data.DB;
using CoreDevelopmentApp.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CoreDevelopmentApp.Data.Repository
{
    public class SQLRepository : IRepository
    {
        private readonly AppDbContext _appDbContext;

        public SQLRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public RequestModel GetEdit(int id)
        {
            var result = _appDbContext.Requests.FirstOrDefault(x => x.Id == id);

            if (result != null)
                return result;
            else
                return null;
        }

        public IEnumerable<ApplicationListModel> GetAllApplicationItems()
        {
            return _appDbContext.ApplicationLists;
        }

        public IEnumerable<RequestModel> GetAllRequests()
        {
            return _appDbContext.Requests;
        }

        public RequestModel UpdateRequest(RequestModel updatedModel)
        {
            var updated = _appDbContext.Attach(updatedModel);
            updated.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();
            return updatedModel;
        }
    }
}
