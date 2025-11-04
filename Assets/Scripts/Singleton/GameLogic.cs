using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : Singleton<GameLogic>
{
    [field: SerializeField] public SpawnerTool Spawner { get; private set; } = null;
}
