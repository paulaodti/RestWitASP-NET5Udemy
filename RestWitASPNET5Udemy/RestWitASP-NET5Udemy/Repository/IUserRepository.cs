using RestWitASP_NET5Udemy.Data.VO;
using RestWitASP_NET5Udemy.Model;

namespace RestWitASP_NET5Udemy.Repository
{
    public interface IUserRepository
    {
        User ValidadeCredentials(UserVO user);
        User ValidadeCredentials(string userName);
        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);
    }
}
