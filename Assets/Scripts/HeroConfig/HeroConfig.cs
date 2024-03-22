using Logick.HeroesSkills;
using UI;
using UnityEngine;

namespace Logick.Config
{
    [CreateAssetMenu(fileName = "Name Hero", menuName = "New Hero")]
    public class HeroConfig : ScriptableObject
    {
        public int Health;
        public int Damage;
        public bool Team;
        public string HeroName;
        public HeroView View;
        public int CurrentHealth;

        [SerializeReference] public BaseSkills GlobalSkills;
        [SerializeReference] public BaseSkills BeforeAttackSkills;
        [SerializeReference] public BaseSkills AfterAttackASkills;
        [SerializeReference] public BaseSkills EndTurnSkills;
        [SerializeReference] public BaseSkills AfterStrikeSkills;
    }
}

