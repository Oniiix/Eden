using System.Collections.Generic;
using UnityEngine;

public class FindRessourceComponent : MonoBehaviour
{
    Fauna faunaElement = null;
    DetectionComponent detectComponent = null;

    private void Start()
    {
        detectComponent = GetComponent<DetectionComponent>();
    }
    float GetDistanceToHabitats(Habitat _habitat)
    {
      return  Vector3.Distance(transform.position, _habitat.transform.position);
    }

    void GetHabitatCost()
    {
        Fauna _animal = gameObject.GetComponent<Fauna>();
        FaunaCharacteristic _chara = (FaunaCharacteristic)_animal.CharacteristicComponent.Characteristic;
        if (!detectComponent) return;
        for (int i = 0; i < detectComponent.Habitats.Count; i++)
        {
            if (_chara.DietType == TDietTypeEnum.Herbivorous)
                GetHerbivorousCost(_animal, i);

            if (_chara.DietType == TDietTypeEnum.Carnivorous)
                GetCarnivorousCost(_animal, i);
            GetThirstCost(_animal, i);
            detectComponent.Habitats[i].Value += GetDistanceToHabitats((detectComponent.Habitats[i].Key))/1000;
        }
    }

    private void GetThirstCost(Fauna _animal, int i)
    {
        int _size = detectComponent.Habitats[i].Key.Nodes.Count;
        for (int j = 0; j < _size; j++)
        {
            if (detectComponent.Habitats[i].Key.Nodes[j].GroundType == EGround.Water)
            {
                if (_animal.GetThirst())
                    detectComponent.Habitats[i].Value -= 2;
                if (_animal.GetGreatThirst())
                    detectComponent.Habitats[i].Value -= 6;
            }
        }
    }

    private void GetCarnivorousCost(Fauna _animal, int i)
    {
        int _size = detectComponent.Habitats[i].Key.GetMeatElement().Count;
        for (int j = 0; j < _size; j++)
        {
            if (_animal.GetHunger())
                detectComponent.Habitats[i].Value -= 1;
            if (_animal.GetGreatHunger())
                detectComponent.Habitats[i].Value -= 4;
        }
    }

    private void GetHerbivorousCost(Fauna _animal, int i) 
    { 

        int _size = detectComponent.Habitats[i].Key.GetPlantElement().Count;
        for (int j = 0; j < _size; j++)
        {
            if (_animal.GetHunger())
                detectComponent.Habitats[i].Value -= 1;
            if (_animal.GetGreatHunger())
                detectComponent.Habitats[i].Value -= 4;
        }
    }

    void GetDistanceCost(Habitat _habitat, float _habitatCost)
    {
        _habitatCost +=  GetDistanceToHabitats(_habitat);
    }

    public Habitat GetBestHabitat()
    {
        List<Habitat> _temp = detectComponent.Habitats.GetAllKeys();
        if (_temp.Count == 0) return null;
        Habitat _bestHabitat = _temp[0];
        GetHabitatCost();
        for (int i = 0;i < detectComponent.Habitats.Count;i++)
        {
            if (detectComponent.Habitats[_temp[i]] < detectComponent.Habitats[_bestHabitat])
                _bestHabitat = _temp[i];
        }
        ResetHabitatCost();
        return _bestHabitat;
    }

    void ResetHabitatCost()
    {
        for (int i = 0; i < detectComponent.Habitats.Count; i++)
        {
            detectComponent.Habitats[i].Value = 1000;
        }
    }
}
