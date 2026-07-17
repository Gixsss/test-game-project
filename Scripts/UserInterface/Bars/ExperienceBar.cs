using Entity;
using UserInterface.Bars.Common;

namespace UserInterface.Bars
{
    public class ExperienceBar : DisplayBar
    {
        private Player _player;

        public void Initialize(Player player)
        {
            _player = player;
        }
        
        private void Start()
        {
            _player.Experience.OnExperienceChanged += UpdateValue;
        }
    }
}