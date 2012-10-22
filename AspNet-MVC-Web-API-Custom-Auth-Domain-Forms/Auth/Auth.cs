using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Security;
using System.Text;
using System.DirectoryServices;


namespace App.Utils
{

    public class DomainFormsAuth : System.Web.Http.AuthorizeAttribute
    {
        public DomainFormsAuth() { }

        public string UserID { get; set; }
        private bool isAuth = false;
        private bool isDomain;
        private bool isForms;

        public override void OnAuthorization(HttpActionContext actionContext)
        {

            //check for windows identity, you could also use the helper Method below (AuthenicateUser)
            if (System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString() != "" )
            {
                isAuth = true;
                isDomain = true;
                Debug.WriteLine("Domain Authenicated");
            }
            else // if not , check if the user is web forms authenicated, this is where you can check query your users database or use facebook or oAth checks
            {
                if (1==1){ //query your db here to see if the user is legit
                    isAuth = true;
                    isForms = true;
                    Debug.WriteLine("Forms Authenicated");
                } 
            }


            //authenicated
            if (isAuth)
            {
                Debug.WriteLine("You're authenicated");

            }
            else // not authenicated
            {
                // 417 - so we can specify a message
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
                actionContext.Response.ReasonPhrase = "User is not domain or forms authenicated ";
            }

        }

        public class HandleExceptionAttribute : ExceptionFilterAttribute
        {
            public override void OnException(HttpActionExecutedContext actionExecutedContext)
            {
                if (actionExecutedContext.Exception != null)
                {
                    var exception = actionExecutedContext.Exception;
                    var response = new HttpResponseMessage();
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.ReasonPhrase = exception.Message;
                    actionExecutedContext.Response = response;
                }
            }
        }

        //you can use this helper method if you need the user to use a differnt domain credential than what he is logged in as
        private bool AuthenicateUser(String path, String user, String pass)
        {
            DirectoryEntry de = new DirectoryEntry(path, user, pass, AuthenticationTypes.Secure);

            try
            {
                //run a search using those credentials.  
                //If it returns anything, then you're authenticated
                DirectorySearcher ds = new DirectorySearcher(de);
                ds.FindOne();
                return true;
            }
            catch
            {
                //otherwise, it will crash out so return false
                return false;
            }
            
            
        }

    }
}