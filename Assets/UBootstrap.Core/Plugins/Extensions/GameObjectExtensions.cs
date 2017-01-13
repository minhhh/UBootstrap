using UnityEngine;

namespace UBootstrap
{
    static public class GameObjectExtensions
    {
        public static T GetOrAddComponent<T> (this GameObject go) where T : Component
        {
            return go.GetComponent<T> () ?? go.AddComponent<T> ();
        }

        public static bool HasComponent<T> (this GameObject go) where T : Component
        {
            return go.GetComponent<T> () != null;
        }
    }
}
