using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;

namespace Xww.vp
{
    internal class 蛇2gcd : ISlotResolver
    {
        public void Build(Slot slot)
        {
            if (VpGcdSpellid.猛袭盘蛇.GetSpell().IsReadyWithCanCast()&&!VpGcdSpellid.疾速盘蛇.GetSpell().IsReadyWithCanCast())
            {
                Vphelp.Ss2(slot);
                Vpjobdata.nextgcdid = slot;
                return;
            }
        }

        public int Check()
        {
            if (Vphelp.Stop())
            {
                return -1001;  
            }
            if (Vphelp.Distance() > JOBSettings.Instance.Maxmeleerange)
            {
                return -3;
            }
            if (Vphelp.Checkaoe())
            {
                return -100;
            }
            if (Core.Me.Level<65)
            {
                return -65;
            }
            if (!VpGcdSpellid.疾速盘蛇.GetSpell().IsReadyWithCanCast()&& VpGcdSpellid.猛袭盘蛇.GetSpell().IsReadyWithCanCast())
            {
                return 2;
            }
            if (QT.QTGET("留资源")&&!VpGcdSpellid.猛袭盘蛇.GetSpell().IsReadyWithCanCast()&&!VpGcdSpellid.疾速盘蛇.GetSpell().IsReadyWithCanCast())
            {
                return -20;
            }
            if (QT.QTGET("收尾")&&VpGcdSpellid.猛袭盘蛇.GetSpell().IsReadyWithCanCast()&&Vphelp.GetVicewinderCharges()>=1.0)
            {
                return 1;
            }
            if (Vphelp.GetVicewinderCharges()>=JOBSettings.Instance.Maxshelian)//不让蛇连击溢出
            {
                return 1;
            }
            return -100;
        }
    }
}
