using UnityEngine;

namespace Codetox.Pooling.Components
{
    public class GameObjectPoolController : ObjectPoolController<GameObject>
    {
        protected override GameObject OnCreatePoolItem()
        {
            var obj = Instantiate(objectToPool);
            obj.SetActive(false);
            return obj;
        }

        protected override void OnGetPoolItem(GameObject obj)
        {
            obj.SetActive(true);
        }

        protected override void OnReturnPoolItem(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
}