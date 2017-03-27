using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magnata.Other
{
    static class AdvancedCollisionCheck
    {
        public static void Check()
        {
            List<ICollider> colliders = (from g in Gameworld.Instance.GetGameobjects(g => g.GetComponent(c => c is ICollider) != null) select g.GetComponent(c => c is ICollider) as ICollider).ToList();

            for(int i = 0; i < colliders.Count - 1; i++)
            {
                ICollider icol = colliders[i];

                for (int j = i + 1; j < colliders.Count; j++)
                    if (icol.CheckCollision(colliders[j]))
                    {
                        icol.OnCollision(colliders[j].Gameobject);
                        colliders[j].OnCollision(icol.Gameobject);
                    }
            }
        }
    }
}
