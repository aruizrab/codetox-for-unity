using UnityEngine;

namespace Codetox.Pooling
{
    [AddComponentMenu(Framework.MenuRoot.Pooling.GameObject)]
    public class GameObjectPool : ObjectPool<GameObject>
    {
        protected override GameObject CreateObject()
        {
            var obj = base.CreateObject();
            obj.SetActive(false);
            return obj;
        }

        protected override void OnGetObject(GameObject obj)
        {
            obj.SetActive(true);
        }

        protected override void OnReturnObject(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}