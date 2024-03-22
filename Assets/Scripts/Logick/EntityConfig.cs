using Logick.Config;
using Logick.HeroesSkills;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;

namespace Logick
{
    public sealed class EntityConfig : MonoBehaviour
    {
        [SerializeField] HeroConfig _config;
        
        [ShowInInspector] private bool _skipTurn;
        [ShowInInspector] private bool _cantStrikeBack;
        [ShowInInspector] private bool _skipAttackTargeting;
        
        public bool SkipAttackTargeting
        {
            get => _skipAttackTargeting;
            set => _skipAttackTargeting = value;
        }
        public bool SkipTurn
        {
            get => _skipTurn;
            set => _skipTurn = value;
        }

        public bool CantStrikeBack
        {
            get => _cantStrikeBack;
            set => _cantStrikeBack = value;
        }

        private void Start()
        {
            _config.CurrentHealth = Health;
        }

        public int Health
        {
            get => _config.Health;
            set => _config.Health = value;
        }

        public int Damage
        {
            get => _config.Damage;
            set => _config.Damage = value;
        }

        public bool Team
        {
            get => _config.Team;
            set => _config.Team = value;
        }
        
        public int CurrentHealth
        {
            get => _config.CurrentHealth;
            set => _config.CurrentHealth = value;
        }

        public bool IsDead { get; set; }
        
        public string Name => name;
        
        public HeroView View => _config.View;

        public bool TryGetGlobalAbility(out BaseSkills ability)
        {
            ability = _config.GlobalSkills;
            if (_config.GlobalSkills != null) return true;
            return false;
        }
        
        public bool TryGetBeforeAttackAbility(out BaseSkills ability)
        {
            ability = _config.BeforeAttackSkills;
            if (_config.BeforeAttackSkills != null) return true;
            return false;
        }
        
        public bool TryGetAfterAttackAbility(out BaseSkills ability)
        {
            ability = _config.AfterAttackASkills;
            if (_config.AfterAttackASkills != null) return true;
            return false;
        }
        
        public bool TryGetEndTurnAbility(out BaseSkills ability)
        {
            ability = _config.EndTurnSkills;
            if (_config.EndTurnSkills != null) return true;
            return false;
        }
        
        public bool TryGetAfterStrikeSkills(out BaseSkills ability)
        {
            ability = _config.AfterStrikeSkills;
            if (_config.AfterStrikeSkills != null) return true;
            return false;
        }
    }
}
