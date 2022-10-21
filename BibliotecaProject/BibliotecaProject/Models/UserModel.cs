namespace BibliotecaProject.Models
{
    public class UserModel
    {
        public User user { get; set; }
        public IEnumerable<Loan> getLoanData { get; set; }
    }
}
