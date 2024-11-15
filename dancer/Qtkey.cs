using xww.dancer.gui;

namespace xww.dancer;
public class Qtkey
{
    public const string 停手 = "停手";
}
public static class QT
{
    public static bool QTGET(string qtName) => Gui.dangui.GetQt(qtName);
    public static bool QTSET(string qtName, bool qtValue) =>  Gui.dangui.SetQt(qtName, qtValue);
}