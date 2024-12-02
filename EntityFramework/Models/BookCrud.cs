namespace EntityFramework.Models
{
    public class BookCrud
    {
        private readonly ApplicationDbContext db;
        public BookCrud(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Book> GetBooks()
        {
            // LINQ
            //var result = from e in db.Employees
            //             select e;
            //return result;

            // Lambda
            return db.Books.ToList();
        }
        public Book GetBookById(int id)
        {
            //LINQ
            //var result= (from e in db.Employees
            //            where e.EmpId==id
            //            select e).SingleOrDefault();
            //return result;

            // Lambda
            return db.Books.Where(x => x.BookId == id).SingleOrDefault();
        }
        public int AddBook(Book book)
        {
            int result = 0;
            // add data in the DbSet 
            db.Books.Add(book);  // Add() will add emp object in the DbSet
            // update changes to Db
            result = db.SaveChanges();
            return result;
        }
        public int UpdateBook(Book book)
        {
            int result = 0;
            // search the data that we need to modify in the DbSet
            var b = db.Books.Where(x => x.BookId == book.BookId).SingleOrDefault();
            if (b != null)
            {
                //update new changes
                b.Name = book.Name;
                b.Author = book.Author;
                b.Category = book.Category;
                b.Price = book.Price;
                // update the changes to DB
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteBook(int id)
        {
            int result = 0;
            // search the data that we need to modify in the DbSet
            var b = db.Books.Where(x => x.BookId == id).SingleOrDefault();
            if (b != null)
            {
                //remove from DbSet
                db.Books.Remove(b);
                // update the changes to DB
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
