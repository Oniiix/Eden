using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MyGrid : MonoBehaviour
{
    [field: SerializeField, Min(2)]
    public int Length { get; private set; } = 3;

    [field: SerializeField, Min(2)]
    public int Width { get; private set; } = 3;

    [field: SerializeField, Min(0)]
    public float Gap { get; private set; } = 1;

    [field: SerializeField]
    public Habitat HabitatPreset { get; private set; } = null;

    [field: SerializeField]
    public List<Habitat> Habitats = new();

    public bool HabitatsIsEmpty => Habitats.Count == 0;

    public void GenerateGrid()
    {
        if (!HabitatPreset)
        {
            Debug.Log("[MyGrid] habitatPreset is null");
            return;
        }

        ClearGrid();
        Vector3 _position = Vector3.zero;
        Habitat _habitat = null;
        int _index = 1;

        for (int l = 0; l < Length; l++)
        {
            for (int w = 0; w < Width; w++)
            {
                float _habitatSizeWidth = HabitatPreset.Width * HabitatPreset.nodeSize;
                float _habitatSizeLength = HabitatPreset.Length * HabitatPreset.nodeSize;
                _position = transform.position + (new Vector3(_habitatSizeWidth / 2 + w * _habitatSizeWidth, 0, _habitatSizeLength / 2 + l * _habitatSizeLength));
                _habitat = Instantiate(HabitatPreset, transform);
                _habitat.transform.position = _position;
                _habitat.name = $"Habitat{_index}";
                _habitat.GenerateHabitat();
                Habitats.Add(_habitat);
                _index += 1;
            }
        }

        SetHabitatSuccessors();
    }
    public void ClearGrid()
    {
        if (HabitatsIsEmpty)
            return;

        int _size = Habitats.Count;

        for (int i = 0; i < _size; i++)
            Habitats[i].DestroyHabitat();

        Habitats.Clear();
    }

    void SetHabitatSuccessors()
    {
        if (HabitatsIsEmpty)
            return;

        int _size = Habitats.Count;

        for (int i = 0; i < _size; i++)
        {
            bool _canRight = i % Width != Width - 1,
            _canUp = i >= Width,
            _canDown = i < (Width * Length) - Width,
            _canLeft = i % Width != 0;

            if (_canRight)
                Habitats[i].AddSuccessor(Habitats[i + 1]);

            if (_canUp)
            {
                Habitats[i].AddSuccessor(Habitats[i - Width]);

                if (_canRight)
                    Habitats[i].AddSuccessor(Habitats[i + 1 - Width]);

                if (_canLeft)
                    Habitats[i].AddSuccessor(Habitats[i - 1 - Width]);
            }

            if (_canDown)
            {
                Habitats[i].AddSuccessor(Habitats[i + Width]);

                if (_canRight)
                    Habitats[i].AddSuccessor(Habitats[i + 1 + Width]);

                if (_canLeft)
                    Habitats[i].AddSuccessor(Habitats[i - 1 + Width]);
            }

            if (_canLeft)
                Habitats[i].AddSuccessor(Habitats[i - 1]);
        }
    }
}
