using System;
using System.Collections.Generic;
using Framework;
using Framework.Controller;
using UnityEngine;

namespace Core.Player
{
    public class PlayerController : BaseController<PlayerController>
    {
        [SerializeReference, SubclassSelector]
        public List<Updatable<PlayerController>> updatables = new List<Updatable<PlayerController>>();

        public Transform body;

        public void Start()
        {
            foreach (var updatable in updatables) updatable.Start(this);
        }

        public void Update()
        {
            foreach (var updatable in updatables) updatable.Update(this);
        }

        private void FixedUpdate()
        {
            foreach (var updatable in updatables) updatable.FixedUpdate(this);
        }

        public void OnDrawGizmos()
        {
            foreach (var updatable in updatables) updatable.OnDrawGizmos();
        }

        public void OnDestroy()
        {
            foreach (var updatable in updatables) updatable.OnDestroy();
        }
    }
}