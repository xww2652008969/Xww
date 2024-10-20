using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;

namespace Xww.vp;

public class Vpaoe:ISlotResolver
{
    public int Check()
    {
        if (Vphelp.Stop())
        {
            return -1001;  
        }
        if (Core.Me.Level < 25)
        {
            return -25;
        }
        if (!Vphelp.Checkaoe())
        {
            return -100;
        }
        {
            
        }
        if (Vphelp.Checkaoe())
        {
            return 1;
        }

        return 1;
    }

    public Spell GetSpell()
    {
        if (Vphelp.GetLastaoeCombo()==1)
        {
            if (Core.Me.HasAura(Vpbuff.咬噬锐牙)|| !Core.Me.HasAura(Vpbuff.穿裂锐牙))
            {
                return VpGcdSpellid.咬噬尖牙.GetSpell();
            }

            if (Core.Me.Level < 35)
            {
                return VpGcdSpellid.咬噬尖牙.GetSpell();
            }
            return VpGcdSpellid.穿裂尖牙.GetSpell();
        }

        if (Vphelp.GetLastaoeCombo()==2)
        {
            if (Vphelp.bufftimeleft(Vpbuff.猛袭) < Vphelp.bufftimeleft(Vpbuff.疾速))
            {
                return VpGcdSpellid.猛袭利牙.GetSpell();
            }

            if (Core.Me.Level < 45)
            {
                return VpGcdSpellid.猛袭利牙.GetSpell();
            }
            return VpGcdSpellid.疾速利牙.GetSpell();
        }

        if (Core.Me.HasAura(Vpbuff.乱击锐牙))
        {
            return VpGcdSpellid.乱击獠牙.GetSpell();
        }
        return VpGcdSpellid.乱裂獠牙.GetSpell();
    }
    public void Build(Slot slot)
    {
        slot.Add(GetSpell());
    }
}