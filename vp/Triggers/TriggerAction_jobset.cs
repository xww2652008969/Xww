using AEAssist.CombatRoutine.Trigger;
using AEAssist.GUI;
using Xww;

namespace xww.vp.Triggers;

public class TriggerAction_jobset: ITriggerAction
{
    public bool Draw()
    {
        ImGuiHelper.LeftInputInt("飞蛇之尾保留层数", ref this.feishe, 0, 3, 1);
        return true;
    }

    public TriggerAction_jobset()
    {
        feishe = JOBSettings.Instance.Maxfeishec;
    }

    public int feishe;
    public string DisplayName { get; } = "xww/Vp/飞蛇之尾保留层数";
    public string Remark { get; set; }
    public bool Handle()
    {
        JOBSettings.Instance.Maxfeishec = this.feishe;
        return true;
    }
}