using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManager.DAL.Entities;

namespace CompanyManager.DAL.Repository
{
    public class PostService
    {
        public IEnumerable<Post> GetPosts()
        {
            using (var context = new PersonContext())
            {
                return context.Posts.ToList();
            }
        }

        public void InsertPost (Post post)
        {
            using (var context = new PersonContext())
            {
                context.Posts.Add(post);
                context.SaveChanges();
            }
        }

        public void DeletePost(int postId)
        {
            using (var context = new PersonContext())
            {
                Post post = context.Posts.FirstOrDefault(x => x.Id == postId);
                context.Posts.Remove(post);
                context.SaveChanges();
            }
        }

        public void UpdatePost(Post post)
        {
            using (var context = new PersonContext())
            {
                context.Posts.Attach(post);
                context.Entry(post).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
