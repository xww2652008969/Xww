using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.View.JobView;
using AEAssist.CombatRoutine.View.JobView.HotkeyResolver;
using xww.dancer.data;

namespace xww.dancer.gui;

public class Hotkey
{
    public static void createHtokey(JobViewWindow QT)
    {
                    
        QT.AddHotkey("内丹", new HotKeyResolver_NormalSpell(7541,SpellTargetType.Self));
        QT.AddHotkey("亲疏自行", new HotKeyResolver_NormalSpell(7548,SpellTargetType.Self));
        QT.AddHotkey("疾跑",new HotKeyResolver_疾跑());
        QT.AddHotkey("LB",new HotKeyResolver_LB());
        QT.AddHotkey("爆发药",new HotKeyResolver_Potion());
        QT.AddHotkey("即兴表演",new HotKeyResolver_NormalSpell(danoffgcd.即兴表演,SpellTargetType.Self));
        QT.AddHotkey("治疗之华尔兹",new HotKeyResolver_NormalSpell(danoffgcd.治疗之华尔兹,SpellTargetType.Self));
        QT.AddHotkey("防守之桑巴",new HotKeyResolver_NormalSpell(danoffgcd.防守之桑巴,SpellTargetType.Self));
    }
}