//using BlogManagement.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace BlogManagement.Services
//{    
//    public class BlogService 
//    {
//        private readonly BlogDbContext _dbContext;

//        public BlogService(BlogDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public List<Post> GetAllPosts()
//        {
//            // Call the SELECT stored procedure
//            return _dbContext.Posts.SqlQuery("EXEC GetPosts").ToList();
//        }

//        public Post GetPostById(int id)
//        {
//            // Call the SELECT stored procedure with parameter
//            return _dbContext.Posts.SqlQuery("EXEC GetPostById @Id", new SqlParameter("@Id", id)).SingleOrDefault();
//        }

//        public void CreatePost(Post post)
//        {
//            // Call the INSERT stored procedure
//            _dbContext.Database.ExecuteSqlCommand("EXEC CreatePost @Title, @Author, @Content,@Status,@CreationDate,@PublishedDate",
//                new SqlParameter("@Title", post.Title),
//                new SqlParameter("@Author", post.Author),
//                new SqlParameter("@Content", post.Content),
//                new SqlParameter("@Status", post.Status),
//                new SqlParameter("@CreationDate", post.CreationDate),
//                new SqlParameter("@PublishedDate", post.PublishedDate)            
//            );
//        }

//        public void UpdatePost(Post post)
//        {
//            // Call the UPDATE stored procedure
//            _dbContext.Database.ExecuteSqlCommand("EXEC UpdatePost @Id, @Title, @Author, @Content,@Status,@CreationDate,@PublishedDate",
//                new SqlParameter("@Id", post.Id),
//                new SqlParameter("@Title", post.Title),
//                new SqlParameter("@Author", post.Author),
//                new SqlParameter("@Content", post.Content),
//                new SqlParameter("@Status", post.Status),
//                new SqlParameter("@CreationDate", post.CreationDate),
//                new SqlParameter("@PublishedDate", post.PublishedDate)
//            );
//        }

//        public void DeletePost(int id)
//        {
//            // Call the DELETE stored procedure
//            _dbContext.Database.ExecuteSqlCommand("EXEC DeletePost @Id",
//                new SqlParameter("@Id", id)
//            );
//        }

//    }
//}