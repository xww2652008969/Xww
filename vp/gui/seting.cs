using AEAssist.CombatRoutine.View.JobView;
using AEAssist.GUI;
using ImGuiNET;
using Xww;

namespace xww.vp.gui;
public class Vpsetting
{
    public static Vpsetting Instance = new();
    public JOBSettings JOBSettings => JOBSettings.Instance;
    public static void createsetting(JobViewWindow jobViewWindow)
    {
        ImGuiHelper.LeftInputInt("TP身位后返回的时间", ref JOBSettings.Instance.TpDelay, 50, 500, 50);
        ImGuiHelper.LeftInputFloat("最远近战距离",ref JOBSettings.Instance.Maxmeleerange,3.0f,10f,0.1f );
        ImGuiHelper.LeftInputFloat("蛇连最大充能时间",ref Xww.JOBSettings.Instance.Maxshelian,1f,2.0f,0.1f);
        ImGuiHelper.LeftInputInt("飞蛇最大充能", ref Xww.JOBSettings.Instance.Maxfeishe, 0, 3, 1);
        if (ImGui.Button("Save"))//保存按钮，不用动
        {
            JOBSettings.Instance.Save();
        }
    }
}