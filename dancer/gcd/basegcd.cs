using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using xww.dancer.data;

namespace xww.dancer.gcd;

public class basegcd:ISlotResolver
{
    public int Check()
    {
        if (QT.QTGET("停手"))
        {
            return -100;
        }
        
        
        if (danhelp.Checkaoe())
        {
            return -1;
        }

        return 1;
    }

    public void Build(Slot slot)
    {
        slot.Add(setspell());
    }

    public Spell setspell()
    {
        if (Core.Me.HasAura(danbuff.对称投掷)|| Core.Me.HasAura(danbuff.对称投掷百花争艳))
        {
            return dangcd.逆瀑泻.GetSpell();
        }

        if (Core.Me.HasAura(danbuff.非对称投掷)|| Core.Me.HasAura(danbuff.非对称投掷百花争艳))
        {
            return dangcd.坠喷泉.GetSpell();
        }
        if ((Core.Resolve<MemApiSpell>().GetLastComboSpellId() == 0 || Core.Resolve<MemApiSpell>().GetLastComboSpellId() == dangcd.喷泉)&& !Core.Me.HasAura(danbuff.对称投掷))
        {
            return dangcd.瀑泻.GetSpell();
        }

        if ((Core.Resolve<MemApiSpell>().GetLastComboSpellId() == dangcd.瀑泻)&& !Core.Me.HasAura(danbuff.非对称投掷))
        {
            return dangcd.喷泉.GetSpell();
        }
        
        return dangcd.瀑泻.GetSpell();
    }
}