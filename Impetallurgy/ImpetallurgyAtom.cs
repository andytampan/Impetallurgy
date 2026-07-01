using Quintessential;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PartType = class_139;
using Permissions = enum_149;
using Texture = class_256;

namespace Impetallurgy;

public class ImpetallurgyAtom
{
    public static AtomType Anisium;
    public static AtomType Gratine;
    public static AtomType Terrine;
    public static AtomType Lardeon;
    public static AtomType Forr;
    public static void AddAtom()
    {
        Anisium = Brimstone.API.CreateMetalAtom(
            ID: 67,
            modName: "impetallurgy",
            name: "Anisium",
            pathToSymbol: "textures/atoms/andytampan/Impetallurgy/anisium_symbol",
            pathToLightramp: "textures/atoms/andytampan/Impetallurgy/anisium_lightramp");
        QApi.AddAtomType(Anisium);

        Gratine = Brimstone.API.CreateMetalAtom(
            ID: 67,
            modName: "impetallurgy",
            name: "Gratine",
            pathToSymbol: "textures/atoms/andytampan/Impetallurgy/gratine_symbol",
            pathToLightramp: "textures/atoms/andytampan/Impetallurgy/gratine_lightramp");
        QApi.AddAtomType(Gratine);
        Terrine = Brimstone.API.CreateMetalAtom(
            ID: 67,
            modName: "impetallurgy",
            name: "Terrine",
            pathToSymbol: "textures/atoms/andytampan/Impetallurgy/terrine_symbol",
            pathToLightramp: "textures/atoms/andytampan/Impetallurgy/terrine_lightramp");
        QApi.AddAtomType(Terrine);
        Lardeon = Brimstone.API.CreateMetalAtom(
            ID: 67,
            modName: "impetallurgy",
            name: "Lardeon",
            pathToSymbol: "textures/atoms/andytampan/Impetallurgy/lardeon_symbol",
            pathToLightramp: "textures/atoms/andytampan/Impetallurgy/lardeon_lightramp");
        QApi.AddAtomType(Lardeon);
        Forr = Brimstone.API.CreateMetalAtom(
            ID: 67,
            modName: "impetallurgy",
            name: "Forr",
            pathToSymbol: "textures/atoms/andytampan/Impetallurgy/forr_symbol",
            pathToLightramp: "textures/atoms/andytampan/Impetallurgy/forr_lightramp");
        QApi.AddAtomType(Forr);
    }

}