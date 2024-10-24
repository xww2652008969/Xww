using AEAssist.GUI;
using ImGuiNET;
namespace Xww;
public class Jobui
{
    public static Jobui Instance = new();
    public JOBSettings JOBSettings => JOBSettings.Instance;
    public void Draw()
    {
        //这里设置ui
        //ui类型请查询ImGui
        //ImGui.InputInt("目标剩余多少百分比血量时禁用读条画画", ref JOBSettings.画画百分比);
        // ImGui.Checkbox("音效", ref PCTSettings.音效);
        // ImGui.Checkbox("智能aoe目标", ref PCTSettings.智能aoe目标);
        ImGuiHelper.LeftInputInt("TP身位后返回的时间", ref JOBSettings.Instance.TpDelay, 50, 500, 50);
        ImGuiHelper.LeftInputFloat("最远近战距离",ref JOBSettings.Instance.Maxmeleerange,3.0f,10f,0.1f );
        if (ImGui.Button("Save"))//保存按钮，不用动
        {
            JOBSettings.Instance.Save();
        }
    }
}
