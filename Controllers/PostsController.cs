using BlogManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogManagement.Controllers
{
    public class PostsController : ApiController
    {
        private readonly BlogDbContext _dbContext;

        public PostsController()
        {
            _dbContext = new BlogDbContext(); // Initialize your database context
        }

        // GET api/posts
        public IHttpActionResult Get()
        {
            //Using LINQ
            //var posts = _dbContext.Posts.ToList();

            //Using SP
            var posts = _dbContext.Posts.SqlQuery("EXEC GetPosts").ToList();
            return Ok(posts);
        }

        // GET api/posts/1
        public IHttpActionResult Get(int id)
        {
            //Using LINQ
            //var post = _dbContext.Posts.Find(id);

            //Using SP
            var post = _dbContext.Posts.SqlQuery("EXEC GetPostById @Id", new SqlParameter("@Id", id)).SingleOrDefault();
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        // POST api/posts
        public IHttpActionResult Post(Post post)
        {
            var exists = _dbContext.Posts.Where(x => x.Author == post.Author).FirstOrDefault();
            if(exists != null)
            {
                return CreatedAtRoute("DefaultApi", new { id = exists.Id }, exists);
            }
            post.CreationDate = DateTime.Now;
            if(post.Status == "Published")
            {
                post.PublishedDate = DateTime.Now;
            }           
            //Using LINQ
            //_dbContext.Posts.Add(post);
            //_dbContext.SaveChanges();

            //Using SP
            _dbContext.Database.ExecuteSqlCommand("EXEC CreatePost @Title, @Author, @Content,@Status,@CreationDate,@PublishedDate",
                new SqlParameter("@Title", post.Title),
                new SqlParameter("@Author", post.Author),
                new SqlParameter("@Content", post.Content),
                new SqlParameter("@Status", post.Status),
                new SqlParameter("@CreationDate", post.CreationDate),
                new SqlParameter("@PublishedDate", DBNull.Value)
            );

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        // PUT api/posts/1
        public IHttpActionResult Put(int id, Post post)
        {
            if (id != post.Id)
                return BadRequest();

            var existingPost = _dbContext.Posts.Find(id);
            if (existingPost == null)
                return NotFound();
            post.CreationDate = existingPost.CreationDate;
            if (post.Status == "Published")
            {
                post.PublishedDate = DateTime.Now;
            }
            else
            {
                post.PublishedDate = existingPost.PublishedDate;
            }           

            //Using LINQ
            //_dbContext.Posts.AddOrUpdate(post);
            //_dbContext.SaveChanges();

            //Using SP
            _dbContext.Database.ExecuteSqlCommand("EXEC UpdatePost @Id, @Title, @Author, @Content,@Status,@CreationDate,@PublishedDate",
                new SqlParameter("@Id", post.Id),
                new SqlParameter("@Title", post.Title),
                new SqlParameter("@Author", post.Author),
                new SqlParameter("@Content", post.Content),
                new SqlParameter("@Status", post.Status),
                new SqlParameter("@CreationDate", post.CreationDate),
                new SqlParameter("@PublishedDate", DBNull.Value)                 
            );

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/posts/1   
        public IHttpActionResult Delete(int id)
        {
            //Using LINQ
            //var post = _dbContext.Posts.Find(id);

            //Using SP
            var post = _dbContext.Posts.SqlQuery("EXEC GetPostById @Id", new SqlParameter("@Id", id)).SingleOrDefault();

            if (post == null)
                return NotFound();

            //Using LINQ
            //_dbContext.Posts.Remove(post);
            //_dbContext.SaveChanges();

            //Using SP
            _dbContext.Database.ExecuteSqlCommand("EXEC DeletePost @Id",
                new SqlParameter("@Id", id)
            );
            return Ok(post);
        }
    }
}
