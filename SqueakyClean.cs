using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        identifier = identifier.Replace(' ', '_');
        identifier = identifier.Replace("\0", "CTRL");
        if (Regex.IsMatch(identifier, @"\S-\S"))
        {
            char[] identifierArray = identifier.ToCharArray();
            char characterToCamel = identifierArray[identifier.IndexOf('-') + 1];
            identifierArray[identifier.IndexOf('-') + 1] = characterToCamel.ToString().ToUpper().ElementAt(0);
            identifier = new string(identifierArray);
            identifier = identifier.Replace("-", "");
        }
        identifier = Regex.Replace(identifier, @"\W|\d", "");
        identifier = Regex.Replace(identifier, @"[α-ω]", "");
        return identifier;
    }
}
