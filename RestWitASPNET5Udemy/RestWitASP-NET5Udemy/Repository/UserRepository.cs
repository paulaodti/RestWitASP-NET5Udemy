using RestWitASP_NET5Udemy.Data.VO;
using RestWitASP_NET5Udemy.Model;
using RestWitASP_NET5Udemy.Model.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RestWitASP_NET5Udemy.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidadeCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName && u.Password == pass));
        }
        
        public User ValidadeCredentials(string userName)
        {
            return _context.Users.SingleOrDefault(u => (u.UserName == userName));
        }
        public bool RevokeToken(string userName)
        {
            var user = ValidadeCredentials(userName);
            if (user == null)
                return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }
        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public User RefreshUserInfo(User user)
        {
            var _item = _context.Users.SingleOrDefault(u => u.Id.Equals(user.Id));
            if (_item == null)
                return null;
            try
            {
                _context.Entry(_item).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }
    }
}
