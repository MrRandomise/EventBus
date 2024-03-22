using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UI;

namespace Logick
{
    [UsedImplicitly]
    public sealed class EntityStorage
    {
        private readonly Dictionary<bool, List<EntityConfig>> _entities = new();
        private readonly Dictionary<bool, int> _currentIndexes;

        public EntityStorage(List<HeroListView> heroListViews)
        {
            for (int i = 0; i < heroListViews.Count; i++)
            {
                var views = heroListViews[i].GetViews();
                foreach (var view in views)
                {
                    var iEntity = view.GetComponentInChildren<EntityConfig>();
                    if (iEntity != null)
                    {
                        if(!_entities.ContainsKey(iEntity.Team))
                            _entities.Add(iEntity.Team, new List<EntityConfig>());
                        _entities[iEntity.Team].Add(iEntity);
                    }
                }
            }
            _currentIndexes = new()
            {
                {false, 0},
                {true, _entities[true].Count - 1}
            };
        }

        public EntityConfig GetStartEntity()
        {
            return _entities[false][_currentIndexes[false]];
        }

        public EntityConfig GetNextEntity(bool team)
        {
            var tries = _entities[team].Count;
            for (int i = 0; i < tries; i++)
            {
                GetNextEntityIndex(team);
                var entity = _entities[team][_currentIndexes[team]];
                if (!entity.IsDead)
                {
                    return entity;
                }
            }

            throw new Exception("No valid entity found!");
        }
        

        public bool HasAliveHeroes(bool team)
        {
            foreach (var entityConfig in _entities[team])
            {
                if(!entityConfig.IsDead) return true;
            }

            return false;
        }

        private void GetNextEntityIndex(bool team)
        {
            _currentIndexes[team]++;
            if (_currentIndexes[team] >= _entities[team].Count)
            {
                _currentIndexes[team] = 0;
            }
        }
        
        public List<EntityConfig> GetActualTeam(bool team)
        {
            var resultTeam = new List<EntityConfig>();
            foreach (var entityConfig in _entities[team])
            {
                if(!entityConfig.IsDead) resultTeam.Add(entityConfig);
            }
            return resultTeam;
        }
        
        public List<EntityConfig> GetTeam(bool team)
        {
            return _entities[team];
        }
    }
}
