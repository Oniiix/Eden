using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[RequireComponent(typeof(FindRessourceComponent), typeof(FSMComponent), typeof(MovingComponent))
    , RequireComponent(typeof(ResourcesDetectionComponent), (typeof(DetectionComponent)))]
public class Fauna : LivingElement
{
    [SerializeField] public event Action onDeath;
    [SerializeField] float hungerIncreaseTime = 0;
    [SerializeField] float thirstIncreaseTime = 0;
    [SerializeField] AnimationComp animationComp = null;

    [field: SerializeField] public ResourcesDetectionComponent resourcesDetectionComponent = null;
    [field: SerializeField, HideInInspector] public FaunaCharacteristic faunaChara = null;
    [field: SerializeField] public FSMComponent fsmComponent = null;
    [field: SerializeField] public MovingComponent MovingComponent = null;
    [field: SerializeField, HideInInspector] public bool IsInGoodHabitat {get; set; } = false;
    [field: SerializeField, HideInInspector] public bool IsHungry {get; set; } = false;

    Element currentFoodTarget = null;
    Node currentWaterTarget = null;
    //TODO Remove
    float lifeTimer;
    [field:SerializeField, HideInInspector] public bool IsDead { get; private set; } = false;

    #region UI

    [SerializeField] StatusWindow statusWindowType = null;
    [SerializeField, HideInInspector] StatusWindow statusWindowInstance = null;
    void InitializeUI()
    {
        if (!statusWindowType) return;
        statusWindowInstance = GameUI.Instance.FeedBackDataPanelUI.MakeNewStatusWindow(transform, statusWindowType);
    }
    public void SetUIVisible()
    {
        statusWindowInstance.ShowUI();
    }
    public void SetUIInVisible()
    {
        statusWindowInstance.HideUI();
    }
    #endregion

    private void Awake()
    {
        onDeath += OnDeath;
    }

    protected override void Init()
    {
        FaunaCharacteristic _faunaChara = Instantiate(CharacteristicComponent.Characteristic) as FaunaCharacteristic;
        if (!_faunaChara)
            Debug.Log("Cast didn't work");
        else
        {
            faunaChara = _faunaChara;
        }
        InvokeRepeating(nameof(UpdateHunger), 1, hungerIncreaseTime);
        InvokeRepeating(nameof(UpdateThirst), 1, thirstIncreaseTime);

        CharacteristicComponent = GetComponent<CharacteristicComponent>();
        InitializeUI();
    }
    private void Update()
    {
        if (faunaChara.life.CurrentValue <= 0)
            onDeath.Invoke();
        else
        {
            //Todo Remove Test death
            lifeTimer += Time.deltaTime;
                //Debug.Log(lifeTimer);
            if (lifeTimer > 1)
            {
                //Je l'ai mit la pour pas que ça tick a chaque frame
                DetecResources();
                faunaChara.life.CurrentValue -= 1;
                lifeTimer = 0;
            }
        }
    }
    void UpdateHunger()
    {
        if (faunaChara.hunger.CurrentValue <= faunaChara.hunger.MinValue) return;
        faunaChara.hunger.CurrentValue -= 5;
    }
    void UpdateThirst()
    {
        if (faunaChara.thirst.CurrentValue <= faunaChara.thirst.MinValue) return;
        faunaChara.thirst.CurrentValue -= 3;
    }

    public bool GetHunger()
    {
        bool _hunger = faunaChara.hunger.CurrentValue <= faunaChara.HungerLimit;
        if (_hunger)
            IsHungry = true;
        return IsHungry;
    }

    public bool GetGreatHunger()
    {
        return faunaChara.hunger.CurrentValue <= faunaChara.HungerLimit / 2;
    }

    void DetecResources()
    {
        // Debug.Log("Detect");
        if (resourcesDetectionComponent.DetectElements())
        {
            string sds = string.Empty;
        }
            
        //Debug.Log(resourcesDetectionComponent.Elements.Count);

            //currentFoodTarget = FindClosestFood(resourcesDetectionComponent.Elements);
        //if (resourcesDetectionComponent.DetectWater())
        //    currentWaterTarget = FindClosestWater(resourcesDetectionComponent.Water);
    }

    Element FindClosestFood(List<Element> _elements)
    {
        float _distance = float.MaxValue;
        Element _currentElement = null;
        foreach(Element _element in _elements) 
        {
            if (Vector3.Distance(transform.position, _element.transform.position) < _distance)
                _currentElement = _element;
        }
        return _currentElement;
    }

    Node FindClosestWater(List<Node> _waters)
    {
        float _distance = float.MaxValue;
        Node _currentWater = null;
        foreach (Node _water in _waters)
        {
            if (Vector3.Distance(transform.position, _water.transform.position) < _distance)
                _currentWater = _water;
        }
        return _currentWater;
    }

    void OnDeath()
    {
        IsDead = true;
        MovingComponent.IsMoving = false;
    }
}
