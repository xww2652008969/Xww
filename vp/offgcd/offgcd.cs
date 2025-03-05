using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.MemoryApi;

namespace Xww.vp;

public class Offgcd : ISlotResolver
{
    public void Build(Slot slot)
    {
        var spell = GetSpell();
        if (spell == null)
            return;
        slot.Add(spell);
    }

    public int Check()
    {
        if (Vphelp.Stop()) return -1001;
        if (Core.Resolve<MemApiSpell>().CheckActionChange(VpOffGcdSpellid.蛇尾术).GetSpell()
            .IsReadyWithCanCast()) return 1;
        return -1;
    }

    public Spell GetSpell()
    {
        return Core.Resolve<MemApiSpell>().CheckActionChange(VpOffGcdSpellid.蛇尾术).GetSpell();
    }
}