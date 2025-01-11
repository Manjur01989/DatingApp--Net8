namespace API.Extensions;

using System;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

public static class DateTimeExtensions
{
    public static int CalculateAge(this DateOnly dob)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = today.Year - dob.Year;
        if (dob > today.AddYears(-age)) age--;
        return age;
    }
}