using Ninesky.DAL;
using Ninesky.IBLL;
using Ninesky.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace Ninesky.BLL
{
    public class UserService : BaseService<User>, InterfaceUserService
    {
        public UserService() : base(RepositoryFactory.UserPrository)
        {
        }

        public ClaimsIdentity CreateIdentity(User user, string authenticationType)
        {
            try
            {
                ClaimsIdentity _identity = new ClaimsIdentity("ApplicationCookie");
                _identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()));
                _identity.AddClaim(new Claim("DisplayName", user.DisplayName));
                return _identity;
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public bool Exist(string Name)
        {
            return CurrentRepository.Exist(u => u.UserName == Name);
        }

        public User Find(string userName)
        {
            return CurrentRepository.Find(u => u.UserName == userName);
        }

        public User Find(int UserId)
        {
            return CurrentRepository.Find(u => u.UserID == UserId);
        }

        public IQueryable<User> FindPageList(int pageIndex, int pageSize, out int totalRecord, int order)
        {
            bool _isAsc = true;
            string _orderName = string.Empty;
            switch (order)
            {
                case 0:
                    _isAsc = true;
                    _orderName = "UserID";
                    break;

                case 1:
                    _isAsc = false;
                    _orderName = "UserID";
                    break;

                case 2:
                    _isAsc = true;
                    _orderName = "RegistrationTime";
                    break;

                case 3:
                    _isAsc = false;
                    _orderName = "RegistrationTime";
                    break;

                case 4:
                    _isAsc = true;
                    _orderName = "LoginTime";
                    break;

                case 5:
                    _isAsc = false;
                    _orderName = "LoginTime";
                    break;

                default:
                    _isAsc = false;
                    _orderName = "UserID";
                    break;
            }
            return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, u => true, _orderName, _isAsc);
        }
    }
}