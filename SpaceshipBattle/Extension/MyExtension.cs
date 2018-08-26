using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceshipBattle.Extension
{
   public static class MyExtension
    {
        public static Dictionary<T, T> AppendDictionary<T>(this Dictionary<T, T> dictionary1, Dictionary<T, T> dictionary2)
        {
            foreach (var item in dictionary2)
            {
                if (!dictionary1.ContainsKey(item.Key))
                {
                    dictionary1.Add(item.Key, item.Value);
                }
            }
            return new Dictionary<T, T>(dictionary1);
        }
    }
}
