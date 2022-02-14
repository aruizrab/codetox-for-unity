using Codetox.AI.Detection;
using UnityEditor;
using UnityEngine;

namespace Codetox.Editor.AI.Detection
{
    [CustomEditor(typeof(FieldOfViewTargetDetector))]
    public class FieldOfViewTargetDetectorEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            var detector = (FieldOfViewTargetDetector) target;
            var transform = detector.transform;
            var position = transform.position;
            var angle = serializedObject.FindProperty("angle").floatValue;
            var radius = serializedObject.FindProperty("radius").floatValue;
            var fovPositiveEdge = GetAngleDirection(detector, angle / 2);
            var fovNegativeEdge = GetAngleDirection(detector, -angle / 2);

            Handles.color = serializedObject.FindProperty("gizmosColor").colorValue;
            Handles.DrawWireArc(position, transform.up, fovNegativeEdge.normalized, angle, radius);
            Handles.DrawLine(position, position + fovPositiveEdge * radius);
            Handles.DrawLine(position, position + fovNegativeEdge * radius);

            Handles.color = Color.red;
            detector.CurrentTargets.ForEach(go => Handles.DrawLine(position, go.transform.position));
        }

        private static Vector3 GetAngleDirection(Component detector, float degreesAngle)
        {
            var eulerAngles = detector.transform.eulerAngles;
            var radAngle = (degreesAngle + eulerAngles.y) * Mathf.Deg2Rad;
            var x = Mathf.Sin(radAngle);
            var z = Mathf.Cos(radAngle);
            return Quaternion.Euler(eulerAngles) * new Vector3(x, 0, z);
        }
    }
}