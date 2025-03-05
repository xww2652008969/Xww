using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using xww.vp;

namespace Xww.vp;

internal class Vphelp
{
    //获取基础连击的阶段
    public static int GetLastCombo()
    {
        var a = Core.Resolve<MemApiSpell>().CheckActionChange(VpGcdSpellid.咬噬尖齿);
        if (a is VpGcdSpellid.咬噬尖齿 or VpGcdSpellid.穿裂尖齿) return 1;
        return a is VpGcdSpellid.疾速利齿 or VpGcdSpellid.猛袭利齿 ? 2 : 3;
    }

    public static int GetLastaoeCombo()
    {
        var a = Core.Resolve<MemApiSpell>().CheckActionChange(VpGcdSpellid.咬噬尖牙);
        return a switch
        {
            VpGcdSpellid.咬噬尖牙 or VpGcdSpellid.穿裂尖牙 => 1,
            VpGcdSpellid.疾速利牙 or VpGcdSpellid.猛袭利牙 => 2,
            _ => 3
        };
    }

    public static int bufftimeleft(int id)
    {
        var idd = (uint)id;
        return Core.Resolve<MemApiBuff>().GetAuraTimeleft(Core.Me, idd, true);
    }

    public static float GetVicewinderCharges() //获取蛇连击充能数
    {
        return Core.Resolve<MemApiSpell>().GetCharges(VpGcdSpellid.强碎灵蛇);
    }

    public static void Ss2(Slot slot) //先连后乱
    {
        slot.Add(VpGcdSpellid.猛袭盘蛇.GetSpell());
        if (Core.Me.Level < 75) return;
        slot.Add(VpOffGcdSpellid.双牙连击.GetSpell());
        slot.Add(VpOffGcdSpellid.双牙乱击.GetSpell());
    }

    public static void Ss1(Slot slot) //先乱后连
    {
        slot.Add(VpGcdSpellid.疾速盘蛇.GetSpell());
        if (Core.Me.Level < 75) return;
        slot.Add(VpOffGcdSpellid.双牙乱击.GetSpell());
        slot.Add(VpOffGcdSpellid.双牙连击.GetSpell());
    }

    public static void ss1aoe(Slot slot)
    {
        slot.Add(VpGcdSpellid.疾速盘蝰.GetSpell());
        if (Core.Me.Level < 80) return;
        slot.Add(VpOffGcdSpellid.双牙乱闪.GetSpell());
        slot.Add(VpOffGcdSpellid.双牙连闪.GetSpell());
    }

    public static void ss2aoe(Slot slot)
    {
        slot.Add(VpGcdSpellid.猛袭盘蝰.GetSpell());
        if (Core.Me.Level < 80) return;
        slot.Add(VpOffGcdSpellid.双牙连闪.GetSpell());
        slot.Add(VpOffGcdSpellid.双牙乱闪.GetSpell());
    }

    public static ISlotResolver? Nextslot()
    {
        return Slotlist.ViperSlotResolvers
            .Where(s => s.SlotMode == SlotMode.Gcd && s.SlotResolver.Check() > 0)
            .Select(s => s.SlotResolver)
            .FirstOrDefault();
    }

    public static bool Checkaoe() //检测aoe 范围
    {
        return TargetHelper.GetNearbyEnemyCount(4) >= 3;
    }

    public static float Distance() //计算目标到自己距离
    {
        return Core.Me.GetCurrTarget() == null ? 0f : Core.Me.GetCurrTarget().Distance(Core.Me);
    }

    public static bool Stop() //检测停手
    {
        return QT.QTGET("停手");
    }

    public static int 飞蛇之魂()
    {
        return Core.Resolve<JobApi_Viper>().RattlingCoilStacks;
    }
}