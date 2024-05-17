
namespace StatsSystem
{
    public class StatAddModificator :StatModificator
    {
        public override float GetModValued(float baseValue)
        {
            return  Value;
        }
    }
}
