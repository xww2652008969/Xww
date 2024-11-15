using AEAssist.CombatRoutine.View.JobView;
using AEAssist.GUI;
using ImGuiNET;
using Xww;

namespace xww.dancer.gui;
public class dansetting
{
    public static dansetting Instance = new();
    public JOBSettings JOBSettings => JOBSettings.Instance;
    public static void createsetting(JobViewWindow jobViewWindow)
    {
        ImGuiHelper.LeftInputInt("最大伶俐", ref JOBSettings.Instance.Maxlinli, 0, 100, 10);
        ImGui.Checkbox("自动舞伴", ref JOBSettings.Instance.Autowuban);
        if (ImGui.Button("Save"))//保存按钮，不用动
        {
            JOBSettings.Instance.Save();
        }
    }
}