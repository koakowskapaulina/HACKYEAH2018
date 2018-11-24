using BE.ApiModels;
using BE.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BE.Services
{
    public interface IUserService
    {
        User CheckUserCredentials(string email, string password);
        IEnumerable<User> GetUsers();
    }

    public class UserService : IUserService
    {
        BazkaContext database;

        public UserService(BazkaContext _databaseContext)
        {
            database = _databaseContext;
        }

        public User CheckUserCredentials(string email, string password)
        {
            try
            {
                string pass = CalculateMD5Hash(password);
                return database.Users.Where(u => u.Email == email && u.Password == pass).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return database.Users.ToList();
        }

        public string CalculateMD5Hash(string input)

        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

    }
}
