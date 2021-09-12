using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using BBI;
using BBI.Unity.Game;
using Carbon.Simulation;
using HarmonyLib;
using UnityEngine;

namespace BetterMouse
{
    public static class Patches
    {
        [HarmonyPatch(typeof(OrientationController), "HandleAxisRotation")]
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = instructions.ToList();
            for (var index = 0; index < codes.Count; index++)
            {
                var code0 = codes[index].opcode;
                var code1 = codes[index + 1].opcode;
                var code2 = codes[index + 2].opcode;
                if (code0 == OpCodes.Ldloc_0
                    && code1 == OpCodes.Ldloc_3
                    && code2 == OpCodes.Ldloca_S)
                {
                    Mod.Log("Match");
                    for (var j = 0; j < 7; j++)
                    {
                        codes[index + j].opcode = OpCodes.Nop;
                    }

                    break;
                }
            }

            return codes.AsEnumerable();
        }

        [HarmonyPatch(typeof(OrientationController), "HandleAxisRotation")]
        public static void Prefix(ref float ___m_MouseAccelerationThreshold)
        {
            ___m_MouseAccelerationThreshold = 0f;
        }
    }
}
