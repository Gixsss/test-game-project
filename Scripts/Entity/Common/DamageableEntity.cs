using Entity.Components;
using UnityEngine;

namespace Entity.Common
{
    public class DamageableEntity : MonoBehaviour
    {
        public readonly Health Health = new();
    }
}