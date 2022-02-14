using UnityEngine;

namespace Codetox.Pooling.Components
{
    public class ParticleSystemPoolController : ObjectPoolController<ParticleSystem>
    {
        protected override ParticleSystem OnCreatePoolItem()
        {
            var ps = Instantiate(objectToPool);
            ps.Stop();
            return ps;
        }

        protected override void OnGetPoolItem(ParticleSystem ps)
        {
            ps.Clear();
            ps.Play();
        }

        protected override void OnReturnPoolItem(ParticleSystem ps)
        {
            ps.Stop();
        }
    }
}