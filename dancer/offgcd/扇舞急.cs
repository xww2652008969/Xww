using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using xww.dancer.data;

namespace xww.dancer.offgcd;

public class 扇舞急:ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手"))
        {
            return -100;
        }
        
        
        if (danoffgcd.扇舞急.GetSpell().IsReadyWithCanCast())
        {
            return 1;
        }

        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(setspell());
    }

    public Spell setspell()
    {
        return danoffgcd.扇舞急.GetSpell();
    }
}