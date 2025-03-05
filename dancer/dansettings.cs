using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using AEAssist.IO;

namespace xww.dancer;

public class JOBSettings
{
    public static JOBSettings Instance;
    private static string path;
    public bool Autowuban;
    public JobViewSave JobViewSave = new(); // QT设置存档
    public int Maxlinli; //伶俐最大

    public static void Build(string settingPath)
    {
        path = Path.Combine(settingPath, "xwwdan", ".json");
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
            Instance = new JOBSettings();
            LogHelper.Error(e.ToString());
        }
    }

    public void Save()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        File.WriteAllText(path, JsonHelper.ToJson(this));
    }
}