using UnityEngine;

public class HabitatSystem : MonoBehaviour
{
    [SerializeField, Range(0, 100)] int updateTime = 3;
    [SerializeField] Habitat habitat = null;

    float currentTime = 0;



    private void Update() => UpdateTimer();


    void UpdateTimer()
    {
        currentTime += Time.deltaTime;
        if (currentTime > updateTime)
        {
            currentTime = 0;
            if (!habitat) Debug.Log(gameObject.name);
            HabitatConditionManager.Instance.UpdateHabitat(habitat);
        }
    }

}
