using System;
using UnityEngine;

namespace Framework
{
    [Serializable]
    public abstract class Updatable<T> where T : MonoBehaviour
    {
        public virtual void Start(T controller) {}
        public virtual void Update(T controller) {}
        public virtual void FixedUpdate(T controller) {}
        
        // Virtual cause there is no obligation to override it in fact
        public virtual void OnDrawGizmos() {}
        public virtual void OnDestroy() {}
    }
}