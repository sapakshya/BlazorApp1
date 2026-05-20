using Microsoft.AspNetCore.Identity;

namespace BlazorApp1.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        // When a user registers they must be approved by an administrator
        // before they are allowed to sign in. Default is false.
        public bool IsApproved { get; set; } = false;
    }

}
