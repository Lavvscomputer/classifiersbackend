using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Classifiers.Domain;

namespace Classifiers.Application.Interfaces
{
    public interface IClassifiersDbContext
    {
        //  коллекция объектов типа Classifier (представляет таблицув бд)
        DbSet<Classifier> Classifiers { get; set;  }
        //Метод для асинхронного сохранения изменений в бд
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
