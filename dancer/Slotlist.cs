using AEAssist.CombatRoutine.Module;
using xww.dancer.gcd;
using xww.dancer.offgcd;

namespace xww.dancer;

public class Slotlist
{
    public static List<SlotResolverData> DancerSlotResolvers = new()
    {
        new SlotResolverData(new 小舞gcd(), SlotMode.Gcd),
        new SlotResolverData(new 流星舞gcd(), SlotMode.Gcd),
        new SlotResolverData(new 提拉纳gcd(), SlotMode.Gcd),
        new SlotResolverData(new 剑舞gcd(), SlotMode.Gcd),
        new SlotResolverData(new 落幕舞gcd(), SlotMode.Gcd),
        new SlotResolverData(new 大舞gcd(), SlotMode.Gcd),
        new SlotResolverData(new baseaoe(), SlotMode.Gcd),
        new SlotResolverData(new basegcd(), SlotMode.Gcd),
        new SlotResolverData(new 百花(), SlotMode.OffGcd),
        new SlotResolverData(new 扇舞急(), SlotMode.OffGcd),
        new SlotResolverData(new 扇舞offgcd(), SlotMode.OffGcd),
        new SlotResolverData(new 扇舞终(), SlotMode.OffGcd)
    };
}