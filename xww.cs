using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module.Opener;
using xww.dancer;
using xww.dancer.Opener;
using xww.vp;
using xww.vp.gui;
using xww.vp.Triggers;
using Slotlist = xww.vp.Slotlist;

namespace Xww;

public class Viper : IRotationEntry
{
    public string AuthorName { get; set; } = "xww";

    public Rotation Build(string settingFolder)
    {
        JOBSettings.Build(settingFolder);
        Gui.Build();
        var rot = new Rotation(Slotlist.ViperSlotResolvers)
        {
            TargetJob = Jobs.Viper,
            AcrType = AcrType.Normal,
            MaxLevel = 100,
            MinLevel = 1,
            Description = "日随用1-100\n没有智能停手，可以在QT控制停手\n后面会更新"
        };
        rot.SetRotationEventHandler(new Vpenevt());
        rot.AddTriggerAction(new TriggerAction_QT());
        rot.AddTriggerAction(new TriggerAction_jobset());
        rot.AddOpener(GetOpener);
        return rot;
    }

    public void Dispose()
    {
    }

    public IRotationUI GetRotationUI()
    {
        return Gui.Vpgui;
    }

    public void OnDrawSetting()
    {
    }

    private IOpener? GetOpener(uint level)
    {
        if (level == 100) return new vp100op();
        return null;
    }
}

public class Dancer : IRotationEntry
{
    public void Dispose()
    {
    }

    public Rotation? Build(string settingFolder)
    {
        xww.dancer.JOBSettings.Build(settingFolder);
        xww.dancer.gui.Gui.Build();
        var rot = new Rotation(xww.dancer.Slotlist.DancerSlotResolvers)
        {
            TargetJob = Jobs.Dancer,
            AcrType = AcrType.Normal,
            MaxLevel = 100,
            MinLevel = 1,
            Description = "日随用1-100\n初始"
        };
        rot.SetRotationEventHandler(new danevent());
        rot.AddOpener(GetOpener);
        return rot;
    }

    public IRotationUI GetRotationUI()
    {
        return xww.dancer.gui.Gui.dangui;
    }

    public void OnDrawSetting()
    {
    }

    public string AuthorName { get; set; } = "Xww";


    private IOpener? GetOpener(uint level)
    {
        return new IOpener100();
    }
}