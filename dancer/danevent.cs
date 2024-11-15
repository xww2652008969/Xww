using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.MemoryApi;
namespace xww.dancer;

public class danevent:IRotationEventHandler
{
    public async Task OnPreCombat()
    {
        
    }

    public void OnResetBattle()
    {
        
    }

    public async Task OnNoTarget()
    {
        
    }

    public void OnSpellCastSuccess(Slot slot, Spell spell)
    {
        
    }

    public void AfterSpell(Slot slot, Spell spell)
    {
       
    }

    public void OnBattleUpdate(int currTimeInMs)
    {
        //自动舞伴
        danhelp.Auto舞伴();
    }

    public void OnEnterRotation()
    {
        Core.Resolve<MemApiChatMessage>().Toast2("欢迎使用舞者acr\n 日常用的，目前在测试 没啥问题就发出来了喵\n还有去悬浮窗设置下自动舞伴喵",1,6000);
    }

    public void OnExitRotation()
    {
   
    }

    public void OnTerritoryChanged()
    {
        if (danhelp.Isben())
        {
            Task.Delay(5000).ContinueWith(_ =>
            {
                Core.Resolve<MemApiChatMessage>().Toast2("进本了喵\n由于你没关闭自动舞伴\n待会儿会自动帮你绑定舞伴喵",1,6000);
            });
            Task.Delay(15000).ContinueWith(_ =>
            {
               danhelp.Auto舞伴();
            });
        }
    }
    
}