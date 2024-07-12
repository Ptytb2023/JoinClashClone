using UnityEngine;

namespace Model.Messaging
{
    public interface IColidable 
    {
        void OnCollisionEnter(Collision collision);
        void OnCollisionStay(Collision collision);
        void OnCollisionExit(Collision collision);
    }
}