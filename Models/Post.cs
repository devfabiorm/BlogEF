namespace BlogEF.Models;

public class Post
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public int AuthorId { get; set; }
    public User Author { get; set; } = default!;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
}