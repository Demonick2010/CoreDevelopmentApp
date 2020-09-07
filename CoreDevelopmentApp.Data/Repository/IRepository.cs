using CoreDevelopmentApp.Models.Models;
using System.Collections.Generic;

namespace CoreDevelopmentApp.Data.Repository
{
    public interface IRepository
    {
        IEnumerable<ApplicationListModel> GetAllApplicationItems();
        IEnumerable<RequestModel> GetAllRequests();
        RequestModel GetEdit(int id);
        RequestModel UpdateRequest(RequestModel updatedModel);
    }
}
