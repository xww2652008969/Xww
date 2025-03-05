using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using Xww;
using xww.dancer.data;

namespace xww.dancer.offgcd;

public class 扇舞offgcd : ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手")) return -100;
        if (xwwhelp.Distance() > 25) return -2;

        if (Core.Me.HasAura(danbuff.技巧舞步结束) && Core.Resolve<JobApi_Dancer>().FourFoldFeathers > 0) return 2;
        if (Core.Resolve<JobApi_Dancer>().FourFoldFeathers == 4 && !Core.Me.HasAura(danbuff.技巧舞步结束)) return 1;

        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(Setspell());
    }

    public static Spell Setspell()
    {
        if (danhelp.Checkaoe()) return danoffgcd.扇舞破.GetSpell();
        return danoffgcd.扇舞序.GetSpell();
    }
}