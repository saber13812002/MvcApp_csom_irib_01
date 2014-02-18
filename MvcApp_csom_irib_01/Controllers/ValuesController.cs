using Microsoft.SharePoint.Client;
using MvcApp_csom_irib_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SP = Microsoft.SharePoint.Client;
using System.Net;
using Microsoft.SharePoint.Client;



namespace MvcApp_csom_irib_01.Controllers
{

    // GET irib/setNewItem/user/passwordaA1/Tasks/title/body/
    public class setNewItemController : ApiController
    {
        // GET irib/setNewItem/user/passwordaA1/Tasks/title/body/
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET irib/setNewItem/user/passwordaA1/Tasks/title/body/
        public string Get(string user,string password,string id,string id1,string id2)
        {
            sharepoint shp = new sharepoint();

            string siteUrl = shp.servername; 

            //ClientContext clientContext = new ClientContext(siteUrl);
            //SP.List oList = clientContext.Web.Lists.GetByTitle(id);


            using (ClientContext context = new ClientContext(siteUrl))
            {
                context.Credentials = new NetworkCredential(user, password, "mesbahsoft.local");

                SP.List oList = context.Web.Lists.GetByTitle(id);
                //context.ExecuteQuery();


                ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                ListItem oListItem = oList.AddItem(itemCreateInfo);
                oListItem["Title"] = id1;
                oListItem["Body"] = id2;

                oListItem.Update();

                context.ExecuteQuery();

            }
            return "task with name " + id1 + " with body " + id2 + " created";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }


    // GET irib/getItemDoc/user/passwordaA1/Tasks/
    public class getItemDocController : ApiController
    {
        // GET irib/getItem/user/passwordaA1/Tasks/
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string user, string password, string id)
        {
            sharepoint shp = new sharepoint();

            string str = "";
            string siteUrl = shp.servername;

            //ClientContext clientContext = new ClientContext(siteUrl);
            //SP.List oList = clientContext.Web.Lists.GetByTitle(id);


            using (ClientContext context = new ClientContext(siteUrl))
            {
                context.Credentials = new NetworkCredential(user, password, "mesbahsoft.local");

                SP.List oList = context.Web.Lists.GetByTitle(id);
                //context.ExecuteQuery();


                //ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                //ListItem oListItem = oList.AddItem(itemCreateInfo);
                //oListItem["Title"] = id1;
                //oListItem["Body"] = id2;

                context.Load(oList);
                context.ExecuteQuery();
                //list.TemplateFeatureId.ToString().Equals("") &&
                string baseType = oList.BaseType.ToString();
                string listTitle = oList.Title.ToString();
                if (oList.BaseType.ToString().Equals("DocumentLibrary", StringComparison.InvariantCultureIgnoreCase) && oList.Title.ToString().Equals(id, StringComparison.InvariantCultureIgnoreCase))
                {
                    foreach (Folder subFolder in oList.RootFolder.Folders)
                    {
                        foreach (File f in subFolder.Files)
                        {
                            str += f.Title.ToString();
                        }
                    }
                }

            }
            return str;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    // GET irib/getItem/user/passwordaA1/Tasks/
    public class getItemController : ApiController
    {
        // GET irib/getItem/user/passwordaA1/Tasks/
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET irib/getItem/user/passwordaA1/Tasks/
        public string Get(string user, string password, string id)
        {
            sharepoint shp = new sharepoint();

            string str = "";
            string siteUrl = shp.servername;

            //ClientContext clientContext = new ClientContext(siteUrl);
            //SP.List oList = clientContext.Web.Lists.GetByTitle(id);


            using (ClientContext context = new ClientContext(siteUrl))
            {
                context.Credentials = new NetworkCredential(user, password, "mesbahsoft.local");

                //SP.List oList = context.Web.Lists.GetByTitle(id);
                //context.ExecuteQuery();
                SP.List oList = context.Web.Lists.GetByTitle(id);
                CamlQuery query = new CamlQuery();
                query.ViewXml =
                   @"<View>
                        <Query>
                            <Where>
                                <IsNull><FieldRef Name='ParentID' /></IsNull>
                            </Where>
                        </Query>
                    </View>";
                ListItemCollection items = oList.GetItems(query);

                //ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();
                //ListItem oListItem = oList.AddItem(itemCreateInfo);
                //oListItem["Title"] = id1;
                //oListItem["Body"] = id2;

                context.Load(oList);
                context.ExecuteQuery();
                //list.TemplateFeatureId.ToString().Equals("") &&
                string baseType = oList.BaseType.ToString();
                string listTitle = oList.Title.ToString();
                if (oList.BaseType.ToString().Equals("GenericList", StringComparison.InvariantCultureIgnoreCase) && oList.Title.ToString().Equals(id, StringComparison.InvariantCultureIgnoreCase))
                {
                    foreach (Folder subFolder in oList.RootFolder.Folders)
                    {
                        foreach (File f in subFolder.Files)
                        {
                            str += f.Title.ToString();
                        }
                    }
                }

            }
            return str;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}