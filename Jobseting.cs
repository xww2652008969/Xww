using System;
using System.IO;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using AEAssist.IO;
using AEAssist;
namespace Xww;

public class JOBSettings
{
    public static JOBSettings Instance;
    private static string path;
    public static void Build(string settingPath)
    {
        path = Path.Combine(settingPath, "xwwvp", ".json");
        if (!File.Exists(path))
        {
            Instance = new JOBSettings();
            Instance.Save();
            return;
        }
        try
        {
            Instance = JsonHelper.FromJson<JOBSettings>(File.ReadAllText(path));
        }
        catch (Exception e)
        {
            Instance = new();
            LogHelper.Error(e.ToString());
        }
    }
    public JobViewSave JobViewSave = new(); // QT设置存档
    public int TpDelay ;//tp后返回时间
    public float Maxmeleerange;  //最远近战距离
    public float Maxshelian;//蛇连最大充能时间
    public int Maxfeishe;//飞蛇最大充能
    public int Maxfeishec;//飞蛇时间轴模式
    public void Save()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        File.WriteAllText(path, JsonHelper.ToJson(this));
    }
    
}
