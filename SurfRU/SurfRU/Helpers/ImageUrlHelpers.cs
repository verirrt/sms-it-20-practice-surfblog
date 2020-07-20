using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfRU.Helpers
{
    public class ImageUrlHelpers
    {
        public static string GetUrl(Guid guid)
        {

            if (guid == Guid.Empty)
            {
                return null;
            }
            return string.Format("/Content/Images/Uploads/{0}.jpg", guid);
        }
    }
}