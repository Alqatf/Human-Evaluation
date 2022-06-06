using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AH_Project.Models.Entities;
using AH_Project.Models.Services.Interfaces;

namespace AH_Project.Models.Services.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IRepository<ModelCaption> ModelCaptions { get; private set; }
        public IRepository<SimilarCaption> SimilarCaptions { get; private set; }
        public IRepository<Evaluation> Evaluations { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            ModelCaptions = new Repository<ModelCaption>(_context);
            SimilarCaptions = new Repository<SimilarCaption>(_context);
            Evaluations = new Repository<Evaluation>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
