using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace school_register.Services.Extension
{
    public static class AzureExtension
    {
        public static string ConnectionStringMySQL(this string connectionString)
        {
            var cs = connectionString;
            var hostPortPattern = @"Source=((?:(?:(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.){3}(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9]))|(?:[A-Z0-9.-]+\.[A-Z]{2,})):(\d+);*";
            var options = RegexOptions.IgnoreCase;

            var match = Regex.Match(connectionString, hostPortPattern, options);

            if (match.Success)
            {
                var ip = match.Groups[1].Value;
                var port = match.Groups[2].Value;
                var other = new Regex(@"Database=(\w+);*").Match(connectionString);
                var db = other.Groups[1].Value;
                other = new Regex(@"User\ Id=(\w+);*").Match(connectionString);
                var user = other.Groups[1].Value;
                other = new Regex(@"Password=([^;]*);*").Match(connectionString);
                var password = other.Groups[1].Value;
                var sb = new StringBuilder();
                sb.Append("server=");
                sb.Append(ip);
                sb.Append(";port=");
                sb.Append(port);
                sb.Append(";userid=");
                sb.Append(user);
                sb.Append(";password=");
                sb.Append(password);
                sb.Append(";database=");
                sb.Append(db);
                cs = sb.ToString();
            }
            return cs;
        }
    }
}
