namespace BossWellApp.SMSend
{
    /// <summary>
    /// 消息工厂
    /// </summary>
    public class SMS_Factory
    {
        /// <summary>
        /// 阿里大于短信模板发送
        /// </summary>
        /// <returns></returns>
        public static ISMS_AliSend SMS_AliTempSend()
        {
            return new SMS_AliSend();
        }
    }
}
