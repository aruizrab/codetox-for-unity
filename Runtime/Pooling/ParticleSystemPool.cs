using UnityEngine;

namespace Codetox.Pooling
{
    [AddComponentMenu(Framework.MenuRoot.Pooling.ParticleSystem)]
    public class ParticleSystemPool : ObjectPool<ParticleSystem>
    {
        protected override ParticleSystem CreateObject()
        {
            var system = base.CreateObject();
            system.Stop();
            return system;
        }

        protected override void OnGetObject(ParticleSystem system)
        {
            system.Clear();
            system.Play();
        }

        protected override void OnReturnObject(ParticleSystem system)
        {
            system.Stop();
        }

        protected override void OnRemoveObject(ParticleSystem system)
        {
            Destroy(system.gameObject);
        }
    }
}