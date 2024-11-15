using AEAssist.CombatRoutine.Module;
using Xww.vp;
using xww.vp.gcd;

namespace xww.vp;

public class Slotlist
{
    public static List<SlotResolverData> ViperSlotResolvers = new()
    {
        new(new 祖灵gcd(),SlotMode.Gcd),
        new(new 蛇1gcd(),SlotMode.Gcd),    //蛇连击优先级高
        new(new 蛇2gcd(),SlotMode.Gcd),
        new SlotResolverData(new 蛇aoe(),SlotMode.Gcd),
        new(new 飞蛇gcd(),SlotMode.Gcd),
        new SlotResolverData(new 飞蛇之牙gcd(),SlotMode.Gcd),
        new(new Basegcd(),SlotMode.Gcd),
        new(new Vpaoe(),SlotMode.Gcd),
        new SlotResolverData(new 真北(),SlotMode.OffGcd),
        new(new Offgcd(),SlotMode.OffGcd), 
        new(new 蛇灵气offgcd(),SlotMode.OffGcd),
    };
}