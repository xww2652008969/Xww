﻿using System.Numerics;
using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.View;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;

namespace Xww.vp
{
    internal class Vphelp
    {
        public static int GetLastCombo() //获取基础连击的阶段
        {
            uint a = Core.Resolve<MemApiSpell>().CheckActionChange(VpGcdSpellid.咬噬尖齿);
            if (a == VpGcdSpellid.咬噬尖齿 || a == VpGcdSpellid.穿裂尖齿)
            {
                return 1;
            }
            else if (a == VpGcdSpellid.疾速利齿 || a == VpGcdSpellid.猛袭利齿)
            {
                return 2;
            }

            return 3;
        }

        public static int GetLastaoeCombo()
        {
            uint a = Core.Resolve<MemApiSpell>().CheckActionChange(VpGcdSpellid.咬噬尖牙);
            if (a == VpGcdSpellid.咬噬尖牙 || a == VpGcdSpellid.穿裂尖牙)
            {
                return 1;
            }

            if (a == VpGcdSpellid.疾速利牙 || a == VpGcdSpellid.猛袭利牙)
            {
                return 2;
            }

            return 3;
        }

        public static int bufftimeleft(int id)
        {
            uint idd = (uint)id;
            return Core.Resolve<MemApiBuff>().GetAuraTimeleft(Core.Me, idd, true);
        }

        public static float GetVicewinderCharges() //获取蛇连击充能数
        {
            return Core.Resolve<MemApiSpell>().GetCharges(VpGcdSpellid.强碎灵蛇);
        }

        public static void Ss2(Slot slot) //先连后乱
        {
            slot.Add(VpGcdSpellid.猛袭盘蛇.GetSpell());
            if (Core.Me.Level < 75)
            {
                return;
            }

            slot.Add(VpOffGcdSpellid.双牙连击.GetSpell());
            slot.Add(VpOffGcdSpellid.双牙乱击.GetSpell());

        }

        public static void Ss1(Slot slot) //先乱后连
        {
            slot.Add(VpGcdSpellid.疾速盘蛇.GetSpell());
            if (Core.Me.Level < 75)
            {
                return;
            }

            slot.Add(VpOffGcdSpellid.双牙乱击.GetSpell());
            slot.Add(VpOffGcdSpellid.双牙连击.GetSpell());

        }

        public static void ss1aoe(Slot slot)
        {
            slot.Add((VpGcdSpellid.疾速盘蝰.GetSpell()));
            if (Core.Me.Level < 80)
            {
                return;
            }

            slot.Add(VpOffGcdSpellid.双牙乱闪.GetSpell());
            slot.Add(VpOffGcdSpellid.双牙连闪.GetSpell());
        }

        public static void ss2aoe(Slot slot)
        {
            slot.Add((VpGcdSpellid.猛袭盘蝰.GetSpell()));
            if (Core.Me.Level < 80)
            {
                return;
            }

            slot.Add(VpOffGcdSpellid.双牙连闪.GetSpell());
            slot.Add(VpOffGcdSpellid.双牙乱闪.GetSpell());

        }

        public static void Lastgcdid(uint i)
        {
            if (ReflectionHelp.IsValueInClass<uint>(typeof(VpGcdSpellid), i))
            {
                Vpjobdata.LastGcdid = i;

            }

            if (ReflectionHelp.IsValueInClass<uint>(typeof(VpOffGcdSpellid), i))
            {
                Vpjobdata.LastOffGcdid = i;
            }
        }

        public static void Set蛇lunck(uint id)
        {
            if (id == VpGcdSpellid.强碎灵蛇)
            {
                Vpjobdata.蛇0lunck = false;
            }

            if (id == VpGcdSpellid.猛袭盘蛇)
            {
                Vpjobdata.蛇2lunck = false;
            }

            if (id == VpGcdSpellid.疾速盘蛇)
            {
                Vpjobdata.蛇1lunck = false;

            }

            if (!Vpjobdata.蛇0lunck && !Vpjobdata.蛇1lunck && !Vpjobdata.蛇2lunck)
            {
                Vpjobdata.蛇0lunck = true;
                Vpjobdata.蛇1lunck = true;
                Vpjobdata.蛇2lunck = true;
            }
        }

        public static bool Checkaoe() //检测aoe 范围
        {
            if (TargetHelper.GetNearbyEnemyCount(4) >= 3)
            {
                return true;
            }

            return false;
        }

        public static float Distance() //计算目标到自己距离
        {
            return Core.Me.GetCurrTarget().Distance(Core.Me);
        }

        public static bool Stop() //检测停手
        {
            if (QT.QTGET("停手"))
            {
                return true;
            }

            return false;
        }

        public static void Tp(int i)
        {
            var aa = Core.Me.Position;
            var a = Core.Me.GetCurrTarget();
            if (i == 1)
            {
                float facingAngle = a.Rotation + MathF.PI / 2;
                float x = MathF.Sin(facingAngle); //x
                float z = MathF.Cos(facingAngle); //y
                var b = new Vector3(x, 0, z);
                var c = a.Position + a.HitboxRadius * b;
                Core.Me.SetPos(c);
                 Task.Delay(500).ContinueWith(_=> Core.Me.SetPos(aa));
            }

            if (i == 2)
            {
                float facingAngle = a.Rotation + MathF.PI;
                float x = MathF.Sin(facingAngle); //x
                float z = MathF.Cos(facingAngle); //y
                var b = new Vector3(x, 0, z);
                var c = a.Position + a.HitboxRadius * b;
                Core.Me.SetPos(c);
                 Task.Delay(500).ContinueWith(_=> Core.Me.SetPos(aa));
            }

        }

        public static void Tp2(int i)
        {
            var aa = Core.Me.Position;
            var a = Core.Me.GetCurrTarget();
            if (i == 1)
            {
                float facingAngle = a.Rotation + MathF.PI / 2;
                float x = MathF.Sin(facingAngle); //x
                float z = MathF.Cos(facingAngle); //y
                var b = new Vector3(x, 0, z);
                var c = a.Position + a.HitboxRadius * b;
                Core.Me.SetPos(c);
                Task.Delay(500).ContinueWith(_=> Core.Me.SetPos(aa));
            }

            if (i == 2)
            {
                float facingAngle = a.Rotation + MathF.PI;
                float x = MathF.Sin(facingAngle); //x
                float z = MathF.Cos(facingAngle); //y
                var b = new Vector3(x, 0, z);
                var c = a.Position + a.HitboxRadius * b;
                Core.Me.SetPos(c);
            }
        }

        public static void drw()
        {
            if (Core.Me.HasAura(Vpbuff.祖灵降临buff)||Core.Me.HasAura(Vpbuff.真北))
            {
                MeleePosHelper.Draw(MeleePosHelper.Pos.Flank,0);
                return;//祖灵状态和真北不打身位去掉
            }
            if ((Vpjobdata.LastGcdid != VpGcdSpellid.强碎灵蛇&& Vpjobdata.LastGcdid!=VpGcdSpellid.疾速盘蛇) &&(!Core.Me.HasAura(Vpbuff.祖灵降临buff)||Core.Me.HasAura(Vpbuff.真北)))//不打蛇连且不在祖灵状态
            {
                if (Core.Me.HasAura(Vpbuff.背击锐牙) || Core.Me.HasAura(Vpbuff.背裂锐牙)||!Core.Me.HasAura(Vpbuff.侧击锐牙) || !Core.Me.HasAura(Vpbuff.侧裂锐牙))
                {
                    MeleePosHelper.Draw(MeleePosHelper.Pos.Behind, 100);
                }
                if (Core.Me.HasAura(Vpbuff.侧击锐牙) || Core.Me.HasAura(Vpbuff.侧裂锐牙))
                {
                    MeleePosHelper.Draw(MeleePosHelper.Pos.Flank, 100);
                }
            }
            if(Vpjobdata.LastGcdid==VpGcdSpellid.强碎灵蛇  || Vpjobdata.LastGcdid == VpGcdSpellid.疾速盘蛇)
            {
                if(Vpjobdata.LastGcdid == VpGcdSpellid.强碎灵蛇)
                {
                    MeleePosHelper.Draw(MeleePosHelper.Pos.Behind, 100);
                    return;
                }
                if( Vpjobdata.LastGcdid == VpGcdSpellid.疾速盘蛇)
                {
                    MeleePosHelper.Draw(MeleePosHelper.Pos.Flank, 100);
                    return;
                }
            }
        }
    }
}
