using System;

namespace Entity.Components
{
    public class Experience
    {
        public event Action<float, float> OnExperienceChanged;
        public event Action OnLevelUp;
        
        private float _currentExperience;
        private float _maxExperience = 200f;

        private float CurrentExperience
        {
            get => _currentExperience;
            set
            {
                _currentExperience = value;
                OnExperienceChanged?.Invoke(_currentExperience, _maxExperience);
            }
        }
        
        private float MaxExperience
        {
            get => _maxExperience;
            set
            {
                _maxExperience = value;
                OnExperienceChanged?.Invoke(_currentExperience, _maxExperience);
            }
        }
        
        public void GainExperience(float experienceGained)
        {
            CurrentExperience += experienceGained;
            while (CurrentExperience >= MaxExperience)
            {
                CurrentExperience -= MaxExperience;
                MaxExperience *= 1.25f;
                OnLevelUp?.Invoke();
            }
        }
    }
}