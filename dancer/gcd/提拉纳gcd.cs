using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.JobApi;
using xww.dancer.data;

namespace xww.dancer.gcd;

public class 提拉纳gcd:ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手"))
        {
            return -100;
        }
        
        
        if (Core.Resolve<JobApi_Dancer>().Esprit > 50)
        {
            return -1;
        }
        
        if (dangcd.提拉纳.GetSpell().IsReadyWithCanCast())
        {
            return 1;
        }
        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(dangcd.提拉纳.GetSpell());
    }
}