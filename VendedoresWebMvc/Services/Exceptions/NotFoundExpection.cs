using System.Configuration;

namespace VendedoresWebMvc.Services.Exceptions
{
    public class NotFoundExpection: ApplicationException
    {
        public NotFoundExpection(string message):base (message) 
        { }
    }
}
