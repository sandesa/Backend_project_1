﻿using System.Security.Claims;

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

                return account?.Id ?? -1;
            }
            return -1;
        }

        public string GetLoggedInAccountName()
        {
            var user = _httpContextAccessor.HttpContext.User;
            return user.Identity.IsAuthenticated ? user.FindFirstValue(ClaimTypes.Name) : null;
        }
    }
}
