using Logick.Config;
using Logick.HeroesSkills;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Logick
{
    public sealed class EntityConfig : MonoBehaviour
    {
        [SerializeField] private HeroConfig _config;
        [SerializeField] private HeroView _view;
        [SerializeField] private Image _portrait;

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

        private void Awake()
        {
            _portrait.sprite = _config.PortraitIcon;
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
        
        public string Name => _config.name;
        
        public HeroView View => _view;

        public bool TryGetGlobalSkills(out BaseSkills skills)
        {
            skills = _config.GlobalSkills;
            if (_config.GlobalSkills != null) return true;
            return false;
        }
        
        public bool TryGetBeforeAttackSkills(out BaseSkills skills)
        {
            skills = _config.BeforeAttackSkills;
            if (_config.BeforeAttackSkills != null) return true;
            return false;
        }
        
        public bool TryGetAfterAttackSkills(out BaseSkills skills)
        {
            skills = _config.AfterAttackASkills;
            if (_config.AfterAttackASkills != null) return true;
            return false;
        }
        
        public bool TryGetEndTurnSkills(out BaseSkills skills)
        {
            skills = _config.EndTurnSkills;
            if (_config.EndTurnSkills != null) return true;
            return false;
        }
        
        public bool TryGetAfterStrikeSkills(out BaseSkills skills)
        {
            skills = _config.AfterStrikeSkills;
            if (_config.AfterStrikeSkills != null) return true;
            return false;
        }
    }
}
