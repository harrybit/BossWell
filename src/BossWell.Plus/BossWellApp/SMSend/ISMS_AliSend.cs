namespace BossWellApp.SMSend
{
    public interface ISMS_AliSend
    {
        bool SMSTempSend(string mobile, string tempCode, string tempJson, string outStr = "");
    }
}
