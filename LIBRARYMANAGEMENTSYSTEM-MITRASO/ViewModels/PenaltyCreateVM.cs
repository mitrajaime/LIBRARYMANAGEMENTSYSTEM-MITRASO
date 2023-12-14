using LIBRARYMANAGEMENTSYSTEM_MITRASO.Models;

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.ViewModels
{
    public class PenaltyCreateVM
    {
        public List<BorrowingRecords> BorrowingRecordsData { get; set; }
        public List<Penalty> PenaltyData { get; set; }
    }
}
