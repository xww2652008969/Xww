using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View;
using AEAssist.Extension;
using AEAssist.MemoryApi;
using Xww;
using Xww.vp;

namespace xww.vp;

internal class Vpenevt : IRotationEventHandler
{
    public void AfterSpell(Slot slot, Spell spell)
    {
    }

    public void OnBattleUpdate(int currTimeInMs)
    {
        if (QT.QTGET("留资源")) QT.QTSET("收尾", false); //资源互斥
        //Vphelp.Tp();  //tp

        if (Core.Me.HasAura(Vpbuff.祖灵降临buff) || Core.Me.HasAura(Vpbuff.真北))
            MeleePosHelper.Draw(MeleePosHelper.Pos.Flank, 0);
    }

    public void OnEnterRotation()
    {
        if (SettingMgr.GetSetting<GeneralSettings>().MaxAbilityTimesInGcd < 3)
        {
            Core.Resolve<MemApiChatMessage>().Toast2("由于你设置Gcd内最大能力技小于3所以蛇连因为2个续剑的原因不会在其中插入真北", 1, 6000);
            return;
        }

        Core.Resolve<MemApiChatMessage>().Toast2("欢迎使用ff14绿色科技", 1, 6000);
        xwwmove.rmove();
    }

    public void OnExitRotation()
    {
        xwwmove.remove();
    }

    public async Task OnNoTarget()
    {
        await Task.CompletedTask;
    }

    public async Task OnPreCombat()
    {
        await Task.CompletedTask;
    }

    public void OnResetBattle()
    {
        Vpjobdata.recinit();
    }

    public void OnSpellCastSuccess(Slot slot, Spell spell)
    {
    }

    public void OnTerritoryChanged()
    {
    }
}