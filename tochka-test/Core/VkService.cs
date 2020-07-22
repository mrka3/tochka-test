using System.Collections.Generic;
using System.Linq;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace tochka_test.Core
{
    public class VkService
    {
        private readonly VkApi api;
        public VkService()
        {
            api = AuthApi();
        }

        private VkApi AuthApi()
        {
            var locApi = new VkApi();

            locApi.Authorize(new ApiAuthParams()
            {
                Login = "+79090143860",
                Password = "muratvk199837",
                ApplicationId = 7546484,
                Settings = Settings.All
            });

            return locApi;
        }

        public Dictionary<string, string> GetWallPosts(List<string> ids, ulong count)
        {
            var result = new Dictionary<string, string>();

            var users = api.Users.Get(ids);

            foreach (var user in users)
            {
                var name = $"{user.FirstName} {user.LastName}";

                var wall = api.Wall.Get(new WallGetParams()
                {
                    OwnerId = user.Id,
                    Count = count
                });

                result[name] = BuildString(wall);
            }

            return result;
        }

        private string BuildString(WallGetObject wall)
        {
            return wall.WallPosts.Aggregate("", (current, post) => current + post.Text);
        }
    }
}