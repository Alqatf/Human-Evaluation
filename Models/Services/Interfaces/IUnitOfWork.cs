using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AH_Project.Models.Entities;

namespace AH_Project.Models.Services.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ModelCaption> ModelCaptions { get; }
        IRepository<SimilarCaption> SimilarCaptions { get; }
        IRepository<Evaluation> Evaluations { get; }
        int Complete();
    }
}
