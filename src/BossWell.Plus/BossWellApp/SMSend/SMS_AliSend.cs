using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using SystemConfig;

namespace BossWellApp.SMSend
{
    public class SMS_AliSend : ISMS_AliSend
    {
        /// <summary>
        /// 短信模板发送
        /// </summary>
        public bool SMSTempSend(string mobile, string tempCode, string tempJson, string outStr = "")
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", SMSendConfig.AccessKeyID,
                SMSendConfig.AccessKeySecret);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", SMSendConfig.Product, SMSendConfig.Domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                request.PhoneNumbers = mobile;//手机号
                request.SignName = SMSendConfig.SingName;//短信签名
                request.TemplateCode = tempCode;//短信模板
                request.TemplateParam = tempJson;//模板中的变量替换JSON串
                request.OutId = outStr;//最终在短信回执消息中将此值带回给调用者

                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);

                //发送失败
                if (sendSmsResponse == null || !sendSmsResponse.Code.Equals("OK"))
                {
                    return false;
                }
            }
            catch (ServerException e)
            {
                return false;
            }
            return true;
        }
    }
}