using RestWitASP_NET5Udemy.Data.VO;

namespace RestWitASP_NET5Udemy.Business.Interfaces
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
        bool RevokeToken(string userName);
    }
}
