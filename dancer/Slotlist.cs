using AEAssist.CombatRoutine.Module;
using xww.dancer.gcd;
using xww.dancer.offgcd;

namespace xww.dancer;

public class Slotlist
{
    public static List<SlotResolverData> DancerSlotResolvers = new()
    {
        new(new 小舞gcd(),SlotMode.Gcd),
        new(new 流星舞gcd(),SlotMode.Gcd),
        new (new 提拉纳gcd(),SlotMode.Gcd),
        new (new 剑舞gcd(),SlotMode.Gcd),
        new (new 落幕舞gcd(),SlotMode.Gcd),
        new(new 大舞gcd(),SlotMode.Gcd),
        new (new baseaoe(),SlotMode.Gcd),
        new(new basegcd(),SlotMode.Gcd),
        new(new 百花(),SlotMode.OffGcd),
        new (new 扇舞急(),SlotMode.OffGcd),
        new (new 扇舞offgcd(),SlotMode.OffGcd),
        new (new 扇舞终(),SlotMode.OffGcd),
    };
}