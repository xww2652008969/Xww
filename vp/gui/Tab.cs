using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.Extension;
using AEAssist.Helper;
using ImGuiNET;
using Xww;
using Xww.vp;

namespace xww.vp.gui;

public class Tab
{
    public static void createTab(JobViewWindow gui)
    {
        if (AEAssist.Share.LocalContentId == "18014469510992065")
        {
            gui.AddTab("dev", dev);  //开发者查看信息用的
        }
            
        gui.AddTab("全局设置",Vpsetting.createsetting);
        gui.AddTab("TP队友",Tp);
        gui.AddTab("TPB标点",Tp2);
    }
    public static void dev(JobViewWindow jobViewWindow)
    {
        if (xwwhelp.isCurrTriggerLine())
        {
            ImGui.TextDisabled(xwwhelp.CurrTriggerLine().Name);
            ImGui.TextDisabled(JOBSettings.Instance.Maxfeishec.ToString());

        } // JOBSettings i = JOBSettings.Instance;
        // ImGui.Text(i.TpDelay.ToString());
        // ImGui.TextUnformatted(Core.Me.Position.ToString());
        // ImGui.TextUnformatted("GCD冷却剩余" + GCDHelper.GetGCDCooldown().ToString());
        // if (Vpjobdata.nextgcdid.Actions.Count!=0)
        // {
        //     ImGui.TextUnformatted("下一个GCD:"+Core.Resolve<MemApiSpell>().GetName(Vpjobdata.nextgcdid.Actions.Peek().Spell.Id));
        // }
        // ImGui.TextUnformatted(Vphelp.Distance().ToString());
        // ImGui.TextUnformatted(Core.Me.GetCurrTarget().HitboxRadius.ToString());
    }
    public static void Tp(JobViewWindow jobViewWindow)
    {
        foreach (var p in PartyHelper.CastableTanks)
        {
                    
            if (p!=Core.Me)
            { 
                if (ImGui.Button(p.Name.ToString()))
                { 
                    Core.Me.SetPos(p.Position);
                }
            }
        }
    
        foreach (var p in PartyHelper.CastableHealers)
        {
            if (p!=Core.Me)
            {
                if (ImGui.Button(p.Name.ToString()))
                {
                    Core.Me.SetPos(p.Position);
                }
            }
        }
        foreach (var p in PartyHelper.CastableDps)
        {
            if (p!=Core.Me)
            {
                if (ImGui.Button(p.Name.ToString()))
                {
                    Core.Me.SetPos(p.Position);
                }
            }
        }
    }
    public static void Tp2(JobViewWindow jobViewWindow)
    {
        if (ImGui.Button("A"))
        {
            Core.Me.SetPos(xwwhelp.Getflag(0));
        }
        if (ImGui.Button("B"))
        {
            Core.Me.SetPos(xwwhelp.Getflag(1));
        }
        if (ImGui.Button("C"))
        {
            Core.Me.SetPos(xwwhelp.Getflag(2));
        }
        if (ImGui.Button("D"))
        {
            Core.Me.SetPos(xwwhelp.Getflag(3));
        }
        if (ImGui.Button("1"))
        {
            Core.Me.SetPos(xwwhelp.Getflag(4));
        }
        if (ImGui.Button("2"))
        {
            Core.Me.SetPos(xwwhelp.Getflag(5));
        }
        if (ImGui.Button("3"))
        {
            Core.Me.SetPos(xwwhelp.Getflag(6));
                
        }
        if (ImGui.Button("4"))
        {
            Core.Me.SetPos(xwwhelp.Getflag(7));
                
        }
            
    }
}