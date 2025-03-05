using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using xww.dancer.data;

namespace xww.dancer.offgcd;

public class 百花 : ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手")) return -100;


        if (Core.Resolve<MemApiSpell>().GetCharges(dangcd.技巧舞步) > 0.95) return -1;
        if (danoffgcd.百花争艳.GetSpell().IsReadyWithCanCast()) return 1;

        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(danoffgcd.百花争艳.GetSpell());
    }
}