using UnityEngine;
using System.Collections;
using Unity.Entities;
using UnityEngine.Rendering;

public class Bootstrap : MonoBehaviour
{

    private static WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeBeforeScene()
    {
        var entityManager = World.Active.GetOrCreateManager<EntityManager>();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitializeAfterScene()
    {
        var em = World.Active.GetOrCreateManager<EntityManager>(); // EntityManager manages all entities in world
    }
}
