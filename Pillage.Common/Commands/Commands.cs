using System.Linq;
using System.Reflection;

namespace Pillage.Common.Commands;

internal static class Commands
{
    static void GetAll()
    {
        // Get all static methods with the specified attribute
        var methodsWithAttribute = typeof(MyStaticClass)
            .GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
            .Where(m => m.GetCustomAttributes(typeof(ChatCommandAttribute), false).Any());

        foreach (var method in methodsWithAttribute)
        {
            var attribute = (ChatCommandAttribute)method.GetCustomAttributes(typeof(ChatCommandAttribute), false)
                .FirstOrDefault();
            Console.WriteLine($"Method: {method.Name}");
            Console.WriteLine($"Command: {attribute.Command}");
        }
    }
}


[AttributeUsage(AttributeTargets.Method)]
public class ChatCommandAttribute(string command, string options) : Attribute
{
    public string Command = command;
    public string Options = options;
}

public static class MyStaticClass
{
    [ChatCommand("lm", "cfg")]
    public static void MethodWithAttribute()
    {
        Console.WriteLine("Method with attribute executed.");
    }

    public static void MethodWithoutAttribute()
    {
        Console.WriteLine("Method without attribute executed.");
    }
}