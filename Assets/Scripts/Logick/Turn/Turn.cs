using System;
using System.Collections.Generic;

namespace Logick.Turn
{
    public class Turn
    {
        public event Action OnFinished;

        private readonly List<TurnTask> _turnTasks = new ();
        private int _currentIndex;

        public void AddTask(TurnTask task)
        {
            _turnTasks.Add(task);
        }

        public void Run()
        {
            _currentIndex = 0;
            RunNextTask();
        }

        public void Clear()
        {
            _turnTasks.Clear();
        }

        private void RunNextTask()
        {
            if (_currentIndex >= _turnTasks.Count)
            {
                OnFinished?.Invoke();
                return;
            }
            _turnTasks[_currentIndex].Run(OnTaskFinished);
        }

        private void OnTaskFinished()
        {
            _currentIndex++;
            RunNextTask();
        }
    }
}
