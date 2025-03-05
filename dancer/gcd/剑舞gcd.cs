using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using Xww;
using xww.dancer.data;

namespace xww.dancer.gcd;

public class 剑舞gcd : ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手")) return -100;

        if (xwwhelp.Distance() > 25) return -2;
        if (Core.Resolve<JobApi_Dancer>().Esprit >= 50 && Core.Me.HasAura(danbuff.技巧舞步结束) &&
            dangcd.剑舞.GetSpell().IsReadyWithCanCast()) return 1;


        if (Core.Resolve<JobApi_Dancer>().Esprit >= JOBSettings.Instance.Maxlinli &&
            dangcd.剑舞.GetSpell().IsReadyWithCanCast() && !Core.Me.HasAura(danbuff.技巧舞步)) return 1;

        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(setspell());
    }

    public Spell setspell()
    {
        return dangcd.剑舞.GetSpell();
    }
}