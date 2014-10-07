namespace BizTalkComponents.Utils.ConfigRepository
{
    public interface IConfigRepository
    {
        string ReadConfigValue(params string[] keys);
    }
}
