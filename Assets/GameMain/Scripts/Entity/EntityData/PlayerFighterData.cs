using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using UnityEngine;

namespace ShootingStar
{
    [Serializable]
    public class PlayerFighterData : EntityData
    {
        [SerializeField] private float changeTime;

        [SerializeField] private ThrusterData thrusterData;

        [SerializeField] private List<WeaponData> weaponDatas = new List<WeaponData>();

        private List<WeaponPointData> weaponPointDatas = new List<WeaponPointData>();

        public PlayerFighterData(int entityID, EnumEntity id) : base(entityID, (int)id)
        {
            IDataTable<DRFighter> dtPlayerFighter = GameEntry.DataTable.GetDataTable<DRFighter>();
            DRFighter drPlayerFighter = dtPlayerFighter.GetDataRow((int)id);
            changeTime = drPlayerFighter.ChangeTime;

            thrusterData = new ThrusterData(GameEntry.Entity.GenerateSerialId(), EnumEntity.ThrusterPoint, entityID);
            weaponPointDatas.Add(
                new WeaponPointData(GameEntry.Entity.GenerateSerialId(), EnumEntity.WeaponPoint, entityID)
                {
                    Position = new Vector3(1, 0, 0)
                });
            weaponPointDatas.Add(
                new WeaponPointData(GameEntry.Entity.GenerateSerialId(), EnumEntity.WeaponPoint, entityID)
                {
                    Position = new Vector3(1, 0.15f, 0),
                    Rotation = Quaternion.Euler(0, 0, 5)
                });
            weaponPointDatas.Add(
                new WeaponPointData(GameEntry.Entity.GenerateSerialId(), EnumEntity.WeaponPoint, entityID)
                {
                    Position = new Vector3(1, -0.15f, 0),
                    Rotation = Quaternion.Euler(0, 0, -5)
                });
            for (EnumEntity i = EnumEntity.PlayerProjectile1; i < EnumEntity.PlayerProjectile1 + 1; i++)
            {
                weaponDatas.Add(new WeaponData(GameEntry.Entity.GenerateSerialId(), i));
            }
        }


        public float ChangeTime
        {
            get => changeTime;
            set => changeTime = value;
        }


        public List<WeaponPointData> GetWeaponPointDatas
        {
            get => weaponPointDatas;
        }

        public ThrusterData GetThrusterData
        {
            get => thrusterData;
        }

        public List<WeaponData> GetWeaponDatas
        {
            get => weaponDatas;
        }
    }
}