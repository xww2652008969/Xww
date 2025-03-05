using AEAssist.CombatRoutine.View.JobView;

namespace xww.dancer.gui;

public class Gui
{
    public static JobViewWindow dangui;
    private static string OverlayTitle { get; } = "舞者";

    public static void Build()
    {
        dangui = new JobViewWindow(JOBSettings.Instance.JobViewSave, JOBSettings.Instance.Save, OverlayTitle);
        Initgui();
    }

    private static void Initgui()
    {
        Hotkey.createHtokey(dangui);
        QT.createQT(dangui);
        Tab.CreateTab(dangui);
    }
}