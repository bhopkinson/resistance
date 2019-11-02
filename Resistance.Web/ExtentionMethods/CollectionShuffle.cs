using System;
using System.Collections.Generic;

namespace Resistance.Web.ExtentionMethods
{
    public static class CollectionShuffle
    {
        public static IList<E> ShuffleList<E>(this IList<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random random = new Random();

            while (inputList.Count > 0)
            {
                var randomIndex = random.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]);
                inputList.RemoveAt(randomIndex);
            }

            return randomList;
        }
    }
}
