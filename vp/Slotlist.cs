using AEAssist.CombatRoutine.Module;
using Xww.vp;
using xww.vp.gcd;

namespace xww.vp;

public class Slotlist
{
    public static List<SlotResolverData> ViperSlotResolvers = new()
    {
        new SlotResolverData(new 祖灵gcd(), SlotMode.Gcd),
        new SlotResolverData(new 蛇Gcd(), SlotMode.Gcd), //蛇连击优先级高
        new SlotResolverData(new 蛇aoe(), SlotMode.Gcd),
        new SlotResolverData(new 飞蛇gcd(), SlotMode.Gcd),
        new SlotResolverData(new 飞蛇之牙gcd(), SlotMode.Gcd),
        new SlotResolverData(new Basegcd(), SlotMode.Gcd),
        new SlotResolverData(new Vpaoe(), SlotMode.Gcd),
        new SlotResolverData(new 真北(), SlotMode.OffGcd),
        new SlotResolverData(new Offgcd(), SlotMode.OffGcd),
        new SlotResolverData(new 蛇灵气offgcd(), SlotMode.OffGcd)
    };
}