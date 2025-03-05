using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;

namespace Xww.vp;

public class 飞蛇之牙gcd : ISlotResolver
{
    public int Check()
    {
        if (Vphelp.Stop()) return -1001;
        if (Vphelp.Distance() > JOBSettings.Instance.Maxmeleerange + 3.0 &&
            Vphelp.Distance() <= 20.0 + JOBSettings.Instance.Maxmeleerange &&
            VpGcdSpellid.飞蛇之牙.GetSpell().IsReadyWithCanCast()) return 1;
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(VpGcdSpellid.飞蛇之牙.GetSpell());
        Vpjobdata.nextgcdid = slot;
    }
}