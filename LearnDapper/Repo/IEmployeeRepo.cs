using LearnDapper.Model;

namespace LearnDapper.Repo
{
    public interface IEmployeeRepo
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetOneById(int emp_id);
        Task<string> Create(Employee employee);
        Task<string> Update(Employee employee, int emp_id);
        Task<string> Remove(int emp_id);
    }
}
