using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using Xww;
using Xww.vp;

namespace xww.vp;

internal class 蛇Gcd : ISlotResolver
{
    public void Build(Slot slot)
    {
        var ta = Core.Me.GetCurrTarget();
        if (ta != null && (VpGcdSpellid.猛袭盘蛇.GetSpell().IsReadyWithCanCast() ||
                           VpGcdSpellid.疾速盘蛇.GetSpell().IsReadyWithCanCast()))
        {
            if (ta.HasPositional())
            {
                if (Core.Resolve<MemApiTarget>().IsBehind && VpGcdSpellid.疾速盘蛇.GetSpell().IsReadyWithCanCast())
                {
                    Vphelp.Ss1(slot);
                    return;
                }

                if (Core.Resolve<MemApiTarget>().IsFlanking && VpGcdSpellid.猛袭盘蛇.GetSpell().IsReadyWithCanCast())
                {
                    Vphelp.Ss2(slot);
                    return;
                }
            }

            if (VpGcdSpellid.疾速盘蛇.GetSpell().IsReadyWithCanCast())
            {
                Vphelp.Ss1(slot);
                return;
            }

            if (VpGcdSpellid.猛袭盘蛇.GetSpell().IsReadyWithCanCast())
            {
                Vphelp.Ss2(slot);
                return;
            }
        }

        slot.Add(VpGcdSpellid.强碎灵蛇.GetSpell());
    }

    public int Check()
    {
        if (Vphelp.Stop()) return -1001;
        if (Vphelp.Checkaoe()) return -101;
        if (Vphelp.Distance() > JOBSettings.Instance.Maxmeleerange + 3.0) return -3;
        if (Core.Me.Level < 65) return -65;

        if (VpGcdSpellid.疾速盘蛇.GetSpell().IsReadyWithCanCast() &&
            VpGcdSpellid.猛袭盘蛇.GetSpell().IsReadyWithCanCast()) return 4;
        if (VpGcdSpellid.疾速盘蛇.GetSpell().IsReadyWithCanCast()) return 1;

        if (VpGcdSpellid.猛袭盘蛇.GetSpell().IsReadyWithCanCast()) return 2;

        if (QT.QTGET("留资源")) return -20;
        if (QT.QTGET("收尾") && Vphelp.GetVicewinderCharges() >= 1.0) return 2;
        if (Vphelp.GetVicewinderCharges() >= JOBSettings.Instance.Maxshelian) //大于蛇连设定值就打
            return 3;
        return -100;
    }
}