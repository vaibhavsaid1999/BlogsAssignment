using BlogManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogManagement
{
    public partial class ViewPost : System.Web.UI.Page
    {
        private const string BaseApiUrl = "https://localhost:44357/api/posts"; // Replace with your API URL
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data of the post to be viewed and populate controls
                int postId = Convert.ToInt32(Request.QueryString["postId"]); // Get the postId from the query string
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseApiUrl + "/");

                    var response = client.GetAsync(postId.ToString()).Result;
                    Post post = JsonConvert.DeserializeObject<Post>(response.Content.ReadAsStringAsync().Result);
                    txtTitle.Text = post.Title;
                    txtAuthor.Text = post.Author;
                    txtContent.Text = post.Content;
                    ddlStatus.Text = post.Status;
                    PublishedDate.Text = post.PublishedDate.ToString();
                }               
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Posts.aspx");
        }
    }
}