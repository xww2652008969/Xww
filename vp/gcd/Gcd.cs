using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using xww.vp;

namespace Xww.vp;

public class Basegcd : ISlotResolver  //基础连击
{
    public void Build(Slot slot)
    {
        slot.Add(GetSpell());
        Vpjobdata.nextgcdid = slot;
    }

    public Slot getslot(Slot slot)
    {
        return slot;
    }

    private Spell GetSpell()
    {
        if (Vphelp.GetLastCombo() == 1)//状态1
        {
            if (Core.Me.Level < 10)
            {
                return VpGcdSpellid.咬噬尖齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.穿裂锐牙))
            {
                return VpGcdSpellid.穿裂尖齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.咬噬锐牙))
            {
                return VpGcdSpellid.咬噬尖齿.GetSpell();
            }
        }
        if (Vphelp.GetLastCombo() == 2)//状态2  因为初始必定打蛇连快速上buff 所以这里进行buff判断
        {
            if (Core.Me.Level < 20)
            {
                return VpGcdSpellid.猛袭利齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.背击锐牙) || Core.Me.HasAura(Vpbuff.背裂锐牙))
            {
                return VpGcdSpellid.疾速利齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.侧击锐牙) || Core.Me.HasAura(Vpbuff.侧裂锐牙))
            {
                return VpGcdSpellid.猛袭利齿.GetSpell();
            }
            return VpGcdSpellid.疾速利齿.GetSpell();
        }
        if (Vphelp.GetLastCombo() == 3)//状态3 后面需要写身位判定先这样写吧
        {
            if (Core.Me.HasAura(Vpbuff.背击锐牙))
            {
                return VpGcdSpellid.背击獠齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.背裂锐牙))
            {
                
                return VpGcdSpellid.背裂獠齿.GetSpell();
            }
            if (Core.Me.HasAura(Vpbuff.侧击锐牙))
            {
                return VpGcdSpellid.侧击獠齿.GetSpell();
               
            }
            if (Core.Me.HasAura(Vpbuff.侧裂锐牙))
            {
                return VpGcdSpellid.侧裂獠齿.GetSpell();
            }
            return Core.Resolve<MemApiSpell>().CheckActionChange( VpGcdSpellid.背击獠齿.GetSpell().Id).GetSpell();
        }
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
        if (Vphelp.Distance() > JOBSettings.Instance.Maxmeleerange)
        {
            return -3;
        }
        if((VpGcdSpellid.猛袭盘蛇.IsReady() || VpGcdSpellid.疾速盘蛇.IsReady()))
        {
            return -3;   //如果使用连连击后  禁止使用基础连击打断
        }
        return 1;
    }
}