using BlogManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlogManagement
{
    public partial class CreatePost : System.Web.UI.Page
    {
        private const string BaseApiUrl = "https://localhost:44357/api/posts"; // Replace with your API URL
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseApiUrl);

                var post = new Post
                {
                    Title = txtTitle.Value,
                    Author = txtAuthor.Value,
                    Content = txtContent.Value,
                    Status = ddlStatus.Value,
                    CreationDate = DateTime.Now
                };

                var response = client.PostAsJsonAsync("", post).Result;

                if (response.IsSuccessStatusCode)
                {
                    Response.Redirect("Posts.aspx");
                }
                else
                {
                    // Handle error
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Posts.aspx");
        }       
    }
}