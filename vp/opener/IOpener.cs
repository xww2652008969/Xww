using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using Xww.vp;

namespace xww.dancer.Opener;

public class vp100op:IOpener
{
    public List<Action<Slot>> Sequence { get; } = new List<Action<Slot>>()
    {
        Step0
    };
    
    public void InitCountDown(CountDownHandler countDownHandler)
    {
        Core.Resolve<MemApiChatMessage>().Toast2("进入起手序列", 1, 3000);
        countDownHandler.AddAction(2000,VpOffGcdSpellid.真北);
        countDownHandler.AddAction(100,34646,SpellTargetType.Target);
    }

    private static void Step0(Slot slot)
    {
        slot.Add(VpGcdSpellid.强碎灵蛇.GetSpell());
        Vphelp.Ss1(slot);
        Vphelp.Ss2(slot);
        slot.Add(VpGcdSpellid.飞蛇之尾.GetSpell());
        if (Core.Me.Level<92)
        {
            return;
        }
        slot.Add(VpOffGcdSpellid.飞蛇连尾击.GetSpell());
        slot.Add(VpOffGcdSpellid.飞蛇乱尾击.GetSpell());
    }
}