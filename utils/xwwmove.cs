using System.Numerics;
using AEAssist;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using Dalamud.Game.ClientState.Objects.Types;
using Dalamud.Game.Command;
using ECommons.DalamudServices;

namespace Xww;

public class xwwmove
{
    //获取鼠标位置
    private static Vector3 mousepos => Core.Resolve<MemApiMove>().MousePos();

    private static List<IBattleChara> p => PartyHelper.Party;


    //注册命令
    public static void rmove()
    {
        try
        {
            Svc.Commands.RemoveHandler("/xwwacr");
        }
        catch (Exception e)
        {
        }

        Svc.Commands.AddHandler("/xwwacr", new CommandInfo(NewCommandHandler)
        {
            HelpMessage = "xwwacr的命令控制器"
        });
        LogHelper.Print("xwwacr:" + "注册移动命令成功喵!详细可以去dc我的帖子查看喵");
    }

    //注销命令
    public static void remove()
    {
        try
        {
            Svc.Commands.RemoveHandler("/xwwacr");
            LogHelper.Print("xwwacr:" + "移除了命令喵");
        }
        catch (Exception e)
        {
        }
    }

    private static void move(Vector3 pos)
    {
        if (Core.Resolve<MemApiMove>().PathEnabled)
        {
            Core.Resolve<MemApiMove>().CancelMove(); //取消移动
            return;
        }

        Core.Resolve<MemApiMove>().MoveToTarget(pos);
    }

    private static void NewCommandHandler(string command, string args)
    {
        var a = args.Split(" ");
        switch (a[0])
        {
            case "moveParty":
                MoveParty(a[1]);
                break;
            case "movemouse":
                Movemouse(); //移动到坐标
                break;
            case "moveflag":
                Moveflag(a[1]);
                break;
            default:
                LogHelper.Print("未知命令");
                break;
        }
    }


    private static void MoveParty(string x)
    {
        int px;
        if (int.TryParse(x, out px))
        {
            if (px == 0) LogHelper.Print("命令有误喵");

            if (px == 8) LogHelper.Print("命令有误喵");
            if (px <= p.Count)
            {
                LogHelper.Print(p[px].Name.ToString());
                move(p[px].Position);
            }

            if (px > p.Count) LogHelper.Print("队伍里没有这个人");
        }
    }

    private static void Moveflag(string ar)
    {
        var a = Vector3.Zero;
        switch (ar)
        {
            case "A":
                a = xwwhelp.Getflag(0);
                break;
            case "B":
                a = xwwhelp.Getflag(1);
                break;
            case "C":
                a = xwwhelp.Getflag(2);
                break;
            case "D":
                a = xwwhelp.Getflag(3);
                break;
            case "1":
                a = xwwhelp.Getflag(4);
                break;
            case "2":
                a = xwwhelp.Getflag(5);
                break;
            case "3":
                a = xwwhelp.Getflag(6);
                break;
            case "4":
                a = xwwhelp.Getflag(7);
                break;
            default:
                LogHelper.Print("命令有误喵");
                break;
        }

        if (a != Vector3.Zero) move(a);
    }

    private static void Movemouse()
    {
        if (mousepos == Vector3.Zero)
        {
            LogHelper.Print("坐标是{0，0，0}，不移动");
            return;
        }

        move(mousepos);
    }
}