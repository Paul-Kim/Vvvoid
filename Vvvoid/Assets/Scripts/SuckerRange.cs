﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SuckerUpgrade
{
    public SuckerUpgrade(string name, double multiply)
    {
        this.name = name;
        this.multiply = multiply;
    }

    public string name;
    public double multiply;
}

public class SuckerRange : MonoBehaviour {
    private GameObject DefulatRangeChecker;
    public double suckableRange { get; private set; }

    public List<SuckerUpgrade> upgradedList;

    [SerializeField]
    private StatManager statManager;

    void Start()
    {
        suckableRange = DefulatRangeChecker.transform.position.z;
    }

    void AddUpgrade(string name, double multiply)
    {
        upgradedList.Add(new SuckerUpgrade(name, multiply));
    }

    void ApplyUpgrade()
    {
        foreach (SuckerUpgrade upgrade in upgradedList)
        {
            suckableRange *= upgrade.multiply;
        }
    }

    void Suck(Resource resource)
    {
        statManager.AddFuel(resource.containingResource);
        statManager.AddMass(resource.containingMass);
        statManager.AddTech(resource.containingTech);
        
    }
}
