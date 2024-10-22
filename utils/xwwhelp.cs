using System.Numerics;
using AEAssist;
using AEAssist.MemoryApi;

namespace Xww;

public class xwwhelp
{
     public static List<WayMarker>flag=new List<WayMarker>()
     {
          Core.Resolve<MemApiMaker>().WayMarker(AEAssist.MemoryApi.WayMark.A),
          Core.Resolve<MemApiMaker>().WayMarker(AEAssist.MemoryApi.WayMark.B),
          Core.Resolve<MemApiMaker>().WayMarker(AEAssist.MemoryApi.WayMark.C),
          Core.Resolve<MemApiMaker>().WayMarker(AEAssist.MemoryApi.WayMark.D),
          Core.Resolve<MemApiMaker>().WayMarker(AEAssist.MemoryApi.WayMark.One),
          Core.Resolve<MemApiMaker>().WayMarker(AEAssist.MemoryApi.WayMark.Two),
          Core.Resolve<MemApiMaker>().WayMarker(AEAssist.MemoryApi.WayMark.Three),
          Core.Resolve<MemApiMaker>().WayMarker(AEAssist.MemoryApi.WayMark.Four),
          
     };

     public static Vector3 Getflag(int i)
     {
          return flag[i].Pos;
     }
}