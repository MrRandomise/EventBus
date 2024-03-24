using System;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Logick
{
    public sealed class EntityButtonListener : MonoBehaviour
    {
        [SerializeField] private HeroListView heroListView;
        [SerializeField] private Button entityButton;
        [SerializeField] private EntityConfig entity;

        public Action<EntityConfig> OnTargetClicked;

        public void OnEnable()
        {
            entityButton.onClick.AddListener(OnTargetClick);
        }

        public void OnDisable()
        {
            entityButton.onClick.RemoveListener(OnTargetClick);
        }
        
        private void OnTargetClick()
        {
            OnTargetClicked?.Invoke(entity);
        }
    }
}
