using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TkChatBot_Database;

namespace TkChatbot_APIClient
{
    public partial class APIClientSettings : TkChatBotPlugin_Base.BotPluginTemplate
    {
        public TinyExe.Context expressionContextMain;

        #region "UI Handlers"

        public APIClientSettings()
        {
            InitializeComponent();
            
        }

        

        private void APIClientSettings_Load(object sender, EventArgs e)
        {
            //Lets load up the API list
            refresh_EndpointList();
            
        }

        private void refresh_EndpointList()
        {
            using (TkChatBot_Database.DatabaseEntities db = new TkChatBot_Database.DatabaseEntities())
            {
                TkChatBot_Database.UserAttribute attrib = db.UserAttributes.Where(x => x.UserName == ".api" && x.Key == "List").FirstOrDefault();

                //Check if we have a list, create one if not
                if (attrib == null)
                {
                    attrib = new TkChatBot_Database.UserAttribute();
                    attrib.UserName = ".api";
                    attrib.Key = "List";
                    attrib.Value = "";
                    db.Entry(attrib).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }

                //Now that we have it, lets split it
                EndpointList.Items.Clear();
                EndpointList.Items.AddRange(attrib.Value.Split("\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

                //Also, refresh the action list
                refresh_EndpointActions();
            }
        }

        private void Endpoint_Add_Click(object sender, EventArgs e)
        {
            //Ask for the endpoint name
            InputBoxResult response = InputBox.Show("Please provide a name for the Endpoint","Add API Endpoint");

            //If response was a cancel, do nothing
            if (response.ReturnCode == DialogResult.Cancel)
                return;

            //First, lets see if this is already in the list
            if (EndpointList.Items.Contains(response.Text) == true)
            {
                //Let the user know it should be unique
                MessageBox.Show("Sorry, endpoint names must be unique!", "Add Endpoint error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string epname = response.Text;

            //Seems fine, lets append it
            using (TkChatBot_Database.DatabaseEntities db = new TkChatBot_Database.DatabaseEntities())
            {
                TkChatBot_Database.UserAttribute attrib = db.UserAttributes.Where(x => x.UserName == ".api" && x.Key == "List").FirstOrDefault();

                //Check if we got the endpoint list. Make it if not, update it if so
                if (attrib == null)
                {
                    attrib = new TkChatBot_Database.UserAttribute();
                    attrib.UserName = ".api";
                    attrib.Key = "List";
                    attrib.Value = "\r" + epname;
                    db.Entry(attrib).State = System.Data.Entity.EntityState.Added;
                } else
                {

                    //Do the append
                    attrib.Value += "\r" + epname ;
                    //Set it as changed
                    db.Entry(attrib).State = System.Data.Entity.EntityState.Modified;

                }
                    

                //Also generate the endpoint attributes
                foreach (string epattrib in (new string[] { "URL","Headers","Description","List" }) )
                {
                    UserAttribute n = new UserAttribute();
                    n.UserName = ".api." + epname;
                    n.Key = epattrib;
                    n.Value = "";

                    db.Entry(n).State = System.Data.Entity.EntityState.Added;
                }

                //And save everything
                db.SaveChanges();
            }

            //Always refresh the list
            refresh_EndpointList();
            EndpointList.SelectedIndex = EndpointList.Items.Count - 1;
        }

        private void EndpointList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Refresh the actions list
            refresh_EndpointActions();

        }

        private void refresh_EndpointActions()
        {

            //Clear out the action list
            endpointActionList.Items.Clear();
            //If we don't have an endpoint selected, that's all 
            if (EndpointList.SelectedItem == null)
                return;

            using (TkChatBot_Database.DatabaseEntities db = new TkChatBot_Database.DatabaseEntities())
            {
                TkChatBot_Database.UserAttribute attrib = db.UserAttributes.Where(x => x.UserName == ".api." + EndpointList.SelectedItem.ToString() && x.Key == "List").FirstOrDefault();

                //Check if we have a list, create one if not (should never happen)
                if (attrib == null)
                {
                    attrib = new TkChatBot_Database.UserAttribute();
                    attrib.UserName = ".api." + EndpointList.SelectedItem.ToString();
                    attrib.Key = "List";
                    attrib.Value = "";
                    db.Entry(attrib).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                }

                //Add the default item
                endpointActionList.Items.Add("[Global]");
                endpointActionList.Items.AddRange(attrib.Value.Split("\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
            }
        }

        private void EndpointAction_Add_Click(object sender, EventArgs e)
        {
            //Don't do anything if no Endpoint is selected
            if (EndpointList.SelectedItem == null)
                return;

            //Ask for the endpoint action name
            InputBoxResult response = InputBox.Show("Please provide a name for the Endpoint Action", "Add API Endpoint");

            //If response was a cancel, do nothing
            if (response.ReturnCode == DialogResult.Cancel)
                return;

            //First, lets see if this is already in the list, or uses the forbidden [Global] name
            if (endpointActionList.Items.Contains(response.Text) == true || response.Text == "[Global]")
            {
                //Let the user know it should be unique
                MessageBox.Show("Sorry, endpoint actions names must be unique!", "Add Endpoint error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string epname = EndpointList.SelectedItem.ToString();
            string epactionname = response.Text;

            //Seems fine, lets append it
            using (TkChatBot_Database.DatabaseEntities db = new TkChatBot_Database.DatabaseEntities())
            {
                TkChatBot_Database.UserAttribute attrib = db.UserAttributes.Where(x => x.UserName == ".api." + epname && x.Key == "List").FirstOrDefault();

                //Do the append
                attrib.Value += "\r" + epactionname;
                //Set it as changed
                db.Entry(attrib).State = System.Data.Entity.EntityState.Modified;

                //Also generate the endpoint action attributes
                foreach (string epattrib in (new string[] { "URL", "Headers", "Description", "Data" }))
                {
                    UserAttribute n = new UserAttribute();
                    n.UserName = ".api." + epname + "." + epactionname;
                    n.Key = epattrib;
                    n.Value = "";

                    db.Entry(n).State = System.Data.Entity.EntityState.Added;
                }

                //And save everything
                db.SaveChanges();
            }

            //Always refresh the list
            refresh_EndpointActions();
        }

        private void endpointActionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Don't do anything if nothings selected...
            if (endpointActionList.SelectedItem == null)
                return;

            //Determine if we're using the special global command or not
            bool globalAttribs = endpointActionList.SelectedItem.ToString() == "[Global]";
            using (TkChatBot_Database.DatabaseEntities db = new TkChatBot_Database.DatabaseEntities())
            {
                List<TkChatBot_Database.UserAttribute> attribs = db.UserAttributes.Where(x => x.UserName == ".api." + EndpointList.SelectedItem.ToString() + (globalAttribs ? "" : "." + endpointActionList.SelectedItem.ToString())).ToList();

                EE_URL.Text = attribs.Where(x => x.Key == "URL").FirstOrDefault().Value;
                EE_Description.Text = attribs.Where(x => x.Key == "Description").FirstOrDefault().Value;
                EE_Headers.Text = attribs.Where(x => x.Key == "Headers").FirstOrDefault().Value;
                if (!globalAttribs) EE_Data.Text = attribs.Where(x => x.Key == "Data").FirstOrDefault().Value;

                //Hide the Data field if it doesn't apply
                EE_Data_Group.Visible = !globalAttribs;


            }
        }

        private void EE_Do_Update_Click(object sender, EventArgs e)
        {
            //Don't do anything if nothings selected...
            if (endpointActionList.SelectedItem == null)
                return;

            //Determine if we're using the special global command or not
            bool globalAttribs = endpointActionList.SelectedItem.ToString() == "[Global]";
            using (TkChatBot_Database.DatabaseEntities db = new TkChatBot_Database.DatabaseEntities())
            {
                List<TkChatBot_Database.UserAttribute> attribs = db.UserAttributes.Where(x => x.UserName == ".api." + EndpointList.SelectedItem.ToString() + (globalAttribs ? "" : "." + endpointActionList.SelectedItem.ToString())).ToList();

                attribs.Where(x => x.Key == "URL").FirstOrDefault().Value = EE_URL.Text;
                attribs.Where(x => x.Key == "Description").FirstOrDefault().Value = EE_Description.Text;
                attribs.Where(x => x.Key == "Headers").FirstOrDefault().Value = EE_Headers.Text ;
                if (!globalAttribs) attribs.Where(x => x.Key == "Data").FirstOrDefault().Value = EE_Data.Text;

                //Let the db know we changed things
                foreach (UserAttribute d in attribs)
                    db.Entry(d).State = System.Data.Entity.EntityState.Modified;

                //And save the changes
                db.SaveChanges();

            }
            MessageBox.Show("Saved.");
        }

        private void EE_Do_Revert_Click(object sender, EventArgs e)
        {
            //To reload, just pretend the selection changed.
            endpointActionList_SelectedIndexChanged(sender, e);
        }

        private void EndpointAction_Remove_Click(object sender, EventArgs e)
        {
            //Don't do anything if nothings selected...
            if (endpointActionList.SelectedItem == null)
                return;

            //Determine if we're using the special global command or not
            if (endpointActionList.SelectedItem.ToString() == "[Global]")
            {
                MessageBox.Show("Sorry, can't delete the Endpoint descriptor.");
                return;
            }

            //Double-check with the user that we want to do this
            string epname = EndpointList.SelectedItem.ToString();
            string epaction = endpointActionList.SelectedItem.ToString();
            if (MessageBox.Show("Are you sure you want to delete the action [" + epaction + "]?") != DialogResult.OK)
                return;

            using (TkChatBot_Database.DatabaseEntities db = new TkChatBot_Database.DatabaseEntities())
            {
                List<TkChatBot_Database.UserAttribute> attribs = db.UserAttributes.Where(x => x.UserName == ".api." + epname + "." + epaction).ToList();

                TkChatBot_Database.UserAttribute attrib = db.UserAttributes.Where(x => x.UserName == ".api." + epname && x.Key == "List").FirstOrDefault();

                //Do the removal
                attrib.Value = String.Join("\r", attrib.Value.Split("\r".ToCharArray()).AsQueryable().Where(x => x != epaction).ToArray());
                //Set it as changed
                db.Entry(attrib).State = System.Data.Entity.EntityState.Modified;

                //Let the db know we should delete things
                foreach (UserAttribute d in attribs)
                    db.Entry(d).State = System.Data.Entity.EntityState.Deleted;

                //And save the changes
                db.SaveChanges();

            }

            //Refresh the actions
            refresh_EndpointActions();

        }

        private void Endpoint_Remove_Click(object sender, EventArgs e)
        {
            //Don't do anything if nothings changed...
            if (EndpointList.SelectedItem == null)
                return;

            //Double-check with the user that we want to do this
            string epname = EndpointList.SelectedItem.ToString();
            if (MessageBox.Show("Are you sure you want to delete the Endpoint [" + epname + "]?", "Delete Endpoint", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            using (TkChatBot_Database.DatabaseEntities db = new TkChatBot_Database.DatabaseEntities())
            {
                //Find all the endpoint attributes and potential actions
                List<TkChatBot_Database.UserAttribute> attribs = db.UserAttributes.Where(x => x.UserName.StartsWith(".api." + epname +".") || x.UserName == ".api." + epname).ToList();

                TkChatBot_Database.UserAttribute attrib = db.UserAttributes.Where(x => x.UserName == ".api" && x.Key == "List").FirstOrDefault();

                //Do the removal
                //var dwavwr = attrib.Value.Split("\r".ToCharArray()).AsQueryable().Where(x => x != epname).ToArray();
                attrib.Value = String.Join("\r",attrib.Value.Split("\r".ToCharArray()).AsQueryable().Where(x=>x != epname).ToArray());
                //Set it as changed
                db.Entry(attrib).State = System.Data.Entity.EntityState.Modified;

                //Let the db know we should delete things
                foreach (UserAttribute d in attribs)
                    db.Entry(d).State = System.Data.Entity.EntityState.Deleted;

                //And save the changes
                db.SaveChanges();

            }

            //Refresh the endpoints
            refresh_EndpointList();

        }
        #endregion

        //Register the commands
        public override void AddToExpressionContext(ref TinyExe.Context theContext)
        {
            base.AddToExpressionContext(ref theContext);
            //Save that reference!
            expressionContextMain = theContext;

            //theContext.Functions.Add("setpermissionlevel", new TinyExe.StaticFunction("SetPermissionLevel", _setPermissionLevel, 2, 2, "Sets the permission level of the given user"));
            //theContext.Functions.Add("getpermissionlevel", new TinyExe.StaticFunction("GetPermissionLevel", _getPermissionLevel, 1, 1, "Gets the permission level of the given user"));
            theContext.Functions.Add("api", new TinyExe.StaticFunction("api", _api, 2, 101, "Enpoint, Action, [$apiData1, $apiData2, etc]. Calls a defined API action. JSON result as a string, sets the variable $apiResult to the result code.", false));
            theContext.Functions.Add("apigjp", new TinyExe.StaticFunction("apiGJP", _apiGetFromJSONPath, 2, 2, "Alias for apiGetFromJSONPath."));
            theContext.Functions.Add("apigetfromjsonpath", new TinyExe.StaticFunction("apiGetFromJSONPath", _apiGetFromJSONPath, 2, 2, "JSON, Path. Returns an element from the JSON string as specified by the given JSON Path statement."));
        }


        private object _api(object[] ps)
        {
            //Push the scope so we can introduce our own variables without screwing with others
            expressionContextMain.PushScope(expressionContextMain.CurrentScope);

            string epname = ps[0].ToString();
            string action = ps[1].ToString();
            //Prep our variables
            string c_BaseURL = "";
            string c_URL = "";
            string c_HeadersDefault = "";
            string C_Headers = "";
            string c_Data = "";
            string result = "";
            int responseCode = 0;


            //Clear out the pushed-scope's $apidata variables (if they exist)
            foreach (KeyValuePair<string, object> variable in (from a in expressionContextMain.CurrentScope where a.Key.StartsWith("$apiData") select a).ToList())
            {
                expressionContextMain.CurrentScope.Remove(variable.Key);
            }

            //Load up passed in data
            for (int counter = 2; counter < ps.Length; counter++)
            {
                expressionContextMain.CurrentScope.Add("$apiData" + (counter - 2), (ps[counter] == null ? "" : ps[counter]).ToString());
            }



            //Lets first make sure the API endpoint and action exist and gather up the parameters
            bool E_NoAction = false;
            using (TkChatBot_Database.DatabaseEntities db = new TkChatBot_Database.DatabaseEntities())
            {
                List<TkChatBot_Database.UserAttribute> globalattribs = db.UserAttributes.Where(x => x.UserName == ".api." + epname).ToList();
                List<TkChatBot_Database.UserAttribute> attribs = db.UserAttributes.Where(x => x.UserName == ".api." + epname + "." + action).ToList();

                //Check that we got both sets of attributes, immediate fail if they don't exist
                if (globalattribs == null || attribs == null)
                    E_NoAction = true;
                else
                {
                    //Gather the attributes we have and set the variables. 
                    c_BaseURL = getAttribValueFromKey(globalattribs, "URL");
                    c_URL = getAttribValueFromKey(attribs, "URL");
                    c_HeadersDefault = getAttribValueFromKey(globalattribs, "Headers");
                    C_Headers = getAttribValueFromKey(attribs, "Headers");
                    c_Data = getAttribValueFromKey(attribs, "Data");

                }
            }


            //Do the substitutions!
            c_URL = templateSubstitution(c_URL);
            c_HeadersDefault = templateSubstitution(c_HeadersDefault);
            C_Headers = templateSubstitution(C_Headers);
            c_Data = templateSubstitution(c_Data);



            //If there was no action or something else went wrong retrieving the action information, just totally skip the request
            if (E_NoAction)
            {
                responseCode = -3;
            }
            else

                //Okay, lets go about setting up the request and executing it
                using (HttpClient client = new HttpClient())
                {
                    //Set the base URL
                    client.BaseAddress = new Uri(c_BaseURL);
                    //Set the timeout to 10 seconds, we don't want to hang the bot for much longer than that...
                    client.Timeout = new TimeSpan(0, 0, 10);

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    //Add the global and custom headers
                    foreach (string header in (c_HeadersDefault + "\r" + C_Headers).Split("\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    {
                        string name, value = "";
                        string[] headerpair = header.Split(": ".ToCharArray());
                        name = headerpair[0];
                        if (headerpair.Length > 1)
                            value = headerpair[1];
                        client.DefaultRequestHeaders.Add(name, value);
                    }


                    HttpResponseMessage response;

                    //Do the request
                    if (c_Data.Length > 0)
                    {
                        StringContent o = new StringContent(c_Data, Encoding.UTF8, "application/json");
                        response = client.PostAsync(c_URL, o).Result;

                    }
                    else
                    {
                        response = client.GetAsync(c_URL).Result;
                    }

                    //Update the result if the request succeeded
                    if (response.IsSuccessStatusCode)
                        result = response.Content.ReadAsStringAsync().Result;

                    responseCode = (int)response.StatusCode;
                }

            //Last, restore the prior context
            expressionContextMain.PopScope();

            //Check if there's already an apiResult variable, and set or reset it accordingly.
            {
                if (!expressionContextMain.CurrentScope.ContainsKey("$apiResult"))
                {
                    expressionContextMain.CurrentScope.Add("$apiResult", responseCode);
                }
                else
                {
                    expressionContextMain.CurrentScope["$apiResult"] = responseCode;
                }
            }

            return result;

        }

        private static string getAttribValueFromKey(List<UserAttribute> attribs, string key)
        {
            //Contrib from @dkf at https://what.thedailywtf.com/post/1008462
            return attribs.Where(x => x.Key == key).Select(x => x.Value).DefaultIfEmpty("").First();

            //Contrib from @Cartmna82 at https://what.thedailywtf.com/post/1008461
            //UserAttribute result1 = attribs.FirstOrDefault(x => x.Key == key);
            //return result1 == null ? "" : result1.Value;

            //My best effort alone at https://what.thedailywtf.com/post/1008458
            //    string result = attribs.Where(x => x.Key == key).Select(x=>x.Value).FirstOrDefault();
            //    if (result == null)
            //        return "";
            //    return result;
            //
        }

        private object _apiGetFromJSONPath(object[] ps)
        {
            //First parameter is the JSON, second is the path requested
            try
            {
                //First interpret the JSON
                JToken o = JToken.Parse(ps[0].ToString());
                
                //Then select the path
                IEnumerable<JToken> r = o.SelectTokens(ps[1].ToString());


                //Give it back if possible
                string result = "";

                if (r != null)
                {
                    result = String.Join("\r", r);
                }

                return result;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            
            
        }

        private string templateSubstitution(string source)
        {
            //#{#([^#}#]+)#}#
            //#{#((?(?!#}#)(.|\n))*)#}#
            var rex = new Regex(@"#{#(.*)#}#", RegexOptions.Multiline);
            return rex.Replace(source, delegate (Match m)
            {
                string exp = m.Groups[1].Value;

                //Create the eval and execute it
                TinyExe.Expression eval = new TinyExe.Expression(exp, expressionContextMain);
                if (eval.Errors.Count > 0)
                {
                    //An error automatically means fail the substitution.
                    return source;
                }
                else
                {
                    dynamic resultTemp = eval.Eval();
                    if ((resultTemp != null))
                        return resultTemp.ToString();
                }
                //Huh, must have evaluated to null. Since we don't want to replace a string with null, give back empty string.
                return "";
            });

        }
    }
}
