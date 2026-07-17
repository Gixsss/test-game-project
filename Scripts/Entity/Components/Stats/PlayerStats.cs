namespace Entity.Components.Stats
{
    public class PlayerStats
    {
        public Stat Speed = new(5f);
        public Stat MagicDamage = new(5f);
        public Stat PhysicalDefense = new(0f);
        public Stat MagicDefense = new(0f);
    }
}
