using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using xww.dancer.data;

namespace xww.dancer.gcd;

public class 小舞gcd:ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手"))
        {
            return -100;
        }

        if (Core.Me.HasAura(danbuff.落幕舞预备))
        {
            return -1;
        }
        
        if (dangcd.标准舞步.GetSpell().IsReadyWithCanCast() || Core.Me.HasAura(danbuff.标准舞步))
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
        if (Core.Me.HasAura(danbuff.标准舞步))
        {
            if (Core.Resolve<JobApi_Dancer>().CompleteSteps==2)
            {
                return dangcd.标准舞步结束.GetSpell();
            }
            return Core.Resolve<JobApi_Dancer>().NextStep.GetSpell();
        }
        return dangcd.标准舞步.GetSpell();
    }
}