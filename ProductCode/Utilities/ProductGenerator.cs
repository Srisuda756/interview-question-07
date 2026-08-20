using System.Security.Cryptography;

namespace ProductCode.Utilities;

public static class ProductCodeGenerator
{
    private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string Generate()
    {
        var parts = new List<string>();

        for (var i = 0; i < 6; i++)
        {
            var part = new string(
                Enumerable.Range(0, 5)
                    .Select(_ => Characters[RandomNumberGenerator.GetInt32(Characters.Length)])
                    .ToArray()
            );

            parts.Add(part);
        }

        return string.Join("-", parts);
    }
}