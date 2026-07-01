using Quintessential;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PartType = class_139;
using Permissions = enum_149;
using Texture = class_256;

namespace Impetallurgy;

public class Impetallurgy : QuintessentialMod
{

   
    public override void Load()
    {
        Logger.Log("MAKE SURE I AM SANE (IMPETALLURGY)");

    }

    public override void PostLoad()
    {

    }
    public const string ReprojectionPermission = "Impetallurgy:Reprojection";
    public override void LoadPuzzleContent()
    {
        ImpetallurgyAtom.AddAtom();

        QApi.AddPuzzlePermission(ReprojectionPermission, "Glyph of Reprojection", "Impetallurgy");
        ImpetallurgyPart.AddGlyph();
    }
    public override void Unload()
    {
        // Blank
    }
}