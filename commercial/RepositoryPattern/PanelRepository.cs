using dbProject.Models;

namespace commercial.RepositoryPattern
{
    public class PanelRepository : IRepositoryPattern<Panel>
    {
        public readonly DatabaseContext _dbContext;   
        public PanelRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Panel? GetById(int panelId){
           return _dbContext.Panels.FirstOrDefault(p => p.UserId == panelId);
        }
        public IEnumerable<Panel> GetAll(){
            return _dbContext.Panels.ToList();
        }
        public void Add(Panel panel){
            _dbContext.Panels.Add(panel);
        }
        public void Update(Panel panel){
            _dbContext.Panels.Update(panel);
        }
        public void Delete(Panel panel){
            _dbContext.Panels.Remove(panel);
        }
    }
}