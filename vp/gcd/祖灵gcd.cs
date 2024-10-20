using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;

namespace Xww.vp
{
    internal class 祖灵gcd : ISlotResolver
    {
        public void Build(Slot slot)
        {
            var s = GetSpell();
            if (s != null) {
                slot.Add(s);
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
            if (!Core.Me.HasAura(Vpbuff.疾速) ||! Core.Me.HasAura(Vpbuff.猛袭))
            {
                return -2;  //没buff 还想打爆发？？？
            }

            if ((VpGcdSpellid.猛袭盘蛇.IsReady() || VpGcdSpellid.猛袭盘蝰.IsReady() || VpGcdSpellid.疾速盘蛇.IsReady() || VpGcdSpellid.疾速盘蝰.IsReady())&&!Core.Me.HasAura(Vpbuff.祖灵降临buff))
            {
                return -1;  //会断蛇连 优先蛇
            }
            
            if (((Vphelp.bufftimeleft(Vpbuff.猛袭) < 15000 || Vphelp.bufftimeleft(Vpbuff.疾速) < 15000)&&!Core.Me.HasAura(Vpbuff.祖灵降临buff)))
            {
                return -3;  //双buf时间不够  先补充buff  
            }

            if (QT.QTGET("留资源")&&!Core.Me.HasAura(Vpbuff.祖灵降临buff))
            {
               return -4;  //保留资源不打小怪 
            }
            if (QT.QTGET("收尾")&&(Core.Resolve<JobApi_Viper>().SerpentOffering >= 50||Core.Me.HasAura(Vpbuff.祖灵降临预备)))
            {
                return 1;
            }
            if(Core.Resolve<MemApiSpell>().GetCharges(VpOffGcdSpellid.蛇灵气)<1.0&& Core.Resolve<MemApiSpell>().GetCharges(VpOffGcdSpellid.蛇灵气) > 0.7&& !Core.Me.HasAura(Vpbuff.祖灵降临buff))
            {
                return -3;  //要打双附体
            }
            if (Core.Me.HasAura(Vpbuff.祖灵降临预备)){
                return 3;//有预备直接打
            }
            if (Core.Me.HasAura(Vpbuff.祖灵降临buff))
            {
                return 2;  //祖灵状态直接打
            }
            if (Core.Resolve<JobApi_Viper>().SerpentOffering >= 50)
            {
                return 1;   //大于指定值释放祖灵gcd
            }
            return -1;
        }
        public Spell GetSpell()
        {
         
            if (Core.Me.Level >= 96)
            {
                if (Core.Resolve<JobApi_Viper>().AnguineTribute== 5)
                {
                    return VpGcdSpellid.祖灵之牙一式.GetSpell();
                }
                if (Core.Resolve<JobApi_Viper>().AnguineTribute == 4)
                {
                    return VpGcdSpellid.祖灵之牙二式.GetSpell();
                }
                if (Core.Resolve<JobApi_Viper>().AnguineTribute == 3)
                {
                    return VpGcdSpellid.祖灵之牙三式.GetSpell();
                }
                if (Core.Resolve<JobApi_Viper>().AnguineTribute == 2)
                {
                    return VpGcdSpellid.祖灵之牙四式.GetSpell();
                }
                if (Core.Resolve<JobApi_Viper>().AnguineTribute == 1)
                {
                    return VpGcdSpellid.祖灵大蛇牙.GetSpell();
                }
            }
            if (Core.Me.Level < 96)
            {
                if (Core.Resolve<JobApi_Viper>().AnguineTribute == 4)
                {
                    return VpGcdSpellid.祖灵之牙一式.GetSpell();
                }
                if (Core.Resolve<JobApi_Viper>().AnguineTribute == 3)
                {
                    return VpGcdSpellid.祖灵之牙二式.GetSpell();
                }
                if (Core.Resolve<JobApi_Viper>().AnguineTribute == 2)
                {
                    return VpGcdSpellid.祖灵之牙三式.GetSpell();
                }
                if (Core.Resolve<JobApi_Viper>().AnguineTribute == 1)
                {
                    return VpGcdSpellid.祖灵之牙四式.GetSpell();
                }
            }
            return VpGcdSpellid.祖灵降临.GetSpell();
        }
    }
}
