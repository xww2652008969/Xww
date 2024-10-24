using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;

namespace Xww.vp;

public class 蛇aoe:ISlotResolver
{
    public int Check()
    {
        if (Vphelp.Stop())
        {
            return -1001;  
        }
        if (!Vphelp.Checkaoe())
        {
            return -100;
        }
        if (Core.Me.Level<70)
        {
            return -70;
        }
        if (VpGcdSpellid.疾速盘蝰.IsReady() || VpGcdSpellid.猛袭盘蝰.IsReady())
        {
            return 2;
        }

        if (QT.QTGET("留资源")&&(!VpGcdSpellid.疾速盘蝰.IsReady() || !VpGcdSpellid.猛袭盘蝰.IsReady()))
        {
            return -20;
        }
        if (1.75 <=Vphelp.GetVicewinderCharges() && Vphelp.GetVicewinderCharges() <= 2.0)  //不让蛇连击溢出
        {
            return 1;
        }

        return -1;
    }

    public void Build(Slot slot)
    {
        GetSpell(slot);
        Vpjobdata.nextgcdid = slot;
    }

    private static void GetSpell(Slot slot)
    {
        if (VpGcdSpellid.疾速盘蝰.IsReady())
        {
             Vphelp.ss1aoe(slot);
             return;
        }

        if (VpGcdSpellid.猛袭盘蝰.IsReady())
        {
           Vphelp.ss2aoe(slot);
           return;
        }

        slot.Add(VpGcdSpellid.强碎灵蝰.GetSpell());
    }
}