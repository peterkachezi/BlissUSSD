using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;


namespace USSDBliss.Controllers
{
    [RoutePrefix("application/services")] // Your Application will be served as http(s)://<host>:port/application/services/...
    public class USSDServiceController : ApiController
    {
        [Route("ussdservice")]  // http(s)://<host>:port/application/services/ussdservice
        [HttpPost, ActionName("ussdservice")]

        public HttpResponseMessage httpResponseMessage([FromBody] UssdResponse ussdResponse)
        {
            HttpResponseMessage responseMessage;
            string response;

            if (ussdResponse.text == null)
            {
                ussdResponse.text = "";
            }

            if (ussdResponse.text.Equals("", StringComparison.Ordinal))
            {
                response = "CON Welcome to Bliss Medical Centre\n";             
                response += "1.Find a clinic\n";
                response += "2.Book Telemedicine\n";
                response += "3.Feedback / Complaint\n";
                response += "4.Helpline\n";
                response += "5.Exit";


            }
            else if (ussdResponse.text.Equals("1", StringComparison.Ordinal))
            {
                response = "END I am doing something \n";
            }
            else if (ussdResponse.text.Equals("2", StringComparison.Ordinal))
            {
                response = "END Some other thing has been done \n";
            }
            else if (ussdResponse.text.Equals("3", StringComparison.Ordinal))
            {
                response = $"END Here is your phone number : {ussdResponse.phoneNumber} \n";
            }
            else
            {
                response = "END Invalid option \n";
            }

            responseMessage = Request.CreateResponse(HttpStatusCode.Created, response);

            responseMessage.Content = new StringContent(response, Encoding.UTF8, "text/plain");

            return responseMessage;
        }
    }
}
