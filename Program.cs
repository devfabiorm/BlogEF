using BlogEF.Data;
using BlogEF.Models;
using Microsoft.EntityFrameworkCore;

using var context = new BlogDataContext();

// var tag = new Tag { Name = "Vue", Slug = "vue" };

// context.Tags.Add(tag);
// context.SaveChanges();

// var tag = context.Tags.FirstOrDefault(x => x.Id == 1003);
// tag!.Name = "VueJs";
// tag.Slug = "vuejs";

// context.Update(tag);
// context.Tags.Update(tag);
// context.SaveChanges();

// var tag = context.Tags.FirstOrDefault(x => x.Id == 4);
// context.Remove<Tag>(tag!);
// context.Tags.Remove(tag!);
// context.SaveChanges();

// var tags = context
//     .Tags
//     .AsNoTracking() //Unable tracking by EF, avoing bringing back metadata incresing performance
//     .Where(x => x.Name.Contains(".NET"))
//     .ToList();

// foreach (var tag in tags)
// {
//     Console.WriteLine(tag.Name);
// }

var tag = context
    .Tags
    .AsNoTracking()
    //.SingleOrDefault() //In case of more than one register, an exception will be throw
    .FirstOrDefault(x => x.Id == 3);