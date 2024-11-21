using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;
using Xww;
using xww.dancer.data;

namespace xww.dancer;

public class danhelp
{
    public static bool Checkaoe()  //检测aoe 范围
    {
        if (TargetHelper.GetNearbyEnemyCount(4) >= 3)
        {
            return true;
        }

        return false;
    }

    public static Spell NextStep()
    {
        return Core.Resolve<JobApi_Dancer>().NextStep.GetSpell();
    }

    public static void Auto舞伴()
    {
        if (Core.Me.Level<60 || Core.Me.HasAura(danbuff.闭式舞姿)||PartyHelper.Party.Count==1)
        {
            return;
        }
        LogHelper.Print("qqq");
        var dps = PartyHelper.CastableDps;
        var t = PartyHelper.CastableTanks;
        var h = PartyHelper.CastableHealers;
        var p = PartyHelper.Party;
        var i = PartyHelper.Party.Count;
        if (i == 2 && new Spell(danoffgcd.闭式舞姿,p[1]).IsReadyWithCanCast())
        {
            AI.Instance.BattleData.NextSlot = new Slot();
            AI.Instance.BattleData.NextSlot.Add(new Spell(danoffgcd.闭式舞姿,p[1]));
            return;
        }

        if (i > 2)
        {
            foreach (var dd in dps)
            {
                if (dd != Core.Me &&!dd.HasAura(danbuff.舞伴)&& new Spell(danoffgcd.闭式舞姿,dd).IsReadyWithCanCast())
                {
                    AI.Instance.BattleData.NextSlot = new Slot();
                    AI.Instance.BattleData.NextSlot.Add(new Spell(danoffgcd.闭式舞姿,dd));
                    return;
                }
            }
            foreach (var dd in t)
            {
                if (dd != Core.Me &&!dd.HasAura(danbuff.舞伴)&&new Spell(danoffgcd.闭式舞姿,dd).IsReadyWithCanCast())
                {
                    AI.Instance.BattleData.NextSlot = new Slot();
                    AI.Instance.BattleData.NextSlot.Add(new Spell(danoffgcd.闭式舞姿,dd));
                    return;
                }
            }
            foreach (var dd in h)
            {
                if (dd != Core.Me &&!dd.HasAura(danbuff.舞伴)&& new Spell(danoffgcd.闭式舞姿,dd).IsReadyWithCanCast())
                {
                    AI.Instance.BattleData.NextSlot = new Slot();
                    AI.Instance.BattleData.NextSlot.Add(new Spell(danoffgcd.闭式舞姿,dd));
                    return;
                }
            }
        }
    }
    public static bool Isben()
    {
        return Core.Resolve<MemApiCondition>().IsBoundByDuty();
    }
}