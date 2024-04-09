using Microsoft.AspNetCore.Http;
using System;
using System.Text;
using System.Threading.Tasks;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;

    public BasicAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        string authHeader = context.Request.Headers["Authorization"];

        if (authHeader != null && authHeader.StartsWith("Basic "))
        {
            // Getting credentials
            string encodedUsernamePassword = authHeader.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries)[1]?.Trim();
            string decodedUsernamePassword = null;

            try
            {
                decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
            }
            catch (FormatException)
            {
                // Handle malformed base64 string
                context.Response.StatusCode = 400; // Bad Request
                return;
            }

            if (decodedUsernamePassword != null)
            {
                string[] usernamePasswordArray = decodedUsernamePassword.Split(':', 2);

                string username = usernamePasswordArray[0];
                string password = usernamePasswordArray[1];

                // Check credentials
                if (IsAuthenticated(username, password))
                {
                    await _next.Invoke(context);
                    return;
                }
            }
        }

        // If credentials are not valid OR missing, return unauthorized status
        context.Response.StatusCode = 401;
        context.Response.Headers["WWW-Authenticate"] = "Basic";
    }

    private bool IsAuthenticated(string username, string password)
    {
        // Credentials
        return username == "user" && password == "password";
    }
}
