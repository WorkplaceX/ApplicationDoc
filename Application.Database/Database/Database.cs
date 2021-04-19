// Do not modify this file. It's generated by Framework.Cli generate command.

namespace Database.Doc
{
    using Framework.DataAccessLayer;
    using System;

    [SqlTable("Doc", "Content")]
    public class Content : Row
    {
        [SqlField("Id", true, FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("NavigateTree", FrameworkTypeEnum.Nvarcahr)]
        public string NavigateTree { get; set; }

        [SqlField("NavigatePath", FrameworkTypeEnum.Nvarcahr)]
        public string NavigatePath { get; set; }

        [SqlField("TitleHtml", FrameworkTypeEnum.Nvarcahr)]
        public string TitleHtml { get; set; }

        [SqlField("TitleLong", FrameworkTypeEnum.Nvarcahr)]
        public string TitleLong { get; set; }

        [SqlField("TextMd", FrameworkTypeEnum.Nvarcahr)]
        public string TextMd { get; set; }

        [SqlField("TextHtml", FrameworkTypeEnum.Nvarcahr)]
        public string TextHtml { get; set; }

        [SqlField("Sort", FrameworkTypeEnum.Float)]
        public double? Sort { get; set; }

        [SqlField("SitemapDate", FrameworkTypeEnum.Datetime2)]
        public DateTime? SitemapDate { get; set; }
    }

    [SqlTable("Doc", "ContentIntegrate")]
    public class ContentIntegrate : Row
    {
        [SqlField("Id", FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("NavigateTree", FrameworkTypeEnum.Nvarcahr)]
        public string NavigateTree { get; set; }

        [SqlField("NavigatePath", FrameworkTypeEnum.Nvarcahr)]
        public string NavigatePath { get; set; }

        [SqlField("TitleHtml", FrameworkTypeEnum.Nvarcahr)]
        public string TitleHtml { get; set; }

        [SqlField("TitleLong", FrameworkTypeEnum.Nvarcahr)]
        public string TitleLong { get; set; }

        [SqlField("TextMd", FrameworkTypeEnum.Nvarcahr)]
        public string TextMd { get; set; }

        [SqlField("TextHtml", FrameworkTypeEnum.Nvarcahr)]
        public string TextHtml { get; set; }

        [SqlField("Sort", FrameworkTypeEnum.Float)]
        public double? Sort { get; set; }

        [SqlField("SitemapDate", FrameworkTypeEnum.Datetime2)]
        public DateTime? SitemapDate { get; set; }

        [SqlField("IdName", FrameworkTypeEnum.Nvarcahr)]
        public string IdName { get; set; }
    }

    [SqlTable("Doc", "Language")]
    public class Language : Row
    {
        [SqlField("Id", true, FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("TextHtml", FrameworkTypeEnum.Nvarcahr)]
        public string TextHtml { get; set; }
    }

    [SqlTable("Doc", "LanguageIntegrate")]
    public class LanguageIntegrate : Row
    {
        [SqlField("Id", FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("TextHtml", FrameworkTypeEnum.Nvarcahr)]
        public string TextHtml { get; set; }

        [SqlField("IdName", FrameworkTypeEnum.Nvarcahr)]
        public string IdName { get; set; }
    }

    [SqlTable("Doc", "LoginRole")]
    public class LoginRole : Row
    {
        [SqlField("Id", true, FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("Sort", FrameworkTypeEnum.Float)]
        public double? Sort { get; set; }
    }

    [SqlTable("Doc", "LoginRoleIntegrate")]
    public class LoginRoleIntegrate : Row
    {
        [SqlField("Id", FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("Sort", FrameworkTypeEnum.Float)]
        public double? Sort { get; set; }

        [SqlField("IdName", FrameworkTypeEnum.Nvarcahr)]
        public string IdName { get; set; }
    }

    [SqlTable("Doc", "LoginUser")]
    public class LoginUser : Row
    {
        [SqlField("Id", true, FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("Password", FrameworkTypeEnum.Nvarcahr)]
        public string Password { get; set; }

        [SqlField("IsIntegrate", FrameworkTypeEnum.Bit)]
        public bool IsIntegrate { get; set; }

        [SqlField("IsDelete", FrameworkTypeEnum.Bit)]
        public bool IsDelete { get; set; }
    }

    [SqlTable("Doc", "LoginUserIntegrate")]
    public class LoginUserIntegrate : Row
    {
        [SqlField("Id", FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("Password", FrameworkTypeEnum.Nvarcahr)]
        public string Password { get; set; }

        [SqlField("IsIntegrate", FrameworkTypeEnum.Bit)]
        public bool IsIntegrate { get; set; }

        [SqlField("IsDelete", FrameworkTypeEnum.Bit)]
        public bool IsDelete { get; set; }

        [SqlField("IdName", FrameworkTypeEnum.Nvarcahr)]
        public string IdName { get; set; }
    }

    [SqlTable("Doc", "LoginUserRole")]
    public class LoginUserRole : Row
    {
        [SqlField("Id", true, FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("LoginUserId", FrameworkTypeEnum.Int)]
        public int LoginUserId { get; set; }

        [SqlField("LoginRoleId", FrameworkTypeEnum.Int)]
        public int LoginRoleId { get; set; }

        [SqlField("IsActive", FrameworkTypeEnum.Bit)]
        public bool? IsActive { get; set; }
    }

    [SqlTable("Doc", "LoginUserRoleApp")]
    public class LoginUserRoleApp : Row
    {
        [SqlField("LoginUserId", FrameworkTypeEnum.Int)]
        public int LoginUserId { get; set; }

        [SqlField("LoginUserName", FrameworkTypeEnum.Nvarcahr)]
        public string LoginUserName { get; set; }

        [SqlField("LoginUserPassword", FrameworkTypeEnum.Nvarcahr)]
        public string LoginUserPassword { get; set; }

        [SqlField("LoginRoleName", FrameworkTypeEnum.Nvarcahr)]
        public string LoginRoleName { get; set; }

        [SqlField("LoginUserRoleIsActive", FrameworkTypeEnum.Bit)]
        public bool? LoginUserRoleIsActive { get; set; }
    }

    [SqlTable("Doc", "LoginUserRoleDisplay")]
    public class LoginUserRoleDisplay : Row
    {
        [SqlField("LoginUserId", FrameworkTypeEnum.Int)]
        public int LoginUserId { get; set; }

        [SqlField("LoginUserName", FrameworkTypeEnum.Nvarcahr)]
        public string LoginUserName { get; set; }

        [SqlField("LoginRoleId", FrameworkTypeEnum.Int)]
        public int LoginRoleId { get; set; }

        [SqlField("LoginRoleName", FrameworkTypeEnum.Nvarcahr)]
        public string LoginRoleName { get; set; }

        [SqlField("LoginUserRoleId", FrameworkTypeEnum.Int)]
        public int? LoginUserRoleId { get; set; }

        [SqlField("IsActive", FrameworkTypeEnum.Bit)]
        public bool? IsActive { get; set; }
    }

    [SqlTable("Doc", "LoginUserRoleIntegrate")]
    public class LoginUserRoleIntegrate : Row
    {
        [SqlField("Id", FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("LoginUserId", FrameworkTypeEnum.Int)]
        public int LoginUserId { get; set; }

        [SqlField("LoginRoleId", FrameworkTypeEnum.Int)]
        public int LoginRoleId { get; set; }

        [SqlField("IsActive", FrameworkTypeEnum.Bit)]
        public bool? IsActive { get; set; }

        [SqlField("LoginUserIsIntegrate", FrameworkTypeEnum.Bit)]
        public bool? LoginUserIsIntegrate { get; set; }

        [SqlField("LoginUserIdName", FrameworkTypeEnum.Nvarcahr)]
        public string LoginUserIdName { get; set; }

        [SqlField("LoginRoleIdName", FrameworkTypeEnum.Nvarcahr)]
        public string LoginRoleIdName { get; set; }
    }

    [SqlTable("Doc", "Navigate")]
    public class Navigate : Row
    {
        [SqlField("Id", true, FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("ParentId", FrameworkTypeEnum.Int)]
        public int? ParentId { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("TextHtml", FrameworkTypeEnum.Nvarcahr)]
        public string TextHtml { get; set; }

        [SqlField("IsDivider", FrameworkTypeEnum.Bit)]
        public bool IsDivider { get; set; }

        [SqlField("IsNavbarEnd", FrameworkTypeEnum.Bit)]
        public bool IsNavbarEnd { get; set; }

        [SqlField("IsContent", FrameworkTypeEnum.Bit)]
        public bool IsContent { get; set; }

        [SqlField("NavigatePath", FrameworkTypeEnum.Nvarcahr)]
        public string NavigatePath { get; set; }

        [SqlField("PageTypeName", FrameworkTypeEnum.Nvarcahr)]
        public string PageTypeName { get; set; }

        [SqlField("Sort", FrameworkTypeEnum.Float)]
        public double? Sort { get; set; }

        [SqlField("SitemapDate", FrameworkTypeEnum.Datetime2)]
        public DateTime? SitemapDate { get; set; }
    }

    [SqlTable("Doc", "NavigateDisplay")]
    public class NavigateDisplay : Row
    {
        [SqlField("LoginUserId", FrameworkTypeEnum.Int)]
        public int LoginUserId { get; set; }

        [SqlField("LoginUserName", FrameworkTypeEnum.Nvarcahr)]
        public string LoginUserName { get; set; }

        [SqlField("Id", FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("ParentId", FrameworkTypeEnum.Int)]
        public int? ParentId { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("TextHtml", FrameworkTypeEnum.Nvarcahr)]
        public string TextHtml { get; set; }

        [SqlField("IsDivider", FrameworkTypeEnum.Bit)]
        public bool IsDivider { get; set; }

        [SqlField("IsNavbarEnd", FrameworkTypeEnum.Bit)]
        public bool IsNavbarEnd { get; set; }

        [SqlField("IsContent", FrameworkTypeEnum.Bit)]
        public bool IsContent { get; set; }

        [SqlField("NavigatePath", FrameworkTypeEnum.Nvarcahr)]
        public string NavigatePath { get; set; }

        [SqlField("PageTypeName", FrameworkTypeEnum.Nvarcahr)]
        public string PageTypeName { get; set; }

        [SqlField("Sort", FrameworkTypeEnum.Float)]
        public double? Sort { get; set; }

        [SqlField("SitemapDate", FrameworkTypeEnum.Datetime2)]
        public DateTime? SitemapDate { get; set; }
    }

    [SqlTable("Doc", "NavigateIntegrate")]
    public class NavigateIntegrate : Row
    {
        [SqlField("Id", FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("ParentId", FrameworkTypeEnum.Int)]
        public int? ParentId { get; set; }

        [SqlField("Name", FrameworkTypeEnum.Nvarcahr)]
        public string Name { get; set; }

        [SqlField("TextHtml", FrameworkTypeEnum.Nvarcahr)]
        public string TextHtml { get; set; }

        [SqlField("IsDivider", FrameworkTypeEnum.Bit)]
        public bool IsDivider { get; set; }

        [SqlField("IsNavbarEnd", FrameworkTypeEnum.Bit)]
        public bool IsNavbarEnd { get; set; }

        [SqlField("IsContent", FrameworkTypeEnum.Bit)]
        public bool IsContent { get; set; }

        [SqlField("NavigatePath", FrameworkTypeEnum.Nvarcahr)]
        public string NavigatePath { get; set; }

        [SqlField("PageTypeName", FrameworkTypeEnum.Nvarcahr)]
        public string PageTypeName { get; set; }

        [SqlField("Sort", FrameworkTypeEnum.Float)]
        public double? Sort { get; set; }

        [SqlField("SitemapDate", FrameworkTypeEnum.Datetime2)]
        public DateTime? SitemapDate { get; set; }

        [SqlField("IdName", FrameworkTypeEnum.Nvarcahr)]
        public string IdName { get; set; }

        [SqlField("ParentIdName", FrameworkTypeEnum.Nvarcahr)]
        public string ParentIdName { get; set; }
    }

    [SqlTable("Doc", "NavigateRole")]
    public class NavigateRole : Row
    {
        [SqlField("Id", true, FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("NavigateId", FrameworkTypeEnum.Int)]
        public int NavigateId { get; set; }

        [SqlField("LoginRoleId", FrameworkTypeEnum.Int)]
        public int LoginRoleId { get; set; }

        [SqlField("IsActive", FrameworkTypeEnum.Bit)]
        public bool? IsActive { get; set; }
    }

    [SqlTable("Doc", "NavigateRoleDisplay")]
    public class NavigateRoleDisplay : Row
    {
        [SqlField("NavigateId", FrameworkTypeEnum.Int)]
        public int NavigateId { get; set; }

        [SqlField("LoginRoleId", FrameworkTypeEnum.Int)]
        public int LoginRoleId { get; set; }

        [SqlField("LoginRoleName", FrameworkTypeEnum.Nvarcahr)]
        public string LoginRoleName { get; set; }

        [SqlField("NavigateRoleId", FrameworkTypeEnum.Int)]
        public int? NavigateRoleId { get; set; }

        [SqlField("IsActive", FrameworkTypeEnum.Bit)]
        public bool? IsActive { get; set; }
    }

    [SqlTable("Doc", "NavigateRoleIntegrate")]
    public class NavigateRoleIntegrate : Row
    {
        [SqlField("Id", FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("NavigateId", FrameworkTypeEnum.Int)]
        public int NavigateId { get; set; }

        [SqlField("LoginRoleId", FrameworkTypeEnum.Int)]
        public int LoginRoleId { get; set; }

        [SqlField("IsActive", FrameworkTypeEnum.Bit)]
        public bool? IsActive { get; set; }

        [SqlField("NavigateIdName", FrameworkTypeEnum.Nvarcahr)]
        public string NavigateIdName { get; set; }

        [SqlField("LoginRoleIdName", FrameworkTypeEnum.Nvarcahr)]
        public string LoginRoleIdName { get; set; }
    }

    [SqlTable("Doc", "StorageFile")]
    public class StorageFile : Row
    {
        [SqlField("Id", true, FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("FileName", FrameworkTypeEnum.Nvarcahr)]
        public string FileName { get; set; }

        [SqlField("Data", FrameworkTypeEnum.Varbinary)]
        public byte[] Data { get; set; }

        [SqlField("DataImageThumbnail", FrameworkTypeEnum.Varbinary)]
        public byte[] DataImageThumbnail { get; set; }

        [SqlField("Description", FrameworkTypeEnum.Nvarcahr)]
        public string Description { get; set; }

        [SqlField("SourceUrl", FrameworkTypeEnum.Nvarcahr)]
        public string SourceUrl { get; set; }

        [SqlField("IsIntegrate", FrameworkTypeEnum.Bit)]
        public bool IsIntegrate { get; set; }

        [SqlField("IsDelete", FrameworkTypeEnum.Bit)]
        public bool IsDelete { get; set; }
    }

    [SqlTable("Doc", "StorageFileDisplay")]
    public class StorageFileDisplay : Row
    {
        [SqlField("Id", FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("FileName", FrameworkTypeEnum.Nvarcahr)]
        public string FileName { get; set; }

        [SqlField("IsData", FrameworkTypeEnum.Bit)]
        public bool? IsData { get; set; }

        [SqlField("IsDataImageThumbnail", FrameworkTypeEnum.Bit)]
        public bool? IsDataImageThumbnail { get; set; }

        [SqlField("Description", FrameworkTypeEnum.Nvarcahr)]
        public string Description { get; set; }

        [SqlField("SourceUrl", FrameworkTypeEnum.Nvarcahr)]
        public string SourceUrl { get; set; }
    }

    [SqlTable("Doc", "StorageFileIntegrate")]
    public class StorageFileIntegrate : Row
    {
        [SqlField("Id", FrameworkTypeEnum.Int)]
        public int Id { get; set; }

        [SqlField("FileName", FrameworkTypeEnum.Nvarcahr)]
        public string FileName { get; set; }

        [SqlField("Data", FrameworkTypeEnum.Varbinary)]
        public byte[] Data { get; set; }

        [SqlField("DataImageThumbnail", FrameworkTypeEnum.Varbinary)]
        public byte[] DataImageThumbnail { get; set; }

        [SqlField("Description", FrameworkTypeEnum.Nvarcahr)]
        public string Description { get; set; }

        [SqlField("SourceUrl", FrameworkTypeEnum.Nvarcahr)]
        public string SourceUrl { get; set; }

        [SqlField("IsIntegrate", FrameworkTypeEnum.Bit)]
        public bool IsIntegrate { get; set; }

        [SqlField("IsDelete", FrameworkTypeEnum.Bit)]
        public bool IsDelete { get; set; }

        [SqlField("IdName", FrameworkTypeEnum.Nvarcahr)]
        public string IdName { get; set; }
    }
}
