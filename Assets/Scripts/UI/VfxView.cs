using UnityEngine;

namespace UI
{
    public sealed class VfxView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem system;

        public void Play()
        {
            system.Play();
        }
    }
}
