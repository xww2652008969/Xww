using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using xww.dancer.data;

namespace xww.dancer.gcd;

public class baseaoe:ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手"))
        {
            return -100;
        }
        if (danhelp.Checkaoe())
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
        if (Core.Me.HasAura(danbuff.对称投掷)|| Core.Me.HasAura(danbuff.对称投掷百花争艳))
        {
            return dangcd.升风车.GetSpell();
        }

        if (Core.Me.HasAura(danbuff.非对称投掷)|| Core.Me.HasAura(danbuff.非对称投掷百花争艳))
        {
            return dangcd.落血雨.GetSpell();
        }
        if ((Core.Resolve<MemApiSpell>().GetLastComboSpellId() == 0 || Core.Resolve<MemApiSpell>().GetLastComboSpellId() == dangcd.落刃雨)&& !Core.Me.HasAura(danbuff.对称投掷))
        {
            return dangcd.风车.GetSpell();
        }

        if ((Core.Resolve<MemApiSpell>().GetLastComboSpellId() == dangcd.风车)&& !Core.Me.HasAura(danbuff.非对称投掷)&& Core.Me.Level>=25)
        {
            return dangcd.落刃雨.GetSpell();
        }
        
        return dangcd.风车.GetSpell();
    }
}