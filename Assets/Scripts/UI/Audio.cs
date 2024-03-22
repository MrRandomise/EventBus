using UnityEngine;

namespace UI
{
    public class Audio : MonoBehaviour
    {
        [SerializeField] private AudioSource startTurnClip;
        [SerializeField] private AudioSource lowHealthClip;
        [SerializeField] private AudioSource abilityClip;
        [SerializeField] private AudioSource deathClip;

        public void PlayStatTurn()
        {
            startTurnClip.Play();
        }
        
        public void PlayLowHealth()
        {
            lowHealthClip.Play();
        }
        
        public void PlayAbility()
        {
            abilityClip.Play();
        }
        
        public void PlayDeath()
        {
            deathClip.Play();
        }
        
    }
}
