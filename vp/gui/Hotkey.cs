using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.CombatRoutine.View.JobView.HotkeyResolver;

namespace xww.vp.gui;

public class Hotkey
{
    public static void createHtokey(JobViewWindow QT)
    {
                    
        QT.AddHotkey("内丹", new HotKeyResolver_NormalSpell(7541,SpellTargetType.Self));
        QT.AddHotkey("亲疏自行", new HotKeyResolver_NormalSpell(7548,SpellTargetType.Self));
        QT.AddHotkey("浴血", new HotKeyResolver_NormalSpell(7542,SpellTargetType.Self));
        QT.AddHotkey("蛇行", new HotKeyResolver_NormalSpell(34646,SpellTargetType.Target));
        QT.AddHotkey("疾跑",new HotKeyResolver_疾跑());
        QT.AddHotkey("牵制",new HotKeyResolver_NormalSpell(7549,SpellTargetType.Target));
        QT.AddHotkey("LB",new HotKeyResolver_LB());
        QT.AddHotkey("爆发药",new HotKeyResolver_Potion());
    }
}