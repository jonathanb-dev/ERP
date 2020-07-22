using DL.Entities;

namespace DL.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public AppUser AppUser { get; set; }
    }
}