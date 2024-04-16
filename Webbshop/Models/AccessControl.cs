using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using Webbshop.Data;
using Webbshop.Models;

namespace Webbshop.Data
{
    public class AccessControl
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _dbContext;

        public AccessControl(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }

        public int GetLoggedInAccountId()
        {
            var user = _httpContextAccessor.HttpContext.User;
            if (user.Identity.IsAuthenticated)
            {
                string subject = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                string issuer = user.FindFirst(ClaimTypes.NameIdentifier).Issuer;

                var account = _dbContext.Accounts
                    .FirstOrDefault(p => p.OpenIDIssuer == issuer && p.OpenIDSubject == subject);

                return account?.ID ?? -1; // Return -1 if account is not found
            }
            return -1; // Return -1 if user is not authenticated
        }

        public string GetLoggedInAccountName()
        {
            var user = _httpContextAccessor.HttpContext.User;
            return user.Identity.IsAuthenticated ? user.FindFirstValue(ClaimTypes.Name) : null;
        }
    }
}
