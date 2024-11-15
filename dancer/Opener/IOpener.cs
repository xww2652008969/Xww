using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.Helper;
using xww.dancer.data;
using static xww.dancer.danhelp;

namespace xww.dancer.Opener;

public class IOpener100:IOpener
{
    public List<Action<Slot>> Sequence { get; }
    
    public void InitCountDown(CountDownHandler countDownHandler)
    {
        LogHelper.Print("进入起手");
        countDownHandler.AddAction(14000,dangcd.标准舞步);
        countDownHandler.AddAction(12000,NextStep);
        countDownHandler.AddAction(10000,NextStep);
        countDownHandler.AddAction(100,dangcd.标准舞步结束);
    }
}