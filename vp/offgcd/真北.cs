using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using xww.vp;

namespace Xww.vp;

public class 真北 : ISlotResolver
{
    public int Check()
    {
        var netslot = Vphelp.Nextslot();
        if (netslot == null)
            return -1;
        if (Vphelp.Stop()) return -1001;
        if (!QT.QTGET("动态真北")) return -10;
        if (!VpOffGcdSpellid.真北.GetSpell().IsReadyWithCanCast()) //没转好
            return -9;

        if (Core.Me.HasAura(Vpbuff.真北)) //身上有真北
            return -8;

        if (Core.Me.GetCurrTarget() == null) return -9;
        if (Core.Me.GetCurrTarget().HasPositional()) //身位判断
        {
            if (netslot.GetType() == typeof(Basegcd))
            {
                if (Core.Me.HasAura(Vpbuff.背击锐牙) || Core.Me.HasAura(Vpbuff.背裂锐牙))
                    if (!Core.Resolve<MemApiTarget>().IsBehind && Vphelp.GetLastCombo() == 3)
                        return 11;
                if (Core.Me.HasAura(Vpbuff.侧击锐牙) || (Core.Me.HasAura(Vpbuff.侧裂锐牙) && Vphelp.GetLastCombo() == 3))
                    if (!Core.Resolve<MemApiTarget>().IsFlanking)
                        return 12;
            }

            if (netslot.GetType() == typeof(蛇Gcd))
                if (Core.Me.Level >= 75 && SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimesInGcd == 3)
                {
                    if (netslot.Check() == 1)
                        if (Core.Resolve<MemApiTarget>().IsBehind)
                            return 1;
                    if (netslot.Check() == 2)
                        if (Core.Resolve<MemApiTarget>().IsFlanking)
                            return 2;

                    if (netslot.Check() == 3)
                        if (!Core.Resolve<MemApiTarget>().IsFlanking && Core.Resolve<MemApiTarget>().IsBehind)
                            return 3;
                }
        }

        return -2;
    }

    public void Build(Slot slot)
    {
        slot.Add(VpOffGcdSpellid.真北.GetSpell());
    }
}