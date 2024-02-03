using dbProject.Models;

namespace commercial.RepositoryPattern
{
    public class UserRepository : IRepositoryPattern<User>, IRepository<User>
    {
        private readonly DatabaseContext _databaseContext; 
        public UserRepository(DatabaseContext databaseContext){
              _databaseContext = databaseContext;
        }
        public User? GetById(int id){
            return _databaseContext.Users.Find(id);
        }

        public User? GetByEmail(string email){
            return _databaseContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public IEnumerable<User> GetAll(){
            try
            {
                return _databaseContext.Users.ToList();
            }
            catch (Exception ex)
            {
                // Log or print the exception to diagnose the issue
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public void Add(User user){
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }
        public void Update(User user){
            _databaseContext.Users.Update(user);
            _databaseContext.SaveChanges();
        }
        public void Delete(User user){
            _databaseContext.Users.Remove(user);
            _databaseContext.SaveChanges();
        }
    }
}