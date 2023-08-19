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
    public partial class EditPost : System.Web.UI.Page
    {
        private const string BaseApiUrl = "https://localhost:44357/api/posts"; // Replace with your API URL
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data of the post to be edited and populate input controls
                int postId = Convert.ToInt32(Request.QueryString["postId"]); // Get the postId from the query string                

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseApiUrl + "/");

                    var response = client.GetAsync(postId.ToString()).Result;
                    Post post = JsonConvert.DeserializeObject<Post>(response.Content.ReadAsStringAsync().Result);
                    txtTitle.Value = post.Title;
                    txtAuthor.Value = post.Author;
                    txtContent.Value = post.Content;
                    ddlStatus.Value = post.Status;                  
                }


                // Retrieve and populate post data using your data access logic
                // Example: Post post = YourDataAccess.GetPostById(postId);
                // Example: txtEditTitle.Text = post.Title;
                // Populate other input controls with post data
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Posts.aspx");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int postId = Convert.ToInt32(Request.QueryString["postId"]);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseApiUrl + "/");

                var post = new Post
                {
                    Id = postId,
                    Title = txtTitle.Value,
                    Author = txtAuthor.Value,
                    Content = txtContent.Value,
                    Status = ddlStatus.Value                    
                };

                var response = client.PutAsJsonAsync(postId.ToString(), post).Result;

                if (response.IsSuccessStatusCode)
                {
                    Response.Redirect("Posts.aspx");
                }
                else
                {
                    // Handle error
                }
            }
            // Update post data in the database using your data access logic
            // Example: int postId = Convert.ToInt32(Request.QueryString["postId"]);
            // Example: Post updatedPost = new Post { Id = postId, Title = txtEditTitle.Text, ... };
            // Example: YourDataAccess.UpdatePost(updatedPost);

            // Redirect back to the list page
        }
        
    }
}