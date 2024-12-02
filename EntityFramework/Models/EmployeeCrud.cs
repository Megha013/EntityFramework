namespace EntityFramework.Models
{
    public class EmployeeCrud
    {
        private readonly ApplicationDbContext db;
        public EmployeeCrud(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Employee> GetEmployees()
        { 
            return db.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            return db.Employees.Where(x => x.EmpId == id).SingleOrDefault();
        }
        public int AddEmployee(Employee emp)
        {
            int result = 0;
            db.Employees.Add(emp); 
            result = db.SaveChanges();
            return result;
        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            // search the data that we need to modify in the DbSet
            var e = db.Employees.Where(x => x.EmpId == emp.EmpId).SingleOrDefault();
            if (e != null)
            {
                //update new changes
                e.Name = emp.Name;
                e.Email = emp.Email;
                e.Salary = emp.Salary;
                // update the changes to DB
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            // search the data that we need to modify in the DbSet
            var e = db.Employees.Where(x => x.EmpId == id).SingleOrDefault();
            if (e != null)
            {
                //remove from DbSet
                db.Employees.Remove(e);
                // update the changes to DB
                result = db.SaveChanges();
            }
            return result;
        }
    }
}