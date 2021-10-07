using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campeonato.Entities;

namespace campeonato.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }

    public class UserService : IUserService
    {        
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "selecao2020", Password = "rubyonrails" }
        };

        public async Task<User> Authenticate(string username, string password)
        {           
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));
            
            if (user == null)
                return null;
           
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {            
            return await Task.Run(() => _users);
        }
    }
}