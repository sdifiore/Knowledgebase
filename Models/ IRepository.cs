namespace KnowledgeBase.Models
{
    public interface IRepository
    {
        IEnumerable<Framework> GetFrameworks();
   
    }
}