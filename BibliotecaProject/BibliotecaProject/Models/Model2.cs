using BibliotecaProject.Database;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace BibliotecaProject.Models
{
    public class Model2
    {
        public User User { get; set; }
		public IEnumerable<Loan> Loans { get; set; }
        public IEnumerable<Book>  Books { get; set; }
        public IEnumerable<Loan> EndedLoans { get; set; }
	}
}
