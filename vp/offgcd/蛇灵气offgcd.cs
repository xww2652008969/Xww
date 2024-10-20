using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.JobApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xww.vp
{
    internal class 蛇灵气offgcd : ISlotResolver
    {
        
        public void Build(Slot slot)
        {
            slot.Add(VpOffGcdSpellid.蛇灵气.GetSpell());
        }

        public int Check()
        {
            if (Vphelp.Stop())
            {
                return -1001;  
            }

            if (QT.QTGET("留资源"))
            {
                return -20;
            }
            if (VpOffGcdSpellid.蛇灵气.IsReady()&& Core.Resolve<JobApi_Viper>().RattlingCoilStacks<3)
            {
                return 1;
            }
            return -1;
        }
    }
}
