using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.UI.WebControls;
using BlogManagement.Models;
using Newtonsoft.Json;

namespace BlogManagement
{
    public partial class Posts : System.Web.UI.Page
    {       
        private const string BaseApiUrl = "https://localhost:44357/api/posts"; // Replace with your API URL

        protected void Page_Load(object sender, EventArgs e)
        {
            //var postService = new BlogService(new BlogDbContext());
            //List<Post> posts = postService.GetAllPosts();

            if (!IsPostBack)
            {
                LoadPosts();
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreatePost.aspx");
        }
        private void LoadPosts()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseApiUrl);
                var response = client.GetAsync("").Result;

                if (response.IsSuccessStatusCode)
                {
                    var posts = JsonConvert.DeserializeObject<List<Post>>(response.Content.ReadAsStringAsync().Result);
                    gvPosts.DataSource = posts;
                    gvPosts.DataBind();
                }
                else
                {
                    // Handle error
                }
            }
        }

        

        //protected void gvPosts_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvPosts.EditIndex = e.NewEditIndex;
        //    LoadPosts();
        //}

        //protected void gvPosts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    gvPosts.EditIndex = -1;
        //    LoadPosts();
        //}

        //protected void gvPosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = gvPosts.Rows[e.RowIndex];
        //    int postId = Convert.ToInt32(gvPosts.DataKeys[e.RowIndex].Value);
        //    string title = (row.FindControl("txtEditTitle") as TextBox).Text;
        //    string author = (row.FindControl("txtEditAuthor") as TextBox).Text;
        //    string content = (row.FindControl("txtEditContent") as TextBox).Text;
        //    string status = (row.FindControl("ddlEditStatus") as DropDownList).SelectedValue;

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(BaseApiUrl + "/");

        //        var updatedPost = new Post
        //        {
        //            Id = postId,
        //            Title = title,
        //            Author = author,
        //            Content = content,
        //            Status = status
        //        };

        //        var response = client.PutAsJsonAsync(postId.ToString(), updatedPost).Result;

        //        if (response.IsSuccessStatusCode)
        //        {
        //            gvPosts.EditIndex = -1;
        //            LoadPosts();
        //        }
        //        else
        //        {
        //            // Handle error
        //        }
        //    }
        //}

        protected void gvPosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int postId = Convert.ToInt32(gvPosts.DataKeys[e.RowIndex].Value);
           
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseApiUrl+"/");

                    var response = client.DeleteAsync(postId.ToString()).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        LoadPosts();
                    }
                    else
                    {
                        // Handle error
                    }
                }          
           
            
        }
        protected void gvPosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int postId = Convert.ToInt32(gvPosts.DataKeys[rowIndex].Value);
                Response.Redirect($"EditPost.aspx?postId={postId}");
            }
            else if (e.CommandName == "Details")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int postId = Convert.ToInt32(gvPosts.DataKeys[rowIndex].Value);
                Response.Redirect($"ViewPost.aspx?postId={postId}");
            }
        }
        //private void ClearForm()
        //{
        //    txtTitle.Value = string.Empty;
        //    txtAuthor.Value = string.Empty;
        //    txtContent.Value = string.Empty;
        //    ddlStatus.SelectedIndex = 0;
        //}

    }
}