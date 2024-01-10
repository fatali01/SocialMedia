using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Services.Replies
{
    public class RepliesService : IRepliesService
    {
        private readonly ApplicationDbContext _dbContext;

        public NoteService(UserManager<User> userManager,
                            SignInManager<User> signInManager,
                            ApplicationDbContext dbContext)
        {
            var currentUser = signInManager.Context.User;
            var userIdClaim = userManager.GetUserId(currentUser);
            var hasValidId = int.TryParse(userIdClaim, out _userId);

            if (hasValidId == false)
                throw new Exception("Attempted to build ReplyService without Id claim.");
                
            _dbContext = dbContext;
        }
    }
}