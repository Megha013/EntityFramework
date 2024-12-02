namespace EntityFramework.Models
{
    public class UsersCrud
    {
        private readonly ApplicationDbContext db;
        public UsersCrud(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        public int ValidateUsers(Users user)
        {
            var existingUser = db.Users.FirstOrDefault(u => u.UserId == user.UserId && u.Password == user.Password);

            return existingUser != null ? existingUser.UserId : 0;
        }
        public int AddUsers(Users user)
        {
            int result = 0;
            db.Users.Add(user);  
            result = db.SaveChanges();
            return result;
        }
    }
}
