using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShoot
{
    [CreateAssetMenu(fileName = "CharacterSO", menuName = "TopDownShoot/CharacterSO")]
    public class CharacterSO : ScriptableObject
    {
        public MoveData moveData;
        public HealthData healthData;
        public List<WeaponSO> weapons;
    }

    [System.Serializable]
    public class HealthData
    {
        public float health = 100f;
        public float maxHealth = 100f;
    }

    [System.Serializable]

    public class MoveData
    {
        public float speed = 5f;
        public float sprintSpeed = 10f;
    }
}
