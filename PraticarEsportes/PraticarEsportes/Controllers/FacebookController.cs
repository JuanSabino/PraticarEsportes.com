using Facebook;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PraticarEsportes.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PraticarEsportes.Controllers
{
    public class FacebookController : Controller
    {
        Context _db = new Context();

        // GET: Facebook
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkin(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Evento");
            }

            Evento evento = _db.Evento.Include("Local").Where(e => e.ID == id).FirstOrDefault<Evento>();


            string url = "https://graph.facebook.com/search?type=place&center=" + evento.Local.Latitude.ToString().Replace(',','.') + "," + evento.Local.Longitude.ToString().Replace(',', '.') + "&distance=50&access_token=" + Session["FbuserToken"].ToString();
            WebRequest myReq = WebRequest.Create(url);
            WebResponse wr = myReq.GetResponse();
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();

            var json = JObject.Parse(content);



            var _fb = new FacebookClient(Session["FbuserToken"].ToString());
            dynamic parameters = new ExpandoObject();
            parameters.checkin = "http://samples.ogp.me/1728776667407990";
            //parameters.client_id = "1728002444152079";
            //parameters.client_secret = "9a5728d23d39d3c9f45e53682d07526a"
            //parameters.access_token = Session["FbuserToken"].ToString();
            if (json["data"][0]["id"] != null)
            {
                parameters.place = json["data"][0]["id"].ToString();
            }

            try
            {
                _fb.Post("me/praticaresportes:fez_checkin", parameters);
                Session["Checkin"] = 1;
            }
            catch(FacebookOAuthException e)
            {
                Console.Write(e.Message);
            }
            

            return RedirectToAction("Details", "Evento",new { id = id });
        }
    }
}