using BlogEF.Data;
using BlogEF.Models;

using var context = new BlogDataContext();

var tag = new Tag { Name = "Vue", Slug = "vue" };

context.Tags.Add(tag);
context.SaveChanges();