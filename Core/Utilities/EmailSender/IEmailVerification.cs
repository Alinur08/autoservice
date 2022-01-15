using System;
using System.Collections.Generic;
using System.Text;

namespace Core1.Utilities.EmailSender
{
    public interface IEmailVerification
    {
        void SendCode(MailContext mailContext, string mail, string code);
        bool Verify(char[] code,char[] checkCode);
    }
}
