using System;
using System.Collections.Generic;
using tochka_test.Core;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace tochka_test
{
    class Program
    {

        //TODO: нужно разделять id юзера и группы
        //TODO: выкладка на стену сообщества
        //TODO: английский алфавит
        //TODO: валидация

        static void Main(string[] args)
        {
            var ids = new List<string>();

            while (true)
            {
                var id = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(id)) break;   
                ids.Add(id);
            }

            var vkService = new VkService();
            var statService = new StatService();

            try
            {
                var dict = vkService.GetWallPosts(ids, 5);

                foreach (var item in dict)
                {
                    Console.WriteLine($"{item.Key}, статистика для последних 5 постов: ");
                    Console.WriteLine(statService.GetStat(item.Value));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
