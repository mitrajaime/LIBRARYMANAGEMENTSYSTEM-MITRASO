﻿using LIBRARYMANAGEMENTSYSTEM_MITRASO.Models;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.ViewModels
{
    public class BorrowingTransactionVM
    {
        public List<BorrowingRecords> BorrowingRecordsData { get; set; }
        
        public List<Borrower> BorrowerData { get; set; }
        public List<Books> BooksData { get; set; }
        public List<Penalty> PenaltyData { get; set; }
        
    }
}
