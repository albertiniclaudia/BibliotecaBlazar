﻿using BibliotecaProject.Database;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace BibliotecaProject.Models
{
    public class UserModel
    {
        
        public User user { get; set; }

        public IEnumerable<Loan> getLoanData { get; set; }

    }
}
