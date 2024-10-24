using GameFramework;
using ShootingStar.DataTableData;

namespace ShootingStar
{
    public class ThrusterEntityData:AccessoryObjectData
    {
        public EntityData entityData;
        public ThrusterData thrusterData;
        
        public float Speed{ get; set; }

        public static ThrusterEntityData Create(EnumEntity id,int ownerId)
        {
            ThrusterEntityData thrusterEntityData = ReferencePool.Acquire<ThrusterEntityData>();
            thrusterEntityData.entityData = GameEntry.Data.GetData<EntityDatas>().GetEntityData(id);
            thrusterEntityData.thrusterData = GameEntry.Data.GetData<ThrusterDatas>().GetThrusterData(id);
            thrusterEntityData.OwnerId = ownerId;
            thrusterEntityData.Speed = thrusterEntityData.thrusterData.Speed;
            return thrusterEntityData;
        }
    }
}