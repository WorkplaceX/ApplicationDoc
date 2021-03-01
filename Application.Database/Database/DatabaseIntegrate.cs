// Do not modify this file. It's generated by Framework.Cli generate command.

namespace DatabaseIntegrate.Doc
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Framework.DataAccessLayer;
    using Database.Doc;

    public static class LanguageIntegrateApp
    {
        public enum IdEnum { [IdEnum(null)]None = 0, [IdEnum("English")]English = -1, [IdEnum("German")]German = -2 }

        public static LanguageIntegrate Row(this IdEnum value)
        {
            return RowList.Where(item => item.IdName == IdEnumAttribute.IdNameFromEnum(value)).SingleOrDefault();
        }

        public static IdEnum IdName(string value)
        {
            return IdEnumAttribute.IdNameToEnum<IdEnum>(value);
        }

        public static string IdName(this IdEnum value)
        {
            return IdEnumAttribute.IdNameFromEnum(value);
        }

        public static async Task<int> Id(this IdEnum value)
        {
            return (await Data.Query<LanguageIntegrate>().Where(item => item.IdName == IdEnumAttribute.IdNameFromEnum(value)).QueryExecuteAsync()).Single().Id;
        }

        public static List<LanguageIntegrate> RowList
        {
            get
            {
                var result = new List<LanguageIntegrate>
                {
                    new LanguageIntegrate { Id = 0, Name = "English", TextHtml = "<span class=\"flag-icon flag-icon-gb\"></span> English", IdName = "English" },
                    new LanguageIntegrate { Id = 0, Name = "German", TextHtml = "<span class=\"flag-icon flag-icon-de\"></span> German", IdName = "German" },
                };
                return result;
            }
        }
    }

    public static class LoginRoleIntegrateApp
    {
        public enum IdEnum { [IdEnum(null)]None = 0, [IdEnum("Admin")]Admin = -1, [IdEnum("Developer")]Developer = -2, [IdEnum("Guest")]Guest = -3 }

        public static LoginRoleIntegrate Row(this IdEnum value)
        {
            return RowList.Where(item => item.IdName == IdEnumAttribute.IdNameFromEnum(value)).SingleOrDefault();
        }

        public static IdEnum IdName(string value)
        {
            return IdEnumAttribute.IdNameToEnum<IdEnum>(value);
        }

        public static string IdName(this IdEnum value)
        {
            return IdEnumAttribute.IdNameFromEnum(value);
        }

        public static async Task<int> Id(this IdEnum value)
        {
            return (await Data.Query<LoginRoleIntegrate>().Where(item => item.IdName == IdEnumAttribute.IdNameFromEnum(value)).QueryExecuteAsync()).Single().Id;
        }

        public static List<LoginRoleIntegrate> RowList
        {
            get
            {
                var result = new List<LoginRoleIntegrate>
                {
                    new LoginRoleIntegrate { Id = 0, Name = "Admin", Sort = null, IdName = "Admin" },
                    new LoginRoleIntegrate { Id = 0, Name = "Developer", Sort = null, IdName = "Developer" },
                    new LoginRoleIntegrate { Id = 0, Name = "Guest", Sort = 3, IdName = "Guest" },
                };
                return result;
            }
        }
    }
}
