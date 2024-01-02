using LearnDapper.Model.Data;
using LearnDapper.Model;
using Dapper;

namespace LearnDapper.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {

        private readonly DapperDBContext context;

        public EmployeeRepo(DapperDBContext context)
        {
            this.context = context;
        }
        public async Task<List<Employee>> GetAll()
        {
            string query = "SELECT * FROM hcm.employees";
            using (var connection = this.context.CreateConnection())
            {
                var emplist = await connection.QueryAsync<Employee>(query);
                return emplist.ToList();
            }
        }
    }
}
