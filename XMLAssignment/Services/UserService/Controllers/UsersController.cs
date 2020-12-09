using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IList<User> users = new List<User>();
        private XmlDocument doc;
        private XmlNode root;
        private static string docPath = "user.xml";

        public UsersController()
        {
            doc = new XmlDocument();
            doc.Load(docPath);
            root = doc.DocumentElement;
            XmlNodeList userList = root.ChildNodes;

            for (int index = 0; index < userList.Count; index++)
            {
                users.Add(new User()
                {
                    id = int.Parse(userList[index].ChildNodes[0].InnerText),
                    username = userList[index].ChildNodes[1].InnerText,
                    password = userList[index].ChildNodes[2].InnerText
                });
            }
        }

        // GET api/users/5
        [HttpGet("{username}")]
        public ActionResult<User> Get(string username)
        {
            User user = null;
            try
            {
                user = users.First(u => u.username == username);
            }
            catch (Exception e)
            {
            }
            
            if (user == null)
            {
                return null;
            }
            return Ok(user);
        }

        // POST api/users
        [HttpPost]
        public void Post([FromBody]User user)
        {
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "User", "");

            XmlNode userId = doc.CreateNode(XmlNodeType.Element, "id", "");
            XmlNode username = doc.CreateNode(XmlNodeType.Element, "username", "");
            XmlNode password = doc.CreateNode(XmlNodeType.Element, "password", "");

            userId.InnerText = Convert.ToString(user.id);
            username.InnerText = user.username;
            password.InnerText = user.password;

            newNode.AppendChild(userId);
            newNode.AppendChild(username);
            newNode.AppendChild(password);

            root.AppendChild(newNode);
            doc.Save(docPath);
        }
    }
}
