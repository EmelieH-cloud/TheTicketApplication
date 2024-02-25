using Microsoft.EntityFrameworkCore;

namespace Database.DbConnection
{
    public class GenericRepo<T> where T : class
    {
        // Klass som har direktkontakt med databasen via dbcontext och returnerar data med hjälp av ett DbSet. 

        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;


        public GenericRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        // Hitta model med ID
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        // Lägg till model
        public void Add(T entity)
        {
            _dbSet.Add(entity);
            Complete();
        }

        // Delete model med ID
        public void Delete(int id)
        {
            T? entityToDelete = GetById(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        // Spara ändringar
        public void Complete()
        {
            _context.SaveChanges();
        }
    }

}
