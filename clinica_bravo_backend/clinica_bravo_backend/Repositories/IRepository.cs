using clinica_bravo_backend.Entities; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clinica_bravo_backend.Repositories
{
    public interface IRepository
    {
        void CreateTopic(Topic topic);
        Guid GetGUID();
        Task<Topic> GetById(int Id);
        List<Topic> GetAllTopics();
    }
}
