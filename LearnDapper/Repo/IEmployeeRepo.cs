using LearnDapper.Model;

namespace LearnDapper.Repo
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAll();
    }
}
