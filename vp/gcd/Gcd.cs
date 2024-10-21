using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;

namespace Xww.vp;

public class Basegcd : ISlotResolver  //基础连击
{

    public void Build(Slot slot)
    {
        var spell = GetSpell();
        if (spell == null)
            return;
        slot.Add(spell);
    }
    private Spell GetSpell()
    {
        if (Vphelp.GetLastCombo() == 1)//状态1
        {
            if (Core.Me.Level < 10)
            {
                Vphelp.Tp(0);
                return VpGcdSpellid.咬噬尖齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.穿裂锐牙))
            {
                Vphelp.Tp(0);
                return VpGcdSpellid.穿裂尖齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.咬噬锐牙))
            {
                Vphelp.Tp(0);
                return VpGcdSpellid.咬噬尖齿.GetSpell();
            }
        }
        if (Vphelp.GetLastCombo() == 2)//状态2  因为初始必定打蛇连快速上buff 所以这里进行buff判断
        {
            if (Core.Me.Level < 20)
            {
                Vphelp.Tp(0);
                return VpGcdSpellid.猛袭利齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.背击锐牙) || Core.Me.HasAura(Vpbuff.背裂锐牙))
            {
                Vphelp.Tp(0);
                return VpGcdSpellid.疾速利齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.侧击锐牙) || Core.Me.HasAura(Vpbuff.侧裂锐牙))
            {
                Vphelp.Tp(0);
                return VpGcdSpellid.猛袭利齿.GetSpell();
            }
            Vphelp.Tp(0);
            return VpGcdSpellid.疾速利齿.GetSpell();
        }
        if (Vphelp.GetLastCombo() == 3)//状态3 后面需要写身位判定先这样写吧
        {
            if (Core.Me.HasAura(Vpbuff.背击锐牙))
            {
                Vphelp.Tp(2);
                return VpGcdSpellid.背击獠齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.背裂锐牙))
            {
                Vphelp.Tp(2);
                return VpGcdSpellid.背裂獠齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.侧击锐牙))
            {
                Vphelp.Tp(1);
                return VpGcdSpellid.侧击獠齿.GetSpell();
               
            }
            if (Core.Me.HasAura(Vpbuff.侧裂锐牙))
            {
                Vphelp.Tp(1);
                return VpGcdSpellid.侧裂獠齿.GetSpell();
            }
        }
        Vphelp.Tp(0);
        return VpGcdSpellid.咬噬尖齿.GetSpell();
    }

    public int Check()
    {
        if (Vphelp.Stop())
        {
            return -1001;  
        }
        if (Vphelp.Checkaoe())
        {
            return -100;
        }
        // if (Vphelp.Distance() > 3.0)
        // {
        //     return -3;
        // }
        if((VpGcdSpellid.猛袭盘蛇.IsReady() || VpGcdSpellid.疾速盘蛇.IsReady()))
        {
            return -3;   //如果使用连连击后  禁止使用基础连击打断
        }
        return 1;
    }
}