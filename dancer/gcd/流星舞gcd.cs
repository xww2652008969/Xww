using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using xww.dancer.data;

namespace xww.dancer.gcd;

public class 流星舞gcd:ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手"))
        {
            return -100;
        }
        
        
        if (dangcd.流星舞.GetSpell().IsReadyWithCanCast())
        {
            return 1;
        }
        
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(dangcd.流星舞.GetSpell());
    }
}