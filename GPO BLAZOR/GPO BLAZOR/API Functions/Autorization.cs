using DBAgent;
using GPO_BLAZOR.DBAgents;

namespace GPO_BLAZOR.API_Functions
{
    public class Autorization
    {
        public record AutorizationDate
        {
            public string login { get; init; }
            public string Password { get; init; }
        }

        static public async Task<bool> checkuser(AutorizationDate Date, Gpo2Context contex)
        {
            return (contex.Users
                        .Where(x => (x.Email == Date.login && x.Password == Date.Password))
                        .FirstOrDefault() is not null);
        }
    }
}
