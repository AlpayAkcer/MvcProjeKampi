using EntityLayer.DTO;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void AdminRegister(string adminMail, string password);
        bool AdminLogin(AdminLogInDto loginDto);
        void WriterRegister(string mail, string password);
        bool WriterLogin(WriterLogInDto writerLoginDto);
    }
}