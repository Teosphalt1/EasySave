using System.Globalization;
using System.Resources;
using System.Reflection;

public static class LangHelper
{
    private static ResourceManager _rm;
    //static constructor
    static LangHelper()
    {
        _rm = new ResourceManager("GuiProject.Language.Resource", Assembly.GetExecutingAssembly());
    }

    public static string? GetString(string name)
    {
        return _rm.GetString(name);
    }
    public static void ChangeLanguage(string language)
    {
        var cultureInfo = new CultureInfo(language);

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
    }
}