using Microsoft.AspNetCore.Identity;


namespace Core.Entities
{
    public class User : IdentityUser<int>
    {
      public List<Post> Posts { get; set; }
    }
}
