using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.JobApi;

namespace Xww.vp
{
    internal class 飞蛇gcd : ISlotResolver
    {
        public void Build(Slot slot)
        {
            slot.Add(VpGcdSpellid.飞蛇之尾.GetSpell());
            if (Core.Me.Level<92)
            {
                return;
            }
            slot.Add(VpOffGcdSpellid.飞蛇连尾击.GetSpell());
            slot.Add(VpOffGcdSpellid.飞蛇乱尾击.GetSpell());
            Vpjobdata.nextgcdid =slot;
        }

        public int Check()
        {
            if (Vphelp.Stop())
            {
                return -1001;  
            }
            if (Core.Me.Level < 82)
            {
                return -82;
            }
            if (Vphelp.Distance() > 17.0+JOBSettings.Instance.Maxmeleerange)
            {
                return -20;
            }

            if (QT.QTGET("留资源"))
            {
                return -30;
            }
            if (QT.QTGET("收尾")&&Core.Resolve<JobApi_Viper>().RattlingCoilStacks>0)
            {
                return 4;
            }
            
            
            if (QT.QTGET("飞蛇之尾") && Vphelp.Distance() > 3.0&&Core.Resolve<JobApi_Viper>().RattlingCoilStacks>0)
            {
                return 3;
            }
            if (Core.Resolve<JobApi_Viper>().RattlingCoilStacks>=JOBSettings.Instance.Maxfeishe&&Core.Resolve<JobApi_Viper>().RattlingCoilStacks!=0)  
            {
                return 1;  
            }
            return -1;
        }
    }
}
