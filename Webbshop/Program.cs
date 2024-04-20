using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;
using Webbshop.Data;
using Webbshop.Interfaces;
using Webbshop.Models;
using Webbshop.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = "Google";
})
.AddCookie(options =>
{
	options.Events.OnValidatePrincipal += async context =>
	{
		var serviceProvider = context.HttpContext.RequestServices;
		using var db = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

		string subject = context.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
		string issuer = context.Principal.FindFirst(ClaimTypes.NameIdentifier).Issuer;
		string name = context.Principal.FindFirst(ClaimTypes.Name).Value;

		var account = db.Accounts
			.FirstOrDefault(p => p.OpenIDIssuer == issuer && p.OpenIDSubject == subject);

		if (account == null)
		{
			account = new Account
			{
				OpenIDIssuer = issuer,
				OpenIDSubject = subject,
				Name = name
			};
			db.Accounts.Add(account);
		}
		else
		{
			account.Name = name;
		}

		await db.SaveChangesAsync();
	};
})
.AddOpenIdConnect("Google", options =>
{
	options.Authority = "https://accounts.google.com";
	
	options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
	options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
	options.ResponseType = OpenIdConnectResponseType.Code;
	options.CallbackPath = "/signin-oidc-google";
	options.Scope.Add("openid");
	options.Scope.Add("profile");
	options.Scope.Add("email");
	options.SaveTokens = true;
	options.GetClaimsFromUserInfoEndpoint = true;
});

builder.Services.AddAuthorization(options =>
{
	options.FallbackPolicy = new AuthorizationPolicyBuilder()
		.RequireAuthenticatedUser()
		.Build();
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AccessControl>();

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<AppDbContext>();
	await ProductsSeedData.InitializeAsync(context);
	SampleData.Create(context);
}

app.Run();
