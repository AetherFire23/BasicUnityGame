using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Utils.Raycasts
{
    public static class Raycasts
    {
        public static IIDRaycastResult IIDRaycastAtMousePosition(Func<RaycastHit2D, bool> raycastFilter)
        {
            Vector3 mouseScreenPosInWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var hits = Physics2D.RaycastAll(mouseScreenPosInWorldPosition, Vector2.zero).Where(raycastFilter);
            bool foundHit = hits.Any();
            IIDRaycastResult rayResult = new IIDRaycastResult()
            {
                HasFoundHit = foundHit,
                FirstResult = foundHit ? hits.First() : null,
                HitObject = foundHit ? hits.First().transform.gameObject : null,
                RaycastResults = hits.ToList(),
            };
            return rayResult;
        }
    }
}
