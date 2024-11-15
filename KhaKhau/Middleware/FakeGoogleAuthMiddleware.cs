using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

public class FakeGoogleAuthMiddleware
{
    private readonly RequestDelegate _next;

    public FakeGoogleAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path == "/signin-google")
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "fake-google-id"),
                new Claim(ClaimTypes.Name, "Fake User"),
                new Claim(ClaimTypes.Email, "fakeuser@example.com"),
                new Claim("image", "https://via.placeholder.com/150") // URL ảnh đại diện giả
            };

            var identity = new ClaimsIdentity(claims, "FakeGoogle");
            var principal = new ClaimsPrincipal(identity);
            await context.SignInAsync("FakeGoogle", principal);

            context.Response.Redirect("/");
            return;
        }

        await _next(context);
    }
}