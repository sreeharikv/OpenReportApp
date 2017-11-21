using System;
using System.Configuration;
using System.Security;
using System.Security.Permissions;
using System.Web;
using System.Web.Configuration;

namespace OpenReportApp.Web.Core.Infrastructure.Config
{
    [AspNetHostingPermissionAttribute(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermissionAttribute(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class ReportAppSettingsSectionGroup : ConfigurationSectionGroup
    {
        [ConfigurationProperty("Settings", IsRequired = true)]
        public ReportAppSettingsConfig Settings
        {
            get { return (ReportAppSettingsConfig)this.Sections["Settings"]; }
        }
    }

    [AspNetHostingPermissionAttribute(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermissionAttribute(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [SecuritySafeCritical]
    public class ReportAppSettingsConfig : ConfigurationSection
    {
        public static ReportAppSettingsConfig GetConfig()
        {
            return (ReportAppSettingsConfig)WebConfigurationManager.GetSection("OpenReports.Web/Settings") ?? new ReportAppSettingsConfig();
        }

        [ConfigurationProperty("UserValidator")]
        public UserValidatorElement UserValidator
        {
            get
            {
                return (UserValidatorElement)this["UserValidator"];
            }
            set
            {
                this["UserValidator"] = value;
            }
        }

        [ConfigurationProperty("PasswordValidator")]
        public PasswordValidatorElement PasswordValidator
        {
            get
            {
                return (PasswordValidatorElement)this["PasswordValidator"];
            }
            set
            {
                this["PasswordValidator"] = value;
            }
        }

        [ConfigurationProperty("TableSettings")]
        public TableSettingsElement TableSettings
        {
            get
            {
                return (TableSettingsElement)this["TableSettings"];
            }
            set
            {
                this["TableSettings"] = value;
            }
        }

        [ConfigurationProperty("AdditionalSettings")]
        public AdditionalSettingsElement AdditionalSettings
        {
            get
            {
                return (AdditionalSettingsElement)this["AdditionalSettings"];
            }
            set
            {
                this["AdditionalSettings"] = value;
            }
        }
    }

    //==============================
    public class UserValidatorElement : ConfigurationElement
    {

        [ConfigurationProperty("AllowOnlyAlphanumericUserNames", DefaultValue = true, IsRequired = false)]
        public bool AllowOnlyAlphanumericUserNames
        {
            get { return (bool)this["AllowOnlyAlphanumericUserNames"]; }
            set { this["AllowOnlyAlphanumericUserNames"] = value; }
        }

        [ConfigurationProperty("RequireUniqueEmail", DefaultValue = true, IsRequired = false)]
        public bool RequireUniqueEmail
        {
            get { return (bool)this["RequireUniqueEmail"]; }
            set { this["RequireUniqueEmail"] = value; }
        }
    }

    //==============================
    public class PasswordValidatorElement : ConfigurationElement
    {

        [ConfigurationProperty("RequiredLength", DefaultValue = 8, IsRequired = false)]
        public int RequiredLength
        {
            get { return (int)this["RequiredLength"]; }
            set { this["RequiredLength"] = value; }
        }

        [ConfigurationProperty("RequireNonLetterOrDigit", DefaultValue = true, IsRequired = false)]
        public bool RequireNonLetterOrDigit
        {
            get { return (bool)this["RequireNonLetterOrDigit"]; }
            set { this["RequireNonLetterOrDigit"] = value; }
        }

        [ConfigurationProperty("RequireDigit", DefaultValue = true, IsRequired = false)]
        public bool RequireDigit
        {
            get { return (bool)this["RequireDigit"]; }
            set { this["RequireDigit"] = value; }
        }

        [ConfigurationProperty("RequireLowercase", DefaultValue = true, IsRequired = false)]
        public bool RequireLowercase
        {
            get { return (bool)this["RequireLowercase"]; }
            set { this["RequireLowercase"] = value; }
        }

        [ConfigurationProperty("RequireUppercase", DefaultValue = true, IsRequired = false)]
        public bool RequireUppercase
        {
            get { return (bool)this["RequireUppercase"]; }
            set { this["RequireUppercase"] = value; }
        }
    }

    //==============================
    public class TableSettingsElement : ConfigurationElement
    {

        [ConfigurationProperty("PageSize", DefaultValue = 25, IsRequired = false)]
        public int PageSize
        {
            get { return (int)this["PageSize"]; }
            set { this["PageSize"] = value; }
        }
    }

    //==============================
    public class AdditionalSettingsElement : ConfigurationElement
    {
        [ConfigurationProperty("AdminFolderPath", DefaultValue = "/admin/", IsRequired = false)]
        public String AdminFolderPath
        {
            get { return (String)this["AdminFolderPath"]; }
            set { this["AdminFolderPath"] = value; }
        }

        [ConfigurationProperty("LoginPath", DefaultValue = "/account/Login", IsRequired = false)]
        public String LoginPath
        {
            get { return (String)this["LoginPath"]; }
            set { this["LoginPath"] = value; }
        }
    }
}
