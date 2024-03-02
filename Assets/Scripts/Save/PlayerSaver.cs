using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Save
{
    public class PlayerSaver : MonoBehaviour, ISavableComponent
    {
        [SerializeField] private int _uniqueID;
        [SerializeField] private int _executionOrder;
        [SerializeField] private readonly string _transformName = "transformValue";
        [SerializeField] private readonly string _curentHealthName = "currentHealthValue";
        [SerializeField] private readonly string _maxHealthName = "maxHealthValue";
        [SerializeField] private Transform _transform;
        [SerializeField] private Player _player;

        public int uniqueID
        {
            get
            {
                return _uniqueID;
            }
        }
        public int executionOrder
        {
            get
            {
                return _executionOrder;
            }
        }

        public ComponentData Serialize()
        {
            ExtendedComponentData data = new ExtendedComponentData();
            data.SetTransform(_transformName, _transform);
            data.SetInt(_curentHealthName, _player.healthSystem.Health);
            data.SetInt(_maxHealthName, _player.healthSystem.MaxHealth);
            return data;
        }
        public void Deserialize(ComponentData data)
        {
            ExtendedComponentData unpacked = (ExtendedComponentData)data;
            unpacked.GetTransform(_transformName, _transform);
            _player.healthSystem.Health = unpacked.GetInt(_curentHealthName);
            _player.healthSystem.MaxHealth = unpacked.GetInt(_maxHealthName);
        }
    }
}