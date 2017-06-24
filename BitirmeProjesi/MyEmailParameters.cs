using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitirmeProjesi
{
    public class MyEmailParameters
    {
        private String fromEmail;
        private String passwordEmail;
        private int portEmail;
        private String smtpServer;

        public MyEmailParameters()
        {

        }

        public MyEmailParameters(String fromEmail, String passwordEmail, int portEmail,String smtpServer)
        {
            this.fromEmail = fromEmail;
            this.passwordEmail = passwordEmail;
            this.portEmail = portEmail;
            this.smtpServer = smtpServer;
        }


        public String FromEmail
        {
            set { fromEmail = value; }
            get { return fromEmail; }
        }

        public String PasswordEmail
        {
            set { passwordEmail = value; }
            get { return passwordEmail; }
        }


        public int PortEmail
        {
            set { portEmail = value; }
            get { return portEmail; }
        }
        public String SmtpServer
        {
            set { smtpServer = value; }
            get { return smtpServer; }
        }
        

    }
}