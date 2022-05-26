namespace KnowledgeBase.Models
{
    public interface IRepository
    {
        IEnumerable<Framework> GetAllFrameworks();
   
    }
}