using GameFramework;

namespace ShootingStar.ReferencePoolData
{
    public abstract class EntityBaseData:IReference
    {
        public int Id { get; }
        
        public virtual void Clear()
        {
            
        }
    }
}