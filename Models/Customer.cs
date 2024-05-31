namespace WebApi_SqlServer.Models
{
    public class Customer
    {
        public int customerID { get; set; }
        public string fname { get; set; } = "";
        public string mname { get; set; } = "";
        public string lname { get; set; } = "";
        public string address { get; set; } = "";
        public string contact { get; set; } = "";
    }
}
