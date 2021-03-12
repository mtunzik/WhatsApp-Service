using ThanosApp.API.Models;
namespace ThanosApp.API.Models
{
    public class NavBar
    {
        public int Id { get; set; }
        public string UId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CssClass { get; set; }
        public string HRef { get; set; }
        public SubIcon SubIcon { get; set; }
        public SubImage SubImage { get; set; }
    }
}