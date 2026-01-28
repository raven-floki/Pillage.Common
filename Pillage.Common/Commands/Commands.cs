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
            Console.WriteLine($"Method: {method.Name}");
        }
    }
}


[AttributeUsage(AttributeTargets.Method)]
public class ChatCommandAttribute(string command, string options) : Attribute
{
    string Command = command;
    string Options = options;
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