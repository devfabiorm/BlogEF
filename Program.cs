using BlogEF.Data;
using BlogEF.Models;
using Microsoft.EntityFrameworkCore;

using var context = new BlogDataContext();

//AddTag(context);
//RetrieveTag(context);
//Update(context);
//Remove(context);
//ListTags(context);
//RetrieveWithoutMetadata(context);

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