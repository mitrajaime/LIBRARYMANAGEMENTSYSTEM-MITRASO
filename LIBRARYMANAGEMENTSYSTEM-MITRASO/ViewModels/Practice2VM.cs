using Humanizer;
using LIBRARYMANAGEMENTSYSTEM_MITRASO.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.ViewModels
{
    public class Practice2VM
    {
        public string Name { get; set; } = string.Empty;
        public List<Books> BookData {  get; set; }
        public List<User> UserData { get; set; }
        public int SelectedCourse { get; set; }
    }
}
