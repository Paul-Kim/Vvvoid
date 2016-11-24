﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class StatManager : MonoBehaviour {

    public const double DEFALT_SPEED = 1.0;
    public const double DEFALT_MASS = 10;
    public double currentScaleStep = 0.0;
    double _velocity;
    public double distance { get; private set; }
    double _fuelAmout;
    public double _maxFuelAmout;
    double _mass;
    double _fuelConsumtionForEachTouch = 10.0;
    int resource;

    public Text _distanceUI = null;
    public Text _velocityUI = null;
    public Text _fuelUI = null;

    void Start () {
        _velocity = DEFALT_SPEED;
        distance = 0.0;
        _fuelAmout = _maxFuelAmout * 0.5;
        _mass = DEFALT_MASS;
	}

    string SetText(ref Text target, ref double targetValue, String formatStr)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Length = 0;
        sb.AppendFormat(formatStr, targetValue);
        target.text = sb.ToString();
        sb.Length = 0;
        return sb.ToString();
    }

    void Update () {
        distance += (double)Time.deltaTime * _velocity;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Length = 0;

        sb.AppendFormat("Dist : {0:N3} m", distance);
        _distanceUI.text = sb.ToString();
        sb.Length = 0;

        sb.AppendFormat("Speed : {0:N3} m/s", _velocity);
        _velocityUI.text = sb.ToString();
        sb.Length = 0;

        sb.AppendFormat("Fuel : {0:N1} / {1:N1} ", _fuelAmout, _maxFuelAmout);
        _fuelUI.text = sb.ToString();
        sb.Length = 0;

        if (Input.GetButtonDown("Fire1"))
        {
            double consumedEnergy = AccelCharacter(_fuelConsumtionForEachTouch);
            if (consumedEnergy > 0.0)
            {
                AnimateAccel(consumedEnergy);
            }
        }
    }

    IEnumerator AnimateAccel(double consumeAmount)
    {
        yield return null;
    }

    public float GetScrollSpeed() { return (float)(_velocity / Math.Pow(2.0, currentScaleStep)); }

    //clicker game has to have stat by double
    public double GetRealSpeed() { return _velocity; }

    public double AccelCharacter(double energy)
    {
        if (_fuelAmout - energy > 0)
        {
            _fuelAmout -= energy;
        }
        else
        {
            _fuelAmout = 0;
            energy = _fuelAmout;
        }

        _velocity = AddSpeed(_velocity, _mass, energy);
        //it return consumed energy
        return energy;
    }

    double AddSpeed(double curVelocity , double targetMass, double energyToAdd)
    {
        double cur_energy = 0.5 * curVelocity * curVelocity * targetMass;
        cur_energy += energyToAdd;
        curVelocity = Math.Sqrt(cur_energy * 2 / targetMass);

        return curVelocity;
    }

    public double GetFuel(double getAmout)
    {
        if (getAmout + _fuelAmout < _maxFuelAmout)
            _fuelAmout += getAmout;
        else
            _fuelAmout = _maxFuelAmout;

        return _fuelAmout;
    }

    public void AddResource(int resource)
    {
        this.resource += resource;
    }

    public int GetResource()
    {
        return resource;
    }
    
}