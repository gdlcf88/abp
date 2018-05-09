﻿using System;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Settings;

namespace Volo.Abp.Emailing.Smtp
{
    /// <summary>
    /// Implementation of <see cref="ISmtpEmailSenderConfiguration"/> that reads settings
    /// from <see cref="ISettingManager"/>.
    /// </summary>
    public class SmtpEmailSenderConfiguration : EmailSenderConfiguration, ISmtpEmailSenderConfiguration, ITransientDependency
    {
        public virtual string Host => GetNotEmptySettingValue(EmailSettingNames.Smtp.Host);

        public virtual int Port => GetNotEmptySettingValue(EmailSettingNames.Smtp.Port).To<int>();

        public virtual string UserName => GetNotEmptySettingValue(EmailSettingNames.Smtp.UserName);

        public virtual string Password => GetNotEmptySettingValue(EmailSettingNames.Smtp.Password);

        public virtual string Domain => SettingManager.GetOrNull(EmailSettingNames.Smtp.Domain);

        public virtual bool EnableSsl => SettingManager.GetOrNull(EmailSettingNames.Smtp.EnableSsl).To<bool>();

        public virtual bool UseDefaultCredentials => SettingManager.GetOrNull(EmailSettingNames.Smtp.UseDefaultCredentials).To<bool>();

        public SmtpEmailSenderConfiguration(ISettingManager settingManager)
            : base(settingManager)
        {

        }
    }
}