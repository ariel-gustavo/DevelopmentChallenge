using DevelopmentChallenge.Data.Classes;
using System.Globalization;
using System.Resources;
using System.Threading;

public class LanguageManager
{
    private ResourceManager _resourceManager;

    public LanguageManager()
    {
        _resourceManager = new ResourceManager("DevelopmentChallenge.Data.Resources.Textos", typeof(LanguageManager).Assembly);
    }

    public string GetString(string key, bool plural = false)
    {
        if (plural)
            key += "s";

        return _resourceManager.GetString(key, Thread.CurrentThread.CurrentUICulture);
    }

    public void SetLanguage(Lenguaje language)
    {
        string code = EnumHelper.GetDescription(language);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(code);
    }
}
