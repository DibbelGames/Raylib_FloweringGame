using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    public class LayerManager
    {
        int listLength;
        public List<IActor> actors = new List<IActor>();

        private List<IActor> sortedList(List<IActor> originalList)
        {
            return originalList.OrderBy(x => x.layer).ToList();
        }

        public void Main()
        {
            ///List<Actor> SortedList = actors.OrderBy(a => a.layer).ToList();

            for (int i = 0; i < sortedList(actors).Count; i++)
            {
                sortedList(actors)[i].Draw();
            }
        }
    }
}