using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Helper;
using Xww;

namespace xww.dancer.gui;

public class Gui
{
    private static string OverlayTitle { get; } = "舞者";
    public static JobViewWindow dangui;
    public static void Build()
    {
        dangui=new JobViewWindow(JOBSettings.Instance.JobViewSave, JOBSettings.Instance.Save, OverlayTitle);
        Initgui();
    }

    private static void Initgui()
    {
        Hotkey.createHtokey(dangui);
        QT.createQT(dangui);
        Tab.CreateTab(dangui);
    }
    
}