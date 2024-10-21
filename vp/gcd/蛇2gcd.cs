using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;

namespace Xww.vp
{
    internal class 蛇2gcd : ISlotResolver
    {
        public void Build(Slot slot)
        {
            if (Vpjobdata.get蛇数() == 2)
            {
                Vphelp.Tp(1);
                Vphelp.Ss2(slot);
                Vpjobdata.蛇数();
                return;
            }

        }

        public int Check()
        {
            if (Vphelp.Stop())
            {
                return -1001;  
            }
            // if (Vphelp.Distance() > 3.0)
            // {
            //     return -3;
            // }
            if (Vphelp.Checkaoe())
            {
                return -100;
            }
            if (Core.Me.Level<65)
            {
                return -65;
            }
            if (Vpjobdata.get蛇数() == 2)
            {
                return 1;
            }
            if (QT.QTGET("留资源")&&!VpGcdSpellid.猛袭盘蛇.IsReady()&&!VpGcdSpellid.疾速盘蛇.IsReady())
            {
                return -20;
            }
            if (QT.QTGET("收尾")&&VpGcdSpellid.猛袭盘蛇.IsReady()&&Vphelp.GetVicewinderCharges()>=1.0)
            {
                return 1;
            }
            return -100;
        }
    }
}
