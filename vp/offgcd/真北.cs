using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;

namespace Xww.vp;

public class 真北:ISlotResolver
{
    public int Check()
    {
        if (Vphelp.Stop())
        {
            return -1001;  
        }
        if (!QT.QTGET("动态真北"))
        {
            return -10;
        }
        if (!VpOffGcdSpellid.真北.IsReady())  //没转好
        {
            return -9;
        }

        if (Core.Me.HasAura(Vpbuff.真北))   //身上有真北
        {
            return -8;
        }
        
        var t1 = (Core.Resolve<MemApiSpellCastSuccess>().LastGcdSuccesTime + 2000 - TimeHelper.Now()) < 2000;
        if (Core.Me.GetCurrTarget().HasPositional() && t1)//身位判断
        {
            if ( Vpjobdata.LastGcdid != VpGcdSpellid.强碎灵蛇 && (Vpjobdata.蛇1lunck && Vpjobdata.蛇0lunck && Vpjobdata.蛇2lunck)&&!Core.Me.HasAura(Vpbuff.祖灵降临buff) && Vphelp.GetLastCombo()==3)//不打蛇连且不在祖灵状态
            {
                if (Core.Me.HasAura(Vpbuff.背击锐牙) || Core.Me.HasAura(Vpbuff.背裂锐牙)&&(!Core.Me.HasAura(Vpbuff.侧击锐牙) &&!Core.Me.HasAura(Vpbuff.侧裂锐牙)))
                {
                    if (!Core.Resolve<MemApiTarget>().IsBehind)
                    {
                        return 1;
                    }
                }
                if (Core.Me.HasAura(Vpbuff.侧击锐牙) || Core.Me.HasAura(Vpbuff.侧裂锐牙))
                {
                    if (!Core.Resolve<MemApiTarget>().IsFlanking)
                    {
                        return 2;
                    }
                }
            }
            if(Vpjobdata.LastGcdid==VpGcdSpellid.强碎灵蛇  || Vpjobdata.LastGcdid == VpGcdSpellid.疾速盘蛇)
            {
                if(Vpjobdata.LastGcdid == VpGcdSpellid.强碎灵蛇)
                {
                    if (!Core.Resolve<MemApiTarget>().IsBehind)
                    {
                        return 1;
                    }
                }
                if( Vpjobdata.LastGcdid == VpGcdSpellid.疾速盘蛇)
                {
                    if (!Core.Resolve<MemApiTarget>().IsFlanking)
                    {
                        return 1;
                    }

                }
            }
        }

        return -1;
    }

    public void Build(Slot slot)
    {
        slot.Add(VpOffGcdSpellid.真北.GetSpell());
    }
}