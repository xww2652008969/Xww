namespace Xww.vp;

public class Qtkey
{
    public const string 飞蛇之尾 = "飞蛇之尾";
    public const string 动态真北 = "动态真北";
    public const string 收尾 = "收尾";
    public const string 停手 = "停手";
    public const string 留资源 = "留资源";
}
public static class QT
{
    public static bool QTGET(string qtName) => Viper.QT.GetQt(qtName);
    public static bool QTSET(string qtName, bool qtValue) => Viper.QT.SetQt(qtName, qtValue);
}