
using System.Numerics;
using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.CombatRoutine.Trigger;
using Dalamud.Game.Command;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.CombatRoutine.View.JobView.HotkeyResolver;
using AEAssist.Extension;
using AEAssist.GUI;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using ImGuiNET;
using xww.dancer;
using xww.dancer.Opener;
using xww.vp;
using Xww.vp;
using xww.vp.gcd;
using xww.vp.gui;

namespace Xww
{
    public  class Viper : IRotationEntry
    {
        public string AuthorName { get; set; } = "xww";
        public Rotation Build(string settingFolder)
        {
            
            JOBSettings.Build(settingFolder);
            Gui.Build();
            Rotation rot = new Rotation(xww.vp.Slotlist.ViperSlotResolvers)
            {
                TargetJob = Jobs.Viper,
                AcrType = AcrType.Normal,
                MaxLevel = 100,
                MinLevel = 1,
                Description="日随用1-100\n没有智能停手，可以在QT控制停手\n后面会更新"
            };
            rot.SetRotationEventHandler(new Vpenevt());
            rot.AddTriggerAction(new xww.vp.Triggers.TriggerAction_QT());
            rot.AddTriggerAction(new xww.vp.Triggers.TriggerAction_jobset());
            rot.AddOpener(GetOpener);
            return rot;
        }

        IOpener? GetOpener(uint level)
        {
            return new vp100op();
        }
        public void Dispose()
        {
           
        }
        public  IRotationUI GetRotationUI()
        {
         return Gui.Vpgui;
        }

        public void OnDrawSetting()
        {
            
        }
        
    } 
    public class Dancer: IRotationEntry
    {
        public void Dispose()
        {
        }

        public Rotation? Build(string settingFolder)
        {
            xww.dancer.JOBSettings.Build(settingFolder);
            xww.dancer.gui.Gui.Build();
            Rotation rot = new Rotation(xww.dancer.Slotlist.DancerSlotResolvers)
            {
                TargetJob = Jobs.Dancer,
                AcrType = AcrType.Normal,
                MaxLevel = 100,
                MinLevel = 1,
                Description="日随用1-100\n初始"
            };
            rot.SetRotationEventHandler(new danevent());
            rot.AddOpener(GetOpener);
            return rot;
        }
        

        IOpener? GetOpener(uint level)
        {
            return new IOpener100();
        }
        public IRotationUI GetRotationUI()
        {
            return xww.dancer.gui.Gui.dangui;
        }

        public void OnDrawSetting()
        {
        }

        public string AuthorName { get; set; } = "Xww";
    }
}
