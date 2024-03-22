using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public sealed class HeroListView : MonoBehaviour
    {
        public event Action<HeroView> OnHeroClicked;

        [SerializeField]
        private HeroView[] views;
        

        private void OnEnable()
        {
            foreach (var view in this.views)
            {
                view.OnClicked += () => this.OnHeroClicked?.Invoke(view);
            }
        }

        private void OnDisable()
        {
            Action<HeroView> @event = this.OnHeroClicked;
            if (@event == null)
            {
                return;
            }

            foreach (var @delegate in @event.GetInvocationList())
            {
                this.OnHeroClicked -= (Action<HeroView>) @delegate;
            }
        }

        public IReadOnlyList<HeroView> GetViews()
        {
            return this.views;
        }
    }
}