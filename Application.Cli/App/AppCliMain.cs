﻿namespace Application.Cli.Doc
{
    using Application.Doc;
    using Database.Doc;
    using DatabaseIntegrate.Doc;
    using Framework;
    using Framework.Cli;
    using Framework.Cli.Config;
    using Framework.DataAccessLayer;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Command line interface application.
    /// </summary>
    public class AppCliMain : AppCli
    {
        public AppCliMain() :
            base(
                typeof(Content).Assembly, // Register Application.Database dll
                typeof(AppMain).Assembly) // Register Application dll
        {

        }

        /// <summary>
        /// Set default values if file ConfigCli.json does not exist.
        /// </summary>
        protected override void InitConfigCli(ConfigCli configCli)
        {
            string appTypeName = UtilCli.AppTypeName(typeof(AppMain));
            configCli.WebsiteList.Add(new ConfigCliWebsite()
            {
                DomainNameList = new List<ConfigCliWebsiteDomain>(new ConfigCliWebsiteDomain[] { new ConfigCliWebsiteDomain { EnvironmentName = "DEV", DomainName = "localhost", AppTypeName = appTypeName, PasswordSalt = UtilFramework.PasswordSaltConfigCreate() } }),
                FolderNameAngular = "Application.Website/",
            });

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Default ConnectionString (Windows)
                configCli.EnvironmentGet().ConnectionStringApplication = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=ApplicationDoc; Integrated Security=True;";
                configCli.EnvironmentGet().ConnectionStringFramework = "Data Source=localhost\\SQLEXPRESS; Initial Catalog=ApplicationDoc; Integrated Security=True;";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Default ConnectionString (Linux)
                configCli.EnvironmentGet().ConnectionStringApplication = "Data Source=localhost; Initial Catalog=ApplicationDoc; User Id=SA; Password=MyPassword;";
                configCli.EnvironmentGet().ConnectionStringFramework = "Data Source=localhost; Initial Catalog=ApplicationDoc; User Id=SA; Password=MyPassword;";
            }
        }

        /// <summary>
        /// Command cli generate.
        /// </summary>
        protected override void CommandGenerateFilter(GenerateFilterArgs args, GenerateFilterResult result)
        {
            result.FieldSqlList = args.FieldSqlList.Where(item => item.SchemaName == "Doc").ToList();
            result.TypeRowCalculatedList = args.TypeRowCalculatedList.Where(item => item.Namespace == "Database.Doc.Calculated").ToList();
        }

        /// <summary>
        /// Cli generate command.
        /// </summary>
        protected override void CommandGenerateIntegrate(GenerateIntegrateResult result)
        {
            // Navigate
            result.Add(Data.Query<NavigateIntegrate>().OrderBy(item => item.IdName));
            result.AddKey<Navigate>(nameof(Navigate.Name));
            result.AddReference<Navigate, Navigate>(nameof(Navigate.ParentId));

            // LoginUser
            result.Add(Data.Query<LoginUserIntegrate>().Where(item => item.IsIntegrate == true).OrderBy(item => item.IdName), isApplication: true);
            result.AddKey<LoginUser>(nameof(LoginUser.Name));

            // LoginRole
            result.Add(Data.Query<LoginRoleIntegrate>().OrderBy(item => item.IdName), isApplication: true);
            result.AddKey<LoginRole>(nameof(LoginRole.Name));

            // LoginUserRole
            result.Add(Data.Query<LoginUserRoleIntegrate>().Where(item => item.LoginUserIsIntegrate == true).OrderBy(item => item.LoginUserIdName).ThenBy(item => item.LoginRoleIdName));
            result.AddKey<LoginUserRole>(nameof(LoginUserRole.LoginUserId), nameof(LoginUserRole.LoginRoleId));
            result.AddReference<LoginUserRole, LoginUser>(nameof(LoginUserRole.LoginUserId));
            result.AddReference<LoginUserRole, LoginRole>(nameof(LoginUserRole.LoginRoleId));

            // NavigateLoginRole
            result.Add(Data.Query<NavigateRoleIntegrate>().OrderBy(item => item.NavigateIdName).ThenBy(item => item.LoginRoleIdName));
            result.AddKey<NavigateRole>(nameof(NavigateRole.NavigateId), nameof(NavigateRole.LoginRoleId));
            result.AddReference<NavigateRole, Navigate>(nameof(NavigateRole.NavigateId));
            result.AddReference<NavigateRole, LoginRole>(nameof(NavigateRole.LoginRoleId));

            // StorageFile
            result.Add(Data.Query<StorageFileIntegrate>().OrderBy(item => item.IdName));
            result.AddKey<StorageFile>(nameof(StorageFile.FileName));
            result.AddBlob<StorageFileIntegrate>(nameof(StorageFile.Data), (row) => row.FileName);

            // Content
            result.Add(Data.Query<ContentIntegrate>().OrderBy(item => item.IdName));
            result.AddKey<Content>(nameof(Content.Name));
            result.AddBlob<ContentIntegrate>(nameof(Content.TextMd), (row) => row.IdName + ".md");
            result.AddBlob<ContentIntegrate>(nameof(Content.TextHtml), (row) => row.IdName + ".html");

            // Feedback
            result.Add(Data.Query<Feedback>().OrderBy(item => item.Name));
            result.AddKey<Feedback>(nameof(Feedback.Name));
            result.AddBlob<Feedback>(nameof(Feedback.AttachmentData), (row) => row.Name + "." + row.AttachmentFileName);
        }

        /// <summary>
        /// Cli deployDb command.
        /// </summary>
        protected override void CommandDeployDbIntegrate(DeployDbIntegrateResult result)
        {
            // Navigate
            var rowList = NavigateIntegrateAppCli.RowList;
            result.Add(rowList, (item) => item.IdName, (item) => item.ParentIdName, (item) => item.Sort);

            // LoginUser
            result.Add(LoginUserIntegrateApp.RowList);
            result.Add(LoginRoleIntegrateApp.RowList);
            result.Add(LoginUserRoleIntegrateAppCli.RowList);

            // NavigateLoginRole
            result.Add(NavigateRoleIntegrateAppCli.RowList);

            // StorageFile
            result.Add(StorageFileIntegrateAppCli.RowList);

            // Content
            result.Add(ContentIntegrateAppCli.RowList);

            // Feedback
            result.Add(FeedbackAppCli.RowList);
        }
    }
}
