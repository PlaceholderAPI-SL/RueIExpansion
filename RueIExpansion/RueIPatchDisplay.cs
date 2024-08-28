using Exiled.API.Features;
using HarmonyLib;
using RueI;

namespace RueIExpansion
{
    [HarmonyPatch(typeof(UnityProvider), "ShowHint")]
    public class RueIPatchDisplay
    {
        public static bool Prefix(UnityProvider __instance, ReferenceHub hub, ref string message)
        {
            message = PlaceholderAPI.API.PlaceholderAPI.SetPlaceholders(Player.Get(hub), message);

            return true;
        }
    }
}
