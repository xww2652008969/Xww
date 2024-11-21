using System.Numerics;
using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.JobApi;
using AEAssist.MemoryApi;

namespace Xww.vp
{
    internal class Vphelp
    {
        public static int GetLastCombo()    //获取基础连击的阶段
        {
            uint a = Core.Resolve<MemApiSpell>().CheckActionChange(VpGcdSpellid.咬噬尖齿);
            if (a == VpGcdSpellid.咬噬尖齿 || a == VpGcdSpellid.穿裂尖齿)
            {
                return 1;
            }else if (a == VpGcdSpellid.疾速利齿 || a == VpGcdSpellid.猛袭利齿)
            {
                return 2;
            }
            return 3;
        }

        public static int GetLastaoeCombo()
        {
            uint a = Core.Resolve<MemApiSpell>().CheckActionChange(VpGcdSpellid.咬噬尖牙);
            if (a==VpGcdSpellid.咬噬尖牙|| a==VpGcdSpellid.穿裂尖牙)
            {
                return 1;
            }

            if (a==VpGcdSpellid.疾速利牙 || a==VpGcdSpellid.猛袭利牙)
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
        public static float GetVicewinderCharges()//获取蛇连击充能数
        {
           return Core.Resolve<MemApiSpell>().GetCharges(VpGcdSpellid.强碎灵蛇);
        }
        public static void Ss2(Slot slot) //先连后乱
        {
            slot.Add(VpGcdSpellid.猛袭盘蛇.GetSpell());
            if (Core.Me.Level<75)
            {
                return;
            }
            slot.Add(VpOffGcdSpellid.双牙连击.GetSpell());
            slot.Add(VpOffGcdSpellid.双牙乱击.GetSpell());

        }
        public static void Ss1(Slot slot)//先乱后连
        {
            slot.Add(VpGcdSpellid.疾速盘蛇.GetSpell());
            if (Core.Me.Level<75)
            {
                return;
            }
            slot.Add(VpOffGcdSpellid.双牙乱击.GetSpell());
            slot.Add(VpOffGcdSpellid.双牙连击.GetSpell());

        }

        public static void ss1aoe(Slot slot)
        {
            slot.Add((VpGcdSpellid.疾速盘蝰.GetSpell()));
            if (Core.Me.Level<80)
            {
                return;
            }
            slot.Add(VpOffGcdSpellid.双牙乱闪.GetSpell());
            slot.Add(VpOffGcdSpellid.双牙连闪.GetSpell());
        }
        public static void ss2aoe(Slot slot)
        {
            slot.Add((VpGcdSpellid.猛袭盘蝰.GetSpell()));
            if (Core.Me.Level<80)
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
                Vpjobdata.蛇0lunck=true;
                Vpjobdata.蛇1lunck=true;
                Vpjobdata.蛇2lunck=true;
            }
        }
        public static bool Checkaoe()  //检测aoe 范围
        {
            if (TargetHelper.GetNearbyEnemyCount(4) >= 3)
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

        public static bool Stop()   //检测停手
        {
            if (QT.QTGET("停手"))
            {
                return true;
            }
            return false;
        }

        public static int 飞蛇之魂()
        {
            return Core.Resolve<JobApi_Viper>().RattlingCoilStacks;
        }
        public static void Tp()
        {
            if (!Core.Me.GetCurrTarget().HasPositional())
            {
                return;  //没身位就不tp了
            }
            if (!QT.QTGET("TP"))
            {
                return;
            }

            if (Vpjobdata.nextgcdid.Actions.Count == 0)
            {
                return;
            }
            float facingAngle = 0f;
            var aa = Core.Me.Position;
            var a = Core.Me.GetCurrTarget();
            Vector3 c;
            if (Vpjobdata.BehindGcd.Contains(Vpjobdata.nextgcdid.Actions.Peek().Spell.Id))
            {
                 facingAngle = a.Rotation + MathF.PI;
                 if (Core.Resolve<MemApiTarget>().IsBehind)
                 {
                     return;
                 }
            }
            
            if (Vpjobdata.Flankinggcd.Contains(Vpjobdata.nextgcdid.Actions.Peek().Spell.Id))
            {
                facingAngle = a.Rotation + MathF.PI / 2;
                if (Core.Resolve<MemApiTarget>().IsFlanking)
                {
                    return;
                }
            }
            
            if (facingAngle==0f)
            {
                return;
            }
            float x = MathF.Sin(facingAngle); //x
            float z = MathF.Cos(facingAngle); //y
            var b = new Vector3(x, 0, z);
            c = a.Position+(Vector3.Distance(aa,a.Position)) * b;
            Core.Me.SetPos(c);
            // Vpjobdata.Tpluck = true;
            Task.Delay(JOBSettings.Instance.TpDelay).ContinueWith(_ =>
            {
                Core.Me.SetPos(aa);
                Vpjobdata.Tpluck = false;
            });
            
        }
    }
}
