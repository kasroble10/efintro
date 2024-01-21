// See https://aka.ms/new-console-template for more information
using EFIntro;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Security.Cryptography;



public class Program
{
    public static void Main(string[] args)
        
    {


        string[] kasin = File.ReadAllLines("C:\\Users\\ansha\\source\\repos\\EFIntro\\Blog.csv");
        string[] ahmed = File.ReadAllLines("C:\\Users\\ansha\\source\\repos\\EFIntro\\post.csv");
        string[] ali = File.ReadAllLines("C:\\Users\\ansha\\source\\repos\\EFIntro\\user.csv");

        foreach (string s in kasin)
        {
            Console.WriteLine(s);


        }
        foreach (string L in ahmed)


        {
            Console.WriteLine(L);

        }
        foreach(string W in ali)

        {
            Console.WriteLine(W);
        }


    }
    public List<User> Parse(string[] csvData)
    {
        List<User> users = new List<User>();
        foreach (string user in csvData )
        {
            User newUser = new User
            {
                Id = int.Parse(user.Split(",")[0]),
                Username = user.Split(",")[1],
                Password = user.Split(",")[2],
                 PostID= int.Parse(user.Split(",")[3])
            };
            users.Add(newUser);
        }
        return users;
    }
    public List<Post> ParsePosts(string[] csvData)
    {
        List<Post> posts = new List<Post>();

        foreach (string postRow in csvData)
        {
            string[] postData = postRow.Split(',');

            if (postData.Length == 6)
            {
                Post newPost = new Post
                {
                    Id = int.Parse(postData[0].Trim()),
                    Title = postData[1].Trim(),
                    Content = postData[2].Trim(),
                    PublishedOn = DateTime.Parse(postData[3].Trim()), // Anpassa datumkonverteringen efter ditt behov
                    BlogId = int.Parse(postData[4].Trim()),
                    UserId = int.Parse(postData[5].Trim())
                };

                posts.Add(newPost);
            }
            else
            {
                Console.WriteLine($"Felaktig rad i CSV: {postRow}");
            }
        }

        return posts;
    }

    public List<Blog> ParseBlogs(string[] csvData)
    {
        List<Blog> blogs = new List<Blog>();

        foreach (string blogRow in csvData)
        {
            string[] blogData = blogRow.Split(',');

            if (blogData.Length == 4)
            {
                Blog newBlog = new Blog
                {
                      Id = int.Parse(blogData[0].Trim()),
                    Url = blogData[1].Trim(),
                    Name = blogData[2].Trim(),
                    PostId = int.Parse(blogData[3].Trim())
                };

                blogs.Add(newBlog);
            }
            else
            {
                Console.WriteLine($"Felaktig rad i CSV: {blogRow}");
            }
        }

        return blogs;
    }



}




//Console.WriteLine("Hello, World!");

//using var db= new BloggingContext();
//Console.WriteLine($"SQLite DB located at:{db.DbPath}");

//db.Add(new Blog { Url = "first Blog" });
//db.Add(new Blog { Url = "second Blog" });


//db.SaveChanges();

//Blog? blog = db.Blogs.OrderBy(b => b.BlogID).First();

//Console.WriteLine($"Blog url before update:{blog.Url}");

//blog.Url = "first blog but changed";
//db.SaveChanges();
//Console.WriteLine($"Blog url before update:{blog.Url}");

//blog.Posts.Add(new Post
//{
//    Title="first post in there first Blog",
//    Content="NO Content TO BE found here"
//});




//foreach(Blog b in db.Blogs)
//{
//    db.Remove(b);

//}
//db.SaveChanges();   