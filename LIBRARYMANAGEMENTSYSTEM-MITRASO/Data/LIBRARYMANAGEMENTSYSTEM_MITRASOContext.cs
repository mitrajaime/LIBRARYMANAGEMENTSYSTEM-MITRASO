using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Models;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Data
{
    public class LIBRARYMANAGEMENTSYSTEM_MITRASOContext : DbContext
    {
        public LIBRARYMANAGEMENTSYSTEM_MITRASOContext (DbContextOptions<LIBRARYMANAGEMENTSYSTEM_MITRASOContext> options)
            : base(options)
        {
        }

        public DbSet<LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.User> User { get; set; } = default!;

        public DbSet<LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.Penalty>? Penalty { get; set; }

        public DbSet<LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.Books>? Books { get; set; }

        public DbSet<LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.Borrower>? Borrower { get; set; }

        public DbSet<LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.BorrowingRecords>? BorrowingRecords { get; set; }
        

        public DbSet<LIBRARYMANAGEMENTSYSTEM_MITRASO.Models.BookCategory>? BookCategory { get; set; }
    }
}
