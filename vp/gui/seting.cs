using AEAssist.CombatRoutine.View.JobView;
using AEAssist.GUI;
using ImGuiNET;
using Xww;

namespace xww.vp.gui;

public class Vpsetting
{
    public JOBSettings JOBSettings => JOBSettings.Instance;

    public static void createsetting(JobViewWindow jobViewWindow)
    {
        ImGuiHelper.LeftInputInt("TP身位后返回的时间", ref JOBSettings.Instance.TpDelay, 50, 500, 50);
        ImGuiHelper.LeftInputFloat("长臂猿距离", ref JOBSettings.Instance.Maxmeleerange, 0.0f, 2.0f);
        ImGuiHelper.LeftInputFloat("蛇连最大充能时间", ref JOBSettings.Instance.Maxshelian, 1f, 2.0f);
        ImGuiHelper.LeftInputInt("飞蛇最大充能", ref JOBSettings.Instance.Maxfeishe, 0, 3);
        if (ImGui.Button("Save")) //保存按钮，不用动
            JOBSettings.Instance.Save();
    }
}