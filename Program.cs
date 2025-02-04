using BlogEF.Data;
using BlogEF.Models;
using Microsoft.EntityFrameworkCore;

using var context = new BlogDataContext();

//Lazy Loading needs virtual access modifier on properties to enables EF Core loading automatically a related property on its access
//Eager Loading you need explicitly use Inclue to load a related property
var posts = await GetPosts(context);
var tags = await context.Users.ToListAsync();

Console.WriteLine("Test"); ;

static void AddTag(BlogDataContext context)
{
    var tag = new Tag { Name = "Vue", Slug = "vue" };

    context.Tags.Add(tag);
    context.SaveChanges();
}

static void RetrieveTag(BlogDataContext context)
{
    var tag = context.Tags.FirstOrDefault(x => x.Id == 1003);
    Console.WriteLine(tag.Name);
}

static void Update(BlogDataContext context)
{
    var tag = context.Tags.FirstOrDefault(x => x.Id == 1003);

    tag!.Name = "VueJs";
    tag.Slug = "vuejs";

    context.Update(tag);
    //context.Tags.Update(tag);
    context.SaveChanges();
}

static void Remove(BlogDataContext context)
{
    var tag = context.Tags.FirstOrDefault(x => x.Id == 4);
    context.Remove<Tag>(tag!);
    //context.Tags.Remove(tag!);
    context.SaveChanges();
}

static void ListTags(BlogDataContext context)
{
    var tags = context
        .Tags
        .AsNoTracking() //Disable tracking by EF, avoing bringing back metadata incresing performance
        .Where(x => x.Name.Contains(".NET"))
        .ToList();

    foreach (var tag in tags)
    {
        Console.WriteLine($"Name: {tag.Name}");
    }
}

static void RetrieveWithoutMetadata(BlogDataContext context)
{
    var tag = context
        .Tags
        .AsNoTracking()
        //.SingleOrDefault() //In case of more than one register, an exception will be throw
        .FirstOrDefault(x => x.Id == 3);

    Console.WriteLine($"Name: {tag!.Name}");
}

static void InsertWithRefencedObjects(BlogDataContext context)
{
    var user = new User
    {
        Name = "Tester",
        Slug = "tester",
        Email = "tester@test,com",
        Bio = "Testing",
        Image = "https://test.com",
        PasswordHash = "andaun123i2qnew9vhj"
    };

    var category = new Category
    {
        Name = "Backend",
        Slug = "backend"
    };

    var post = new Post
    {
        Author = user,
        Category = category,
        Body = "<p>Hello World</p>",
        Slug = "comecando-com-ef-core",
        Summary = "Neste artigo vamos aprender sobre EF Core",
        Title = "Começando com EF Core",
        CreateDate = DateTime.Now,
        LastUpdateDate = DateTime.Now,
    };

    context.Posts.Add(post);
    context.SaveChanges();
}

static void RetrievePostsWithRelatedObjects(BlogDataContext context)
{
    var posts = context
    .Posts
    .AsNoTracking()
    .Include(x => x.Author)
    .Include(x => x.Category)
    .OrderByDescending(x => x.LastUpdateDate)
    .ToList();

    foreach (var post in posts)
        Console.Write($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");
}

static void UpdatingPropertyOfRelatedObject(BlogDataContext context)
{
    var post = context
    .Posts
    .Include(x => x.Author)
    .Include(x => x.Category)
    .OrderByDescending(x => x.LastUpdateDate)
    .FirstOrDefault();

    post!.Author.Name = "Testador";
    context.Posts.Update(post);
    context.SaveChanges();
}

static void TestingMigrations(BlogDataContext context)
{
    // var user = new User
    // {
    //     Name = "John Santiago Shuawzinner",
    //     Bio = "Backend developer",
    //     Email = "j.santiago.shu@test.com",
    //     Image = "https;/imagegenerator.test/user/jsshu",
    //     PasswordHash = "A134F1CD42BGHA1B355A",
    //     Slug = "jonh-s-shu"
    // };

    // context.Users.Add(user);
    // context.SaveChanges();

    var user = context.Users.FirstOrDefault();

    var post = new Post
    {
        Author = user!,
        Body = "Meu artigo",
        Category = new Category
        {
            Name = ".NET",
            Slug = "dotnet"
        },
        CreateDate = DateTime.Now.ToUniversalTime(),
        Slug = "meu-atigo",
        Summary = "Neste artigo vamos conferir...",
        Title = "Meu artigo"
    };

    context.Posts.Add(post);
    context.SaveChanges();
}

static async Task<IEnumerable<Post>> GetPosts(BlogDataContext context)
{
    return await context.Posts.ToListAsync(); ;
}

static List<Post> ListPostsWithPagination(BlogDataContext context, int skip = 0, int take = 25)
{
    var posts = context
        .Posts
        .AsNoTracking() //Use when no update or delete is needed
        .Skip(0)
        .Take(take)
        .ToList();

    return posts;
}