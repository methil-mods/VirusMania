using System.Collections.Generic;
using UnityEngine;

namespace Framework.ScriptableObjects
{
    public class SingletonScriptableDatabase<T, TData> : SingletonScriptableObject<T> where T : SingletonScriptableObject<T>
    {
        [SerializeField]
        public List<TData> Database;

        public TData GetRandom()
        {
            if (Database == null || Database.Count == 0) return default;
            return Database[Random.Range(0, Database.Count)];
        }
    }
}