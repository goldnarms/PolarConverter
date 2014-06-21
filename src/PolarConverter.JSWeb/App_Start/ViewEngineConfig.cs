using System.Web.Mvc;

namespace PolarConverter.JSWeb
{
    public static class ViewEngineConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection engines)
        {
            engines.Clear();
            engines.Add(new RazorViewEngine());
        }
    }
}