namespace Test_e.Server.Models
{
    public class ApiErrorResponse
    {
        public string Title { get; set; }     // e.g., "Bad Request"
        public int Status { get; set; }       // HTTP status code
        public string Detail { get; set; }    // Description of the error
        public string Instance { get; set; }  // Request path

    }
}
