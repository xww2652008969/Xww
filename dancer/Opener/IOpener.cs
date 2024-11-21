using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using xww.dancer.data;
using static xww.dancer.danhelp;

namespace xww.dancer.Opener;

public class IOpener100:IOpener
{
    public List<Action<Slot>> Sequence { get; } = new List<Action<Slot>>()
    {
        s1
    };
    
    public void InitCountDown(CountDownHandler countDownHandler)
    {
        Auto舞伴();
        Core.Resolve<MemApiChatMessage>().Toast2("进入倒计时起手如果计时间小于15秒会出问题",1,3000);
        countDownHandler.AddAction(14000,dangcd.标准舞步);
        countDownHandler.AddAction(12000,NextStep);
        countDownHandler.AddAction(10000,NextStep);
        countDownHandler.AddAction(100,dangcd.标准舞步结束);
    }

    private static void s1(Slot slot)
    {
        Auto舞伴();
    }
}