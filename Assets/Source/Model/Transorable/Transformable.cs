using UnityEngine;

namespace Model.Transformables
{
    public class Transformable
    {
        internal Vector3 PositionField;
        internal Quaternion RotationField; 

        public Vector3 Position => PositionField;
        public Quaternion Rotation => RotationField;

        public Vector3 Forward => RotationField * Vector3.forward;
    }
}
