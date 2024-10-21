
using System.Numerics;
using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;

using AEAssist.CombatRoutine.View.JobView;
using AEAssist.CombatRoutine.View.JobView.HotkeyResolver;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using ImGuiNET;
using xww.vp;
using Xww.vp;

namespace Xww
{
    public class Viper : IRotationEntry
    {
        
        public string AuthorName { get; set; } = "xww";
        public string OverlayTitle { get; } = "这个好像是标题";
        public Rotation Build(string settingFolder)

        {
            JOBSettings.Build(settingFolder);
            BuildQT();
            Rotation rot = new Rotation(ViperSlotResolvers)
            {
                TargetJob = Jobs.Viper,
                AcrType = AcrType.Normal,
                MaxLevel = 100,
                MinLevel = 1,
                Description="日随用1-100\n没有智能停手，可以在QT控制停手\n后面会更新"
            };
            rot.SetRotationEventHandler(new Vpenevt());
            return rot;
        }

        public void Dispose()
        {
           
        }
        public static JobViewWindow QT { get; private set; }
        private Jobui settingUI = new();
        public IRotationUI GetRotationUI()
        {
            return QT;
        }
        public void BuildQT()
        {
            Viper.QT = new JobViewWindow(JOBSettings.Instance.JobViewSave, JOBSettings.Instance.Save, OverlayTitle);
            // Viper.QT.AddTab("通用", DrawQtGeneral);
            if (AEAssist.Share.LocalContentId == "18014469510992065")
            {
                QT.AddTab("通用", DrawQtGeneral);  //自己查看信息的
            }
            LogHelper.Print("??");
            
            Viper.QT.AddQt(Qtkey.动态真北,false,"动态真北");
            Viper.QT.AddQt(Qtkey.收尾,false,"倾斜资源");
            Viper.QT.AddQt(Qtkey.飞蛇之尾,true,"过远就飞蛇尾");
            Viper.QT.AddQt(Qtkey.停手, false,"停手不打技能");
            Viper.QT.AddQt(Qtkey.留资源,false,"保留资源不打小怪");
            QT.AddHotkey("内丹", new HotKeyResolver_NormalSpell(7541,SpellTargetType.Self));
            QT.AddHotkey("亲疏自行", new HotKeyResolver_NormalSpell(7548,SpellTargetType.Self));
            QT.AddHotkey("浴血", new HotKeyResolver_NormalSpell(7542,SpellTargetType.Self));
            QT.AddHotkey("蛇行", new HotKeyResolver_NormalSpell(34646,SpellTargetType.Target));
            QT.AddHotkey("疾跑",new HotKeyResolver_疾跑());
            QT.AddHotkey("牵制",new HotKeyResolver_NormalSpell(7549,SpellTargetType.Target));
            


        }
        public void OnDrawSetting()
        {
            settingUI.Draw();
        }
        public List<SlotResolverData> ViperSlotResolvers = new()
        {
            
             new(new 祖灵gcd(),SlotMode.Gcd),
            new(new 蛇1gcd(),SlotMode.Gcd),    //蛇连击优先级高
           new(new 蛇2gcd(),SlotMode.Gcd),
           new SlotResolverData(new 蛇aoe(),SlotMode.Gcd),
           new(new 飞蛇gcd(),SlotMode.Gcd),
           // new SlotResolverData(new 飞蛇之牙gcd(),SlotMode.Gcd),
           new(new Basegcd(),SlotMode.Gcd),
           new(new Vpaoe(),SlotMode.Gcd),
            new SlotResolverData(new 真北(),SlotMode.OffGcd),
           new(new Offgcd(),SlotMode.OffGcd), 
           new(new 蛇灵气offgcd(),SlotMode.OffGcd),
        };
        public void DrawQtGeneral(JobViewWindow jobViewWindow)
        {
            ImGui.TextUnformatted("我的位置:"+Core.Me.Position.ToString());
            ImGui.TextUnformatted("gcd"+Core.Resolve<MemApiSpell>().GetGCDDuration());
            if (ImGui.Button("w"))
            {
                // global::AEAssist.MemoryApi.WayMark[] wayMarks = new global::AEAssist.MemoryApi.WayMark[]
                // {
                //     global::AEAssist.MemoryApi.WayMark.A,
                //     global::AEAssist.MemoryApi.WayMark.B,
                //     global::AEAssist.MemoryApi.WayMark.C,
                //     global::AEAssist.MemoryApi.WayMark.D,
                //     global::AEAssist.MemoryApi.WayMark.One,
                //     global::AEAssist.MemoryApi.WayMark.Two,
                //     global::AEAssist.MemoryApi.WayMark.Three,
                //     global::AEAssist.MemoryApi.WayMark.Four
                // };
                // Core.Me.SetPos(Core.Resolve<MemApiMaker>().WayMarker(wayMarks[0]).Pos);
               //
                // LogHelper.Print(PartyHelper.Party[1].Position.ToString());
      
                // LogHelper.Print(Core.Me.GetCurrTarget().Rotation.ToString());
                // LogHelper.Print(Core.Me.GetCurrTarget().HitboxRadius.ToString()); //目标圈大小
                 //Core.Me.SetPos(PartyHelper.Party[1].Position);  //tp指定位置
            }
        }
    } 
}
