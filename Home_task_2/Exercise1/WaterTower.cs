﻿using System.Text;

namespace Exercise1;
//Хто керує часом?
public class WaterTower
{
    private readonly double _maxLevel;
    private double _currentLevel;
    private Faucet _faucet;
    private List<Pump> _pumps;
    //Це закритs дані, а краще, щоб їх можна було ззовні конфігурувати
    private const double WATERSPEED = 4d;
    public WaterTower(double maxLevel = 150d, params Pump[] pumps)
    {
        _maxLevel = Validation.CheckEqualsZero(maxLevel);
        _pumps = new List<Pump>(pumps);
        _faucet = new Faucet();
    }
    // якщо вода на рівні 0, то зачиняє кран,
    // вмикає насоси до моменту, поки вежа не наповниться повністю.
    // повертає рівень води
    //Хто викликає цей метод?
    public double CheckWaterLevel()
    {
        
    }
    // заповнює вежу, використовуючи загальну потужність усіх насосів одночасно 
    private void FillTower()
    {
        
    }
    private double GetTotalPumpPower()
    {
        
    }
    // забирає воду з вежі для користувачів
    public double GetWater()
    {
        
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Oб`єм: " + _maxLevel + "м^3\n");
        sb.Append("Поточний рівень води: " + _currentLevel + "м^3\n");
        sb.Append("=+=+=+=Інформація про вентиль+=+=+=+=\n");
        sb.Append(_faucet.ToString());
        sb.Append("\n=+=+=+=Інформація про насоси+=+=+=+=\n");
        int i = 0;
        foreach (var pump in _pumps)
        {
            sb.Append("Номер насосу: " + i++ + '\n');
            sb.Append(pump.ToString() + '\n');
        }
        return sb.ToString();
    }
}
