using AEAssist.CombatRoutine.Trigger;
using AEAssist.GUI;
using Xww;

namespace xww.vp.Triggers;

public class TriggerAction_jobset : ITriggerAction
{
    public int feishe;

    public TriggerAction_jobset()
    {
        feishe = JOBSettings.Instance.Maxfeishec;
    }

    public bool Draw()
    {
        ImGuiHelper.LeftInputInt("飞蛇之尾保留层数", ref feishe, 0, 3);
        return true;
    }

    public string DisplayName { get; } = "xww/Vp/飞蛇之尾保留层数";
    public string Remark { get; set; }

    public bool Handle()
    {
        JOBSettings.Instance.Maxfeishec = feishe;
        return true;
    }
}