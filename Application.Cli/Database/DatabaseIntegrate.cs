// Do not modify this file. It's generated by Framework.Cli generate command.

namespace DatabaseIntegrate.dbo
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Database.dbo;

    public static class FrameworkConfigGridIntegrateAppCli
    {
        public static List<FrameworkConfigGridIntegrate> RowList
        {
            get
            {
                var result = new List<FrameworkConfigGridIntegrate>
                {
                    new FrameworkConfigGridIntegrate { Id = 0, IdName = "Doc.LoginUser; ", TableId = 0, TableIdName = "Doc.LoginUser", TableNameCSharp = "Doc.LoginUser", ConfigName = null, RowCountMax = null, IsAllowInsert = null, IsShowHeader = null, IsShowPagination = null, IsDelete = false },
                    new FrameworkConfigGridIntegrate { Id = 0, IdName = "Doc.LoginUser; SignIn", TableId = 0, TableIdName = "Doc.LoginUser", TableNameCSharp = "Doc.LoginUser", ConfigName = "SignIn", RowCountMax = null, IsAllowInsert = false, IsShowHeader = false, IsShowPagination = false, IsDelete = false },
                };
                return result;
            }
        }
    }

    public static class FrameworkConfigFieldIntegrateAppCli
    {
        public static List<FrameworkConfigFieldIntegrate> RowList
        {
            get
            {
                var result = new List<FrameworkConfigFieldIntegrate>
                {
                    new FrameworkConfigFieldIntegrate { Id = 0, ConfigGridId = 0, ConfigGridIdName = "Doc.LoginUser; ", FieldId = 0, FieldIdName = "Doc.LoginUser; IsDelete", InstanceName = null, TableNameCSharp = "Doc.LoginUser", ConfigName = null, FieldNameCSharp = "IsDelete", Text = null, Description = null, IsVisible = null, IsReadOnly = null, IsMultiline = null, Sort = null, IsDelete = false },
                    new FrameworkConfigFieldIntegrate { Id = 0, ConfigGridId = 0, ConfigGridIdName = "Doc.LoginUser; SignIn", FieldId = 0, FieldIdName = "Doc.LoginUser; IsDelete", InstanceName = null, TableNameCSharp = "Doc.LoginUser", ConfigName = "SignIn", FieldNameCSharp = "IsDelete", Text = null, Description = null, IsVisible = false, IsReadOnly = null, IsMultiline = null, Sort = null, IsDelete = false },
                    new FrameworkConfigFieldIntegrate { Id = 0, ConfigGridId = 0, ConfigGridIdName = "Doc.LoginUser; ", FieldId = 0, FieldIdName = "Doc.LoginUser; IsIntegrate", InstanceName = null, TableNameCSharp = "Doc.LoginUser", ConfigName = null, FieldNameCSharp = "IsIntegrate", Text = null, Description = null, IsVisible = null, IsReadOnly = null, IsMultiline = null, Sort = null, IsDelete = false },
                    new FrameworkConfigFieldIntegrate { Id = 0, ConfigGridId = 0, ConfigGridIdName = "Doc.LoginUser; SignIn", FieldId = 0, FieldIdName = "Doc.LoginUser; IsIntegrate", InstanceName = null, TableNameCSharp = "Doc.LoginUser", ConfigName = "SignIn", FieldNameCSharp = "IsIntegrate", Text = null, Description = null, IsVisible = false, IsReadOnly = null, IsMultiline = null, Sort = null, IsDelete = false },
                };
                return result;
            }
        }
    }
}

namespace DatabaseIntegrate.Doc
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Database.Doc;

    public static class NavigateIntegrateAppCli
    {
        public static List<NavigateIntegrate> RowList
        {
            get
            {
                var result = new List<NavigateIntegrate>
                {
                    new NavigateIntegrate { Id = 0, ParentId = 0, Name = "Admin", TextHtml = "<i class=\"fas fa-shield-alt\"></i> Admin", IsDivider = false, IsNavbarEnd = false, NavigatePath = null, PageTypeName = null, Sort = 21, IdName = "Admin", ParentIdName = null },
                    new NavigateIntegrate { Id = 0, ParentId = 0, Name = "AdminLoginUser", TextHtml = "<i class=\"fas fa-user\"></i> User", IsDivider = false, IsNavbarEnd = false, NavigatePath = "/admin-user/", PageTypeName = "PageAdminLoginUser", Sort = 1, IdName = "AdminLoginUser", ParentIdName = "Admin" },
                    new NavigateIntegrate { Id = 0, ParentId = 0, Name = "AdminNavigate", TextHtml = "<i class=\"fas fa-sitemap\"></i> Navigate", IsDivider = false, IsNavbarEnd = false, NavigatePath = "/admin-navigate/", PageTypeName = "PageAdminNavigate", Sort = 1, IdName = "AdminNavigate", ParentIdName = "Developer" },
                    new NavigateIntegrate { Id = 0, ParentId = 0, Name = "AdminStorage", TextHtml = "<i class=\"far fa-folder\"></i> Storage", IsDivider = false, IsNavbarEnd = false, NavigatePath = "/storage/", PageTypeName = "PageAdminStorage", Sort = 2, IdName = "AdminStorage", ParentIdName = "Admin" },
                    new NavigateIntegrate { Id = 0, ParentId = 0, Name = "Developer", TextHtml = "<i class=\"fas fa-coffee\"></i> Developer", IsDivider = false, IsNavbarEnd = false, NavigatePath = null, PageTypeName = null, Sort = 21, IdName = "Developer", ParentIdName = null },
                    new NavigateIntegrate { Id = 0, ParentId = 0, Name = "Home", TextHtml = "<i class=\"fas fa-home\"></i> Home", IsDivider = false, IsNavbarEnd = false, NavigatePath = "/", PageTypeName = "PageHome", Sort = 1, IdName = "Home", ParentIdName = null },
                    new NavigateIntegrate { Id = 0, ParentId = 0, Name = "LoginSignIn", TextHtml = "<i class=\"fas fa-sign-in-alt\"></i> Sign in", IsDivider = false, IsNavbarEnd = true, NavigatePath = "/signin/", PageTypeName = "PageLoginSignIn", Sort = 2, IdName = "LoginSignIn", ParentIdName = null },
                    new NavigateIntegrate { Id = 0, ParentId = 0, Name = "LoginSignOut", TextHtml = "<i class=\"fas fa-sign-out-alt\"></i> Sign out", IsDivider = false, IsNavbarEnd = true, NavigatePath = "/signout/", PageTypeName = "PageLoginSignOut", Sort = 3, IdName = "LoginSignOut", ParentIdName = null },
                    new NavigateIntegrate { Id = 0, ParentId = 0, Name = "LoginSignUp", TextHtml = "<i class=\"fas fa-user-plus\"></i> Sign up", IsDivider = false, IsNavbarEnd = true, NavigatePath = "/signup/", PageTypeName = "PageLoginSignUp", Sort = 1, IdName = "LoginSignUp", ParentIdName = null },
                };
                return result;
            }
        }
    }

    public static class LoginUserRoleIntegrateAppCli
    {
        public static List<LoginUserRoleIntegrate> RowList
        {
            get
            {
                var result = new List<LoginUserRoleIntegrate>
                {
                    new LoginUserRoleIntegrate { Id = 0, LoginUserId = 0, LoginRoleId = 0, IsActive = true, LoginUserIsIntegrate = true, LoginUserIdName = "a", LoginRoleIdName = "Admin" },
                    new LoginUserRoleIntegrate { Id = 0, LoginUserId = 0, LoginRoleId = 0, IsActive = true, LoginUserIsIntegrate = true, LoginUserIdName = "c", LoginRoleIdName = "Customer" },
                    new LoginUserRoleIntegrate { Id = 0, LoginUserId = 0, LoginRoleId = 0, IsActive = true, LoginUserIsIntegrate = true, LoginUserIdName = "d", LoginRoleIdName = "Admin" },
                    new LoginUserRoleIntegrate { Id = 0, LoginUserId = 0, LoginRoleId = 0, IsActive = true, LoginUserIsIntegrate = true, LoginUserIdName = "d", LoginRoleIdName = "Developer" },
                    new LoginUserRoleIntegrate { Id = 0, LoginUserId = 0, LoginRoleId = 0, IsActive = true, LoginUserIsIntegrate = true, LoginUserIdName = "Guest", LoginRoleIdName = "Guest" },
                };
                return result;
            }
        }
    }

    public static class NavigateRoleIntegrateAppCli
    {
        public static List<NavigateRoleIntegrate> RowList
        {
            get
            {
                var result = new List<NavigateRoleIntegrate>
                {
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "Admin", LoginRoleIdName = "Admin" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "Admin", LoginRoleIdName = "Developer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "AdminLoginUser", LoginRoleIdName = "Admin" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "AdminLoginUser", LoginRoleIdName = "Developer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "AdminNavigate", LoginRoleIdName = "Developer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "AdminStorage", LoginRoleIdName = "Admin" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "AdminStorage", LoginRoleIdName = "Developer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "Developer", LoginRoleIdName = "Developer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "Home", LoginRoleIdName = "Admin" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "Home", LoginRoleIdName = "Customer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "Home", LoginRoleIdName = "Developer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "Home", LoginRoleIdName = "Guest" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "LoginSignIn", LoginRoleIdName = "Developer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "LoginSignIn", LoginRoleIdName = "Guest" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "LoginSignOut", LoginRoleIdName = "Admin" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "LoginSignOut", LoginRoleIdName = "Customer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "LoginSignOut", LoginRoleIdName = "Developer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "LoginSignUp", LoginRoleIdName = "Developer" },
                    new NavigateRoleIntegrate { Id = 0, NavigateId = 0, LoginRoleId = 0, IsActive = true, NavigateIdName = "LoginSignUp", LoginRoleIdName = "Guest" },
                };
                return result;
            }
        }
    }

    public static class StorageFileIntegrateAppCli
    {
        public static List<StorageFileIntegrate> RowList
        {
            get
            {
                var result = new List<StorageFileIntegrate>
                {
                };
                return result;
            }
        }
    }
}
