using System;
using System.Security.Claims;

namespace API.Extensions;

public static class ClaimsPrincipleExtesions
{
    public static string GetUsername(this ClaimsPrincipal user)
    {
        var username = user.FindFirstValue(ClaimTypes.NameIdentifier);  //ClaimTypes.NameIdentifier
        if (string.IsNullOrEmpty(username))
        {
            throw new Exception("Username not found in claims");
        }
        return username;
    } 
}