namespace Xww.vp
{
    public static class VpGcdSpellid
    {
        public const uint 咬噬尖齿 = 34606;//状态1
        public const uint 穿裂尖齿 = 34607;//状态1
        public const uint 猛袭利齿 = 34608;//状态2
        public const uint 疾速利齿 = 34609;//状态2
        public const uint 侧击獠齿 = 34610;//状态3
        public const uint 侧裂獠齿 = 34611;//状态3
        public const uint 背击獠齿 = 34612;//状态3
        public const uint 背裂獠齿 = 34613;//状态3
        public const uint 飞蛇之牙 = 34632;

        public const uint 咬噬尖牙 = 34614;
        public const uint 穿裂尖牙=34615;
        public const uint 猛袭利牙=34616;
        public const uint 疾速利牙=34617;
        public const uint 乱击獠牙=34618;
        public const uint 乱裂獠牙=34619;

        public const uint 强碎灵蝰 = 34623;
        public const uint 猛袭盘蝰 = 34624;
        public const uint 疾速盘蝰 = 34625;
        
        

        public const uint 强碎灵蛇 = 34620;//充能2
        public const uint 猛袭盘蛇 = 34621;//侧
        public const uint 疾速盘蛇 = 34622;//背

        public const uint 飞蛇之尾 = 34633;

        public const uint 祖灵降临 = 34626;
        public const uint 祖灵之牙一式 = 34627;
        public const uint 祖灵之牙二式 = 34628;
        public const uint 祖灵之牙三式 = 34629;
        public const uint 祖灵之牙四式 = 34630;
        public const uint 祖灵大蛇牙 = 34631;

    }
    public static class VpOffGcdSpellid
    {
        public const uint 真北 = 7546;
        public const uint 蛇尾术 = 35920;//
        public const uint 蛇尾击 = 34634;//
        public const uint 蛇尾闪 = 34635;//
        public const uint 双牙连术 = 35921;//
        public const uint 双牙乱术 = 35922;//
        public const uint 双牙连击 = 34636;
        public const uint 双牙乱击 = 34637;
        public const uint 双牙乱闪 = 34639;
        public const uint 双牙连闪 = 34638;
        public const uint 飞蛇连尾击 = 34644;
        public const uint 飞蛇乱尾击 = 34645;
        public const uint 蛇灵气 = 34647;
        public const uint 祖灵之蛇一式 = 34640;
        public const uint 祖灵之蛇二式 = 34641;
        public const uint 祖灵之蛇三式 = 34642;
        public const uint 祖灵之蛇四式 = 34643;

    }
    public static class Vpbuff
    {
        public const int 真北 = 1250;
        public const int 穿裂锐牙 = 3772;//强化穿裂尖齿
        public const int 咬噬锐牙 = 3672;//强化咬噬尖齿
        public const int 猛袭 = 3668;//强化攻击
        public const int 疾速 = 3669;//强化攻速
        public const int 背击锐牙 = 3647;
        public const int 背裂锐牙 = 3648;
        public const int 侧裂锐牙 = 3646;
        public const int 侧击锐牙 = 3645;
        public const int 连击双锐牙 = 3657;//先连
        public const int 乱击双锐牙 = 3658;//先乱
        public const int 祖灵降临buff = 3670;
        public const int 祖灵降临预备 = 3671;
        public const int 乱击锐牙 = 3649;
        public const int 乱裂锐牙 = 3450;

    }
    public  class Vpjobdata
    {
        public static uint LastGcdid { get; set; }
        public static uint LastOffGcdid { get; set; }
        public static uint NextGcdid { get; set; }
        public static bool 蛇0lunck {  get; set; }  //bool表示不能使用
        public static bool 蛇1lunck {  get; set; }//bool 表示不能使用
        public static bool 蛇2lunck {  get; set; }//bool 表示不能用
        static Vpjobdata()
        {
            LastGcdid = initid();
            LastOffGcdid = initid();
            NextGcdid = initid();
            蛇0lunck=init蛇gcdlunck();
            蛇1lunck = init蛇gcdlunck();
            蛇2lunck = init蛇gcdlunck();
        }
        public static void recinit()
        {
            LastGcdid = initid();
            LastOffGcdid = initid();
            NextGcdid = initid();
            蛇0lunck = init蛇gcdlunck();
            蛇1lunck = init蛇gcdlunck();
            蛇2lunck = init蛇gcdlunck();
        }
        private static uint initid()
        {
            return 0;
        }
        private static bool init蛇gcdlunck()
        {
            return true;
        }
    }
}