using System.Collections.Generic;
using Codetox.Core;
using UnityEngine;

namespace Codetox.AI.Detection
{
    public class FieldOfViewTargetDetector : MultipleTargetDetector<GameObject>

    {
        [SerializeField] [Min(0f)] private float radius;
        [SerializeField] [Range(0, 360)] private float angle;
        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private Color gizmosColor = Color.white;

        public override (List<GameObject>, bool) DetectTarget()
        {
            var colliders = Physics.OverlapSphere(transform.position, radius, targetLayers);
            var targets = new List<GameObject>();

            foreach (var coll in colliders)
            {
                var direction = this.DirectionTo(coll.transform);

                if (Vector3.Angle(transform.forward, direction) > angle * 0.5f) continue;

                var ray = new Ray(transform.position, direction);

                if (!Physics.Raycast(ray, out var hit, radius)) continue;
                if (!Equals(hit.collider.gameObject, coll.gameObject)) continue;

                targets.Add(coll.gameObject);
            }

            return (targets, targets.Count > 0);
        }
    }
}