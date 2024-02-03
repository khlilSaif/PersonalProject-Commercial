using commercial;
using commercial.RepositoryPattern;
using commercial.Secyrity;

public class AuthRepository : IRepositoryPattern<AuthenticationToken>
{
        private readonly DatabaseContext _databaseContext; 
        public AuthRepository(DatabaseContext databaseContext){
              _databaseContext = databaseContext;
        }
        public AuthenticationToken? GetById(int id){
            return _databaseContext.AuthenticationTokens.Find(id);
        }

        public IEnumerable<AuthenticationToken> GetAll(){
            return _databaseContext.AuthenticationTokens.ToList();
        }
        public void Add(AuthenticationToken authenticationToken){
            _databaseContext.AuthenticationTokens.Add(authenticationToken);
            _databaseContext.SaveChanges();
        }
        public void Update(AuthenticationToken authenticationToken){
            _databaseContext.AuthenticationTokens.Update(authenticationToken);
            _databaseContext.SaveChanges();
        }
        public void Delete(AuthenticationToken authenticationToken){
            _databaseContext.AuthenticationTokens.Remove(authenticationToken);
            _databaseContext.SaveChanges();
        }
}
