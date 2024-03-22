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
            entityButton.onClick.AddListener(OnButtonClick);
        }

        public void OnDisable()
        {
            entityButton.onClick.RemoveListener(OnButtonClick);
        }
        
        private void OnButtonClick()
        {
            OnTargetClicked?.Invoke(entity);
            Debug.Log($"Button {entity.Name} clicked");
        }
    }
}
