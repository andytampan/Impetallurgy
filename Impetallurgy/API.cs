using Quintessential;
using System;
using System.Collections.Generic;

namespace Impetallurgy;


public class API {

    private static Dictionary<Tuple<AtomType, AtomType>, AtomType> reprojDict = new();

    public static void AddReprojectionRule(AtomType quicksilver, AtomType metal, AtomType result)
    {
        Tuple<AtomType, AtomType> pair = new(quicksilver, metal);
        reprojDict.Add(pair, result);
    }

    public static bool ApplyReprojectionRule(AtomType quicksilver, AtomType metal, out AtomType result)
    {
        Tuple<AtomType, AtomType> pair = new(quicksilver, metal);
        return reprojDict.TryGetValue(pair, out result);

    }
}