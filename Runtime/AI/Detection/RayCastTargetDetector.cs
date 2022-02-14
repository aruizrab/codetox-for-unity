using Codetox.Core;
using UnityEngine;

namespace Codetox.AI.Detection
{
    public class RayCastDetector : TargetDetector<GameObject>
    {
        [SerializeField] private LayerMask targetLayers;
        [SerializeField] private float distance;
        [SerializeField] private Color rayColor = Color.white;
        [SerializeField] private Color rayColorWhenTargetDetected = Color.red;

        private void OnDrawGizmos()
        {
            var t = transform;
            var position = t.position;
            Gizmos.color = HasTarget ? rayColorWhenTargetDetected : rayColor;
            Gizmos.DrawLine(position, position + t.forward * distance);
        }

        public override (GameObject, bool) DetectTarget()
        {
            var t = transform;
            var ray = new Ray(t.position, t.forward);
            var isTargetHit = Physics.Raycast(ray, out var targetHit, distance);

            if (isTargetHit && this.IsLayerInLayerMask(targetHit.collider.gameObject.layer, targetLayers))
                return (targetHit.collider.gameObject, true);

            return (null, false);
        }
    }
}