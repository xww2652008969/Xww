using AEAssist.CombatRoutine.View.JobView;
using Xww;

namespace xww.vp.gui;

public class Gui
{
    public static JobViewWindow Vpgui;
    private static string OverlayTitle { get; } = "这个好像是标题";

    public static void Build()
    {
        Vpgui = new JobViewWindow(JOBSettings.Instance.JobViewSave, JOBSettings.Instance.Save, OverlayTitle);
        Initgui();
    }

    private static void Initgui()
    {
        Hotkey.createHtokey(Vpgui);
        QT.createQT(Vpgui);
        Tab.createTab(Vpgui);
    }
}