using CompanyManager.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public void InsertPost(Post post)
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
                var post = context.Posts.FirstOrDefault(x => x.Id == postId);
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

        public Post GetPostByName(string name)
        {
            using(var context = new PersonContext())
            {
                return context.Posts.FirstOrDefault(x => x.Name==name);
            }            
        }
    }
}
