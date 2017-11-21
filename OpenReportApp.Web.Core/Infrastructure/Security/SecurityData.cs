using System;
using System.Threading.Tasks;
using OpenReportApp.Web.Core.Infrastructure.Config;

namespace OpenReportApp.Web.Core.Infrastructure.Security
{
    public class SecurityData
    {
        public static AppUserPrincipal CurrentUser
        {
            get
            {
                return new AppUserPrincipal(System.Web.HttpContext.Current.User as System.Security.Claims.ClaimsPrincipal);
            }
        }

        public static bool IsAuthenticated
        {
            get
            {
                if (CurrentUser.Identity.IsAuthenticated)
                {
                    return true;
                }

                return false;
            }
        }

        public SecurityData() { }

        #region Password Helper

        private static string alphaUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string alphaLower = "abcdefghijklmnopqrstuvwxyz";
        private static string numericChars = "1234567890";
        private static string specialChars = "@#$&%";
        private static int _length = -1;
        private static string allChars = alphaUpper + alphaLower + numericChars + specialChars;
        private static string _adminfolderpath = string.Empty;
        private static string _loginpath = string.Empty;

        private static int MinRequiredPasswordLength
        {
            get
            {
                if (_length <= 3)
                {
                    //GetConfig();
                    //todo
                    //_length = config.PasswordValidator.RequiredLength;
                    if (_length <= 9)
                    {
                        _length = 12;
                    }
                }

                return _length;
            }
        }
        public static string GenerateSimplePassword()
        {
            int length = MinRequiredPasswordLength;

            Random rand = new Random();
            string generatedPassword = String.Empty;

            for (int i = 0; i < length; i++)
            {
                double dbl = rand.NextDouble();
                if (i == 0)
                {
                    generatedPassword += alphaUpper.ToCharArray()[(int)Math.Floor(dbl * alphaUpper.Length)];
                }
                else if (i == length - 3)
                {
                    generatedPassword += alphaLower.ToCharArray()[(int)Math.Floor(dbl * alphaLower.Length)];
                }
                else if (i == length - 5)
                {
                    generatedPassword += numericChars.ToCharArray()[(int)Math.Floor(dbl * numericChars.Length)];
                }
                else if (i == length - 7)
                {
                    generatedPassword += specialChars.ToCharArray()[(int)Math.Floor(dbl * specialChars.Length)];
                }
                else
                {
                    generatedPassword += allChars.ToCharArray()[(int)Math.Floor(dbl * allChars.Length)];
                }
            }

            return generatedPassword;
        }
        #endregion

        public static string AdminFolderPath {
			get {
				if (string.IsNullOrEmpty(_adminfolderpath)) {
					string _defPath = "/c3-admin/";
                    ReportAppSettingsConfig config = ReportAppSettingsConfig.GetConfig();
					if (config.AdditionalSettings != null && !String.IsNullOrEmpty(config.AdditionalSettings.AdminFolderPath)) {
						_adminfolderpath = config.AdditionalSettings.AdminFolderPath;
						_adminfolderpath = String.Format("/{0}/", _adminfolderpath).Replace(@"\", "/").Replace("///", "/").Replace("//", "/").Replace("//", "/").Trim();
					} else {
						_adminfolderpath = _defPath;
					}
					if (String.IsNullOrEmpty(_adminfolderpath) || _adminfolderpath.Length < 2) {
						_adminfolderpath = _defPath;
					}
				}
				return _adminfolderpath;
			}
		}

        public static string LoginPath
        {
            get
            {
                if(string.IsNullOrEmpty(_loginpath))
                {
                    ReportAppSettingsConfig config = ReportAppSettingsConfig.GetConfig();
                    _loginpath = config.AdditionalSettings.LoginPath;
                }
                return _loginpath;
            }
        }

        public static string NotAuthorizedURL
        {
            get
            {
                return "AccessDenied";
            }
        }
    }
}