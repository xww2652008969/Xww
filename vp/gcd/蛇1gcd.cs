using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using Xww.vp;

namespace xww.vp
{
    internal class 蛇1gcd : ISlotResolver
    {
        public void Build(Slot slot)
        {
            if (VpGcdSpellid.猛袭盘蛇.IsReady()||VpGcdSpellid.疾速盘蛇.IsReady())
            {
                Vphelp.Ss1(slot);
            }
            else
            {
                slot.Add(VpGcdSpellid.强碎灵蛇.GetSpell());
               
            }

            if (VpGcdSpellid.疾速盘蛇.IsReady() && !VpGcdSpellid.猛袭盘蛇.IsReady())
            {
                Vphelp.Ss1(slot);  //防手贱
            }

        }

        public int Check()
        {
            if (Vphelp.Stop())
            {
                return -1001;  
            }
            if (Vphelp.Distance() > 3.0)
            {
                return -3;
            }
            if (Vphelp.Checkaoe())
            {
                return -100;
            }
            if (Vphelp.Distance() > 3.0)
            {
                return -3;
            }
            if (Core.Me.Level<65)
            {
                return -65;
            }
            if (VpGcdSpellid.疾速盘蛇.IsReady()&& VpGcdSpellid.猛袭盘蛇.IsReady())
            {
                return 2;
            }
            if (VpGcdSpellid.疾速盘蛇.IsReady()&& !VpGcdSpellid.猛袭盘蛇.IsReady())
            {
                return 3;
            }
            if (!VpGcdSpellid.疾速盘蛇.IsReady()&& VpGcdSpellid.猛袭盘蛇.IsReady())
            {
                return -3;
            }

            if (QT.QTGET("留资源")&&!VpGcdSpellid.猛袭盘蛇.IsReady()&&!VpGcdSpellid.疾速盘蛇.IsReady())
            {
                return -20;
            }
            if (QT.QTGET("收尾")&&Vphelp.GetVicewinderCharges()>=1.0)
            {
                return 1;
            }
            if (1.75 <=Vphelp.GetVicewinderCharges() && Vphelp.GetVicewinderCharges() <= 2.0)  //不让蛇连击溢出
            {
                return 1;
            }
            return -100;
        }
    }

    }
