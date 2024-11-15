using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View;
using AEAssist.Extension;
using AEAssist.MemoryApi;
using ImGuiNET;
using Xww;
using Xww.vp;

namespace xww.vp
{
    internal class Vpenevt : IRotationEventHandler
    {
        public void AfterSpell(Slot slot, Spell spell)
        {
            Vphelp.Lastgcdid(spell.Id);
            if (spell.Id == VpGcdSpellid.强碎灵蛇 || spell.Id == VpGcdSpellid.猛袭盘蛇 || spell.Id == VpGcdSpellid.疾速盘蛇)
            {
                Vphelp.Set蛇lunck(spell.Id);       //设置蛇连
            }
        }

        public void OnBattleUpdate(int currTimeInMs)
        {
            
           
            if (QT.QTGET("留资源"))
            {
                QT.QTSET("收尾",false);  //资源互斥
            }
             Vphelp.Tp();  //tp
            
            if (Core.Me.HasAura(Vpbuff.祖灵降临buff)||Core.Me.HasAura(Vpbuff.真北))
            {
                MeleePosHelper.Draw(MeleePosHelper.Pos.Flank,0);
                return;//祖灵状态和真北不打身位去掉
            }
            if ((Vpjobdata.LastGcdid != VpGcdSpellid.强碎灵蛇&& Vpjobdata.LastGcdid!=VpGcdSpellid.疾速盘蛇) &&(!Core.Me.HasAura(Vpbuff.祖灵降临buff)||Core.Me.HasAura(Vpbuff.真北)))//不打蛇连且不在祖灵状态
            {
                if (Core.Me.HasAura(Vpbuff.背击锐牙) || Core.Me.HasAura(Vpbuff.背裂锐牙)||!Core.Me.HasAura(Vpbuff.侧击锐牙) || !Core.Me.HasAura(Vpbuff.侧裂锐牙))
                {
                    MeleePosHelper.Draw(MeleePosHelper.Pos.Behind, 100);
                }
                if (Core.Me.HasAura(Vpbuff.侧击锐牙) || Core.Me.HasAura(Vpbuff.侧裂锐牙))
                {
                    MeleePosHelper.Draw(MeleePosHelper.Pos.Flank, 100);
                }
            }
            if(Vpjobdata.LastGcdid==VpGcdSpellid.强碎灵蛇  || Vpjobdata.LastGcdid == VpGcdSpellid.疾速盘蛇)
            {
                if(Vpjobdata.LastGcdid == VpGcdSpellid.强碎灵蛇)
                {
                    MeleePosHelper.Draw(MeleePosHelper.Pos.Behind, 100);
                    return;
                }
                if( Vpjobdata.LastGcdid == VpGcdSpellid.疾速盘蛇)
                {
                    MeleePosHelper.Draw(MeleePosHelper.Pos.Flank, 100);
                    return;
                }
            }
        }

        public void OnEnterRotation()
        {
            Core.Resolve<MemApiChatMessage>().Toast2("欢迎使用蝰蛇绿色ACR\n目前适合普通日随\n有些副本有需要停手的请qt选择停手\n目前也适合打7.0的2个极神\nTP功能别乱用哦，别乱用哦\n11.6更新用户可以在悬浮窗设置飞蛇之尾和蛇连击最低充能数使用前先配置",1,6000);
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
