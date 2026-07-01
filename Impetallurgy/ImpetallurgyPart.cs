using Quintessential;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using PartType = class_139;
using Permissions = enum_149;
using Texture = class_256;
using static Impetallurgy.ImpetallurgyAtom;

namespace Impetallurgy;

public class ImpetallurgyPart
{


    public static Texture ReprojectionBase = class_238.field_1989.field_90.field_257.field_359;

    public static Texture filtrationGlow = Brimstone.API.GetTexture("textures/select/erikhaag/MiscGlyphs/triline_glow");
    public static Texture filtrationStroke = Brimstone.API.GetTexture("textures/select/erikhaag/MiscGlyphs/triline_stroke");
    public static Texture filtrationIcon = Brimstone.API.GetTexture("textures/parts/erikhaag/MiscGlyphs/icons/filtration");
    public static Texture filtrationIconHover = Brimstone.API.GetTexture("textures/parts/erikhaag/MiscGlyphs/icons/filtration_hover");

    public static Texture bowl = class_238.field_1989.field_90.field_170;
    public static Texture hole = class_238.field_1989.field_90.field_255.field_293;
    public static Texture quicksilverIcon = class_238.field_1989.field_90.field_255.field_294;

    public static Texture[] projectionGlyphFlashAnimation = class_238.field_1989.field_90.field_256;
    public static Texture[] projectAtomAnimation => class_238.field_1989.field_81.field_614;

    public static PartType Reprojection;

    public static HexIndex reprojectionQsA = new(0, 0);
    public static HexIndex reprojectionQsB = new(1, 0);
    public static HexIndex reprojectionInput = new(0, 1);

    public static Vector2 hexGraphicalOffset(HexIndex hex) => class_187.field_1742.method_492(hex);
    public static void AddGlyph()
    {


        Reprojection = new()
        {
            field_1528 = "impetallurgy-reprojection", // ID
            field_1529 = class_134.method_253("Glyph of Filtration", string.Empty), // Name
            field_1530 = class_134.method_253("The glyph of filtration allows atoms to pass through if they match the atom in the bowl, or if the bowl is empty.", string.Empty), // Description
            field_1531 = 30, // Cost
            field_1539 = true, // Is a glyph
            field_1549 = class_238.field_1989.field_97.field_374, // Shadow/glow
            field_1550 = class_238.field_1989.field_97.field_375, // Stroke/outline
            field_1547 = filtrationIcon, // Panel icon
            field_1548 = filtrationIconHover, // Hovered panel icon
            field_1540 = new HexIndex[]
            {
               reprojectionInput, reprojectionQsA, reprojectionQsB
            },
            field_1551 = Permissions.None,
            CustomPermissionCheck = perms => perms.Contains(Impetallurgy.ReprojectionPermission)
        };
        QApi.AddPartTypeToPanel(Reprojection, false);
        AtomType quicksilver = Brimstone.API.VanillaAtoms.quicksilver;
        API.AddReprojectionRule(quicksilver, Brimstone.API.VanillaAtoms.lead, Brimstone.API.VanillaAtoms.iron);
        API.AddReprojectionRule(quicksilver, Brimstone.API.VanillaAtoms.tin, Brimstone.API.VanillaAtoms.copper);
        API.AddReprojectionRule(quicksilver, Brimstone.API.VanillaAtoms.iron, Brimstone.API.VanillaAtoms.silver);
        API.AddReprojectionRule(quicksilver, Brimstone.API.VanillaAtoms.copper, Brimstone.API.VanillaAtoms.gold);

        API.AddReprojectionRule(quicksilver, Anisium, Gratine);
        API.AddReprojectionRule(quicksilver, Gratine, Terrine);
        API.AddReprojectionRule(quicksilver, Terrine, Lardeon);
        API.AddReprojectionRule(quicksilver, Lardeon, Forr);


        QApi.AddPartType(Reprojection, static (part, pos, editor, renderer) =>
        {

            renderer.method_523(ReprojectionBase, Vector2.Zero, new Vector2(42f, 48f), 0f);
            renderer.method_528(bowl, reprojectionInput, Vector2.Zero);

            renderer.method_529(hole, reprojectionQsA, Vector2.Zero);
            renderer.method_529(quicksilverIcon, reprojectionQsA, Vector2.Zero);
            renderer.method_529(hole, reprojectionQsB, Vector2.Zero);
            renderer.method_529(quicksilverIcon, reprojectionQsB, Vector2.Zero);
        });

        QApi.RunAfterCycle((sim, first) =>
        {
            SolutionEditorBase seb = sim.field_3818;
            Dictionary<Part, PartSimState> pss = sim.field_3821;
            List<Part> parts = seb.method_502().field_3919;
            foreach (Part part in parts) {
                PartType type = part.method_1159();
                if (type == Reprojection)
                {


                    bool reprojectionA = sim.FindAtomRelative(part, reprojectionQsA).method_99(out AtomReference quicksilverA) && !quicksilverA.field_2281 && !quicksilverA.field_2282;
                    bool reprojectionB = sim.FindAtomRelative(part, reprojectionQsB).method_99(out AtomReference quicksilverB) && !quicksilverB.field_2281 && !quicksilverB.field_2282;
                    bool reprojectionC = sim.FindAtomRelative(part, reprojectionInput).method_99(out AtomReference input);

                    if (reprojectionA && reprojectionB && quicksilverA.field_2280 == quicksilverB.field_2280 && reprojectionC) {

                        if (API.ApplyReprojectionRule(quicksilverA.field_2280, input.field_2280, out AtomType result))
                        {
                            Brimstone.API.RemoveAtom(quicksilverA);
                            Brimstone.API.DrawFallingAtom(seb, quicksilverA);
                            Brimstone.API.RemoveAtom(quicksilverB);
                            Brimstone.API.DrawFallingAtom(seb, quicksilverB);

                            Vector2 hexPosition = hexGraphicalOffset(part.method_1161() + reprojectionInput.Rotated(part.method_1163()));
                            
                            float radians = (part.method_1163() + HexRotation.R180).ToRadians();
                            float sixtyDegree = (float)(Math.PI / 3);
                            seb.field_3935.Add(new class_228(seb, (enum_7)1, hexPosition, projectionGlyphFlashAnimation, 30f, Vector2.Zero, radians - sixtyDegree));
                            seb.field_3935.Add(new class_228(seb, (enum_7)1, hexPosition, projectionGlyphFlashAnimation, 30f, Vector2.Zero, radians - sixtyDegree * 2));
                            Brimstone.API.ChangeAtom(input, result);
                            input.field_2279.field_2276 = (Maybe<class_168>)new class_168(seb, (enum_7)0, (enum_132)1, input.field_2280, projectAtomAnimation, 30f);


                        }

                    }
                }
            }
        });
    }
}