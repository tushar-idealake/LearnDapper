using LearnDapper.Model.Data;
using LearnDapper.Model;
using Dapper;
using System.Data;

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

        async Task<string> IEmployeeRepo.Create(Employee employee)
        {
            string response = string.Empty;
            string query = "INSERT INTO hcm.employees (first_name,middle_name,last_name,job_id,salary,birth_date,hire_date,department_id,manager_id,phone,street_address,city,state_province,postal_code,country_id,termination_date) VALUES (@first_name,@middle_name,@last_name,@job_id,@salary,@birth_date,@hire_date,@department_id,@manager_id,@phone,@street_address,@city,@state_province,@postal_code,@country_id,@termination_date)";
            var parameters = new DynamicParameters();
            parameters.Add("first_name", employee.first_name, DbType.String);
            parameters.Add("middle_name", employee.middle_name, DbType.String);
            parameters.Add("last_name", employee.last_name, DbType.String);
            parameters.Add("job_id", employee.job_id, DbType.Int32);
            parameters.Add("salary", employee.salary, DbType.Int32);
            parameters.Add("birth_date", employee.birth_date, DbType.String);
            parameters.Add("hire_date", employee.hire_date, DbType.String);
            parameters.Add("department_id", employee.department_id, DbType.Int32);
            parameters.Add("manager_id", employee.manager_id, DbType.Int32);
            parameters.Add("phone", employee.phone, DbType.String);
            parameters.Add("street_address", employee.street_address, DbType.String);
            parameters.Add("city", employee.city, DbType.String);
            parameters.Add("state_province", employee.state_province, DbType.String);
            parameters.Add("postal_code", employee.postal_code, DbType.String);
            parameters.Add("country_id", employee.country_id, DbType.Int32);
            parameters.Add("termination_date", employee.termination_date, DbType.String);

            using (var connection = this.context.CreateConnection())
            {
                var emp = await connection.ExecuteAsync(query, parameters);
                response = "Executed INSERT Query";
            }
            return response;
        }

        async Task<Employee> IEmployeeRepo.GetOneById(int emp_id)
        {
            string query = "SELECT * FROM hcm.employees where employee_id=@emp_id";
            using (var connection = this.context.CreateConnection())
            {
                var emp = await connection.QueryFirstOrDefaultAsync<Employee>(query, new { emp_id });
                return emp;
            }
        }

        async Task<string> IEmployeeRepo.Remove(int emp_id)
        {
            string response = string.Empty;
            string query = "DELETE FROM hcm.employees where employee_id=@emp_id";
            using (var connection = this.context.CreateConnection())
            {
                var emp = await connection.ExecuteAsync(query, new { emp_id });
                response = "Executed DELETE Query";
            }
            return response;
        }

        async Task<string> IEmployeeRepo.Update(Employee employee, int emp_id)
        {
            string response = string.Empty;
            string query = "UPDATE hcm.employees set first_name=@first_name, middle_name=@middle_name, last_name=@last_name, job_id=@job_id, salary=@salary, birth_date=cast(@birth_date AS datetime), hire_date=@hire_date, department_id=@department_id, manager_id=@manager_id, phone=@phone, street_address=@street_address, city=@city, state_province=@state_province, postal_code=@postal_code, country_id=@country_id, termination_date=@termination_date WHERE employee_id=@employee_id";
            var parameters = new DynamicParameters();
            parameters.Add("employee_id", employee.employee_id, DbType.Int32);
            parameters.Add("first_name", employee.first_name, DbType.String);
            parameters.Add("middle_name", employee.middle_name, DbType.String);
            parameters.Add("last_name", employee.last_name, DbType.String);
            parameters.Add("job_id", employee.job_id, DbType.Int32);
            parameters.Add("salary", employee.salary, DbType.Int32);
            parameters.Add("birth_date", employee.birth_date, DbType.String);
            parameters.Add("hire_date", employee.hire_date, DbType.String);
            parameters.Add("department_id", employee.department_id, DbType.Int32);
            parameters.Add("manager_id", employee.manager_id, DbType.Int32);
            parameters.Add("phone", employee.phone, DbType.String);
            parameters.Add("street_address", employee.street_address, DbType.String);
            parameters.Add("city", employee.city, DbType.String);
            parameters.Add("state_province", employee.state_province, DbType.String);
            parameters.Add("postal_code", employee.postal_code, DbType.String);
            parameters.Add("country_id", employee.country_id, DbType.Int32);
            parameters.Add("termination_date", employee.termination_date, DbType.String);

            using (var connection = this.context.CreateConnection())
            {
                var emp = await connection.ExecuteAsync(query, parameters);
                response = "Executed UPDATE Query";
            }
            return response;
        }
    }
}
