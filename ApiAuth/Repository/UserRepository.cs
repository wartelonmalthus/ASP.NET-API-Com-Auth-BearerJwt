using System.Collections.Generic;
using System.Linq;
using ApiAuth.Models;

namespace ApiAuth.Repository
{
    public class UserRepository
    {
        public static User Get (string username, string password){
            
            var users = new List<User>{
                new () {Id = 1, Username = "Joao", Password = "123", Role = "Gerente"},
                new () {Id = 1, Username = "Luiz", Password = "123", Role = "Vendedor"}
                
            };

            return (User)users.Where(x=> x.Username.ToLower() == username.ToLower() && x.Password == password);

            

        }
    }
}