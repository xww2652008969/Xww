using System.Numerics;
using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Trigger;
using AEAssist.Extension;
using AEAssist.MemoryApi;
using Dalamud.Game.ClientState.Objects.Types;

namespace Xww;

public class xwwhelp
{
     public static List<WayMarker>flag=new List<WayMarker>()
     {
          Core.Resolve<MemApiMaker>().WayMarker(WayMark.A),
          Core.Resolve<MemApiMaker>().WayMarker(WayMark.B),
          Core.Resolve<MemApiMaker>().WayMarker(WayMark.C),
          Core.Resolve<MemApiMaker>().WayMarker(WayMark.D),
          Core.Resolve<MemApiMaker>().WayMarker(WayMark.One),
          Core.Resolve<MemApiMaker>().WayMarker(WayMark.Two),
          Core.Resolve<MemApiMaker>().WayMarker(WayMark.Three),
          Core.Resolve<MemApiMaker>().WayMarker(WayMark.Four),
          
     };

     public static Vector3 Getflag(int i)
     {
          return flag[i].Pos;
     }
     //是否加载了时间轴
     public static bool isCurrTriggerLine()
     {
          if (AI.Instance.TriggerlineData.CurrTriggerLine!=null)
          {
               return true;
          }

          return false;
     }
     public static float Distance()//计算目标到自己距离
     {
          if (Core.Me.GetCurrTarget() == null)
          {
               return 0f;
          }
          return Core.Me.GetCurrTarget().Distance(Core.Me);
     }
     public static float Distance(IBattleChara tar)//计算目标到自己距离
     {
          if (tar==null)
          {
               return 0f;
          }
          return tar.Distance(Core.Me);
     }
     
     
     public static TriggerLine CurrTriggerLine()
     {
          return AI.Instance.TriggerlineData.CurrTriggerLine;
     }
}