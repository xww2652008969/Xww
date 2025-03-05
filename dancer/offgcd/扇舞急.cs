using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using Xww;
using xww.dancer.data;

namespace xww.dancer.offgcd;

public class 扇舞急 : ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手")) return -100;

        if (xwwhelp.Distance() > 25) return -2;
        if (danoffgcd.扇舞急.GetSpell().IsReadyWithCanCast()) return 1;

        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(Setspell());
    }

    private static Spell Setspell()
    {
        return danoffgcd.扇舞急.GetSpell();
    }
}