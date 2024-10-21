using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using Xww;
using Xww.vp;

namespace xww.vp
{
    internal class Vpenevt : IRotationEventHandler
    {
        public void AfterSpell(Slot slot, Spell spell)
        {
            Vphelp.drw();
            
            Vphelp.Lastgcdid(spell.Id);
            if (spell.Id == VpGcdSpellid.强碎灵蛇 || spell.Id == VpGcdSpellid.猛袭盘蛇 || spell.Id == VpGcdSpellid.疾速盘蛇)
            {
                Vphelp.Set蛇lunck(spell.Id);       //设置蛇连
            }
        }

        public void OnBattleUpdate(int currTimeInMs)
        {
            // LogHelper.Print(Core.Me.Position.ToString());
            if (QT.QTGET("留资源"))
            {
                QT.QTSET("收尾",false);  //资源互斥
            }
           
        }

        public void OnEnterRotation()
        {
            return;
        }

        public void OnExitRotation()
        {
            return;
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
            return;
        }
    }
}
