using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using Xww;
using xww.dancer.data;

namespace xww.dancer.gcd;

public class 落幕舞gcd : ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手")) return -100;
        if (xwwhelp.Distance() > 25) return -2;

        if (Core.Resolve<MemApiSpell>().GetCharges(dangcd.技巧舞步) >= 0.79) return -1;
        if (dangcd.落幕舞.GetSpell().IsReadyWithCanCast()) return 1;

        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(setspell());
    }

    public Spell setspell()
    {
        return dangcd.落幕舞.GetSpell();
    }
}