using AEAssist.CombatRoutine.View.JobView;
using Xww.vp;

namespace xww.vp.gui;

public class QT
{
    public static void createQT(JobViewWindow gui)
    {
        gui.AddQt(Qtkey.动态真北,true,"动态真北");
        gui.AddQt(Qtkey.收尾,false,"倾斜资源");
        gui.AddQt(Qtkey.飞蛇之尾,true,"过远就飞蛇尾");
        gui.AddQt(Qtkey.停手, false,"停手不打技能");
        gui.AddQt(Qtkey.留资源,false,"保留资源不打小怪");
        gui.AddQt(Qtkey.TP,false,"开全tp");
    }
}