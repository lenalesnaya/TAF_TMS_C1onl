using System.Reflection;

namespace TAF_TMS_C1onl.Utilites.Helpers;

public class TestDataHelper
{
    public static EntityType GetTestEntity<EntityType>(string FileName)
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var json = File.ReadAllText(basePath + Path.DirectorySeparatorChar + "TestData" 
                                    + Path.DirectorySeparatorChar + FileName + ".json");
        return JsonHelper.FromJson(json).ToObject<EntityType>()!;
    }
}