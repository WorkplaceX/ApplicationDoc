namespace Application.Doc
{
    using Database.Doc;
    using Framework;
    using Framework.DataAccessLayer;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public static class Util
    {
        /// <summary>
        /// Gets Version. This is the application version.
        /// </summary>
        public static string Version
        {
            get
            {
                return $"v1.11 (Framework { UtilFramework.Version }) - Heartbeat { UtilFramework.BackgroundServiceTimeHeartbeat }";
            }
        }

        public static byte[] ImageResize(int width, byte[] data)
        {
            Image image;
            using (var memoryStream = new MemoryStream(data))
            {
                image = Image.FromStream(memoryStream);
            }
            var scale = (double)width / image.Width;
            var widthDest = (int)Math.Round(image.Width * scale);
            var heightDest = (int)Math.Round(image.Height * scale);
            var imageDest = image.GetThumbnailImage(widthDest, heightDest, () => false, IntPtr.Zero);

            using (var memoryStream = new MemoryStream())
            {
                var imageFormat = image.RawFormat; // Original format
                imageFormat = ImageFormat.Jpeg; // Keep size low
                imageDest.Save(memoryStream, image.RawFormat);
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Parse and publish content from sql table Content to sql table Navigate.
        /// </summary>
        public static async Task ContentPublish()
        {
            // Delete all content pages and it's guest roles
            var sql = @"
            DELETE Doc.NavigateRole WHERE NavigateId IN (SELECT Id FROM Doc.Navigate WHERE IsContent = CAST(1 AS BIT))
            GO
            DELETE Doc.Navigate WHERE IsContent = CAST(1 AS BIT)
            ";
            await Data.ExecuteNonQueryAsync(sql);

            List<Content> contentList = (await Data.Query<Content>().OrderBy(item => item.NavigateTree).QueryExecuteAsync());

            // (NavigateTree, Id)
            var navigateTreeList = new Dictionary<string, int>();

            // Returns closest parent.
            int? NavigateParentId(string navigateTree)
            {
                int? result = null;
                string find = "";
                foreach (var item in navigateTreeList.Keys)
                {
                    if (navigateTree?.StartsWith(item) == true)
                    {
                        if (item.Length > find.Length)
                        {
                            find = item;
                        }
                    }
                }
                if (find != "" && find != "/")
                {
                    result = navigateTreeList[find];
                }
                return result;
            }

            foreach (var page in contentList)
            {
                // Insert Navigate
                var parentId = NavigateParentId(page.NavigateTree);
                var navigateRow = new Navigate { ParentId = parentId, Name = page.Name, TextHtml = page.TitleHtml, IsContent = true, NavigatePath = page.NavigatePath, Sort = 1000 + page.Sort.GetValueOrDefault(), SitemapDate = page.SitemapDate };
                await Data.InsertAsync(navigateRow);
                if (page.NavigateTree != null)
                {
                    navigateTreeList.Add(page.NavigateTree, navigateRow.Id);
                }
            }

            // Assign Guest role to all IsContent pages.
            sql = @"
            INSERT INTO Doc.NavigateRole
            SELECT Id, (SELECT Id FROM Doc.LoginRole WHERE Name= 'Guest') AS LoginRoleId, CAST(1 AS BIT) AS IsActive FROM Doc.Navigate WHERE IsContent = CAST(1 AS Bit)
            ";
            await Data.ExecuteNonQueryAsync(sql);
        }

        public static void Assert(bool isAssert, string exceptionText)
        {
            if (!isAssert)
            {
                throw new Exception(exceptionText);
            }
        }

        public static void Assert(bool isAssert)
        {
            if (!isAssert)
            {
                throw new Exception("Assert!");
            }
        }
    }
}
