using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using xww.dancer.data;

namespace xww.dancer.gcd;

public class 大舞gcd : ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手")) return -100;

        if (dangcd.技巧舞步.GetSpell().IsReadyWithCanCast() || Core.Me.HasAura(danbuff.技巧舞步)) return 1;
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(setspell());
        if (setspell().Id == dangcd.技巧舞步结束) slot.Add(danoffgcd.进攻之探戈.GetSpell());
    }

    public Spell setspell()
    {
        if (Core.Me.HasAura(danbuff.技巧舞步))
        {
            if (Core.Resolve<JobApi_Dancer>().CompleteSteps == 4) return dangcd.技巧舞步结束.GetSpell();
            return Core.Resolve<JobApi_Dancer>().NextStep.GetSpell();
        }

        return dangcd.技巧舞步.GetSpell();
    }
}