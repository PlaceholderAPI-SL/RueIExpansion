using PlaceholderAPI;
using PlaceholderAPI.API.Abstract;
using RueI;
using System.Reflection;

namespace RueIExpansion
{
    public class RueIExpansion : PlaceholderExpansion
    {
        public override string Author { get; set; } = "NotZer0Two";
        public override string Identifier { get; set; } = "ruei";
        public override string RequiredPlugin { get; set; } = null;

        public override bool CanRegister()
        {
            // This lets us know if RueI exist.
            bool success = false;

            Assembly assembly = typeof(RueIMain).Assembly;
            MethodInfo init = assembly.GetType("RueI.RueIMain").GetMethod("EnsureInit");

            if (init != null)
                success = true;
            else return success;

            PlaceholderAPIPlugin.HarmonyPatch.PatchAll(typeof(RueIExpansion).Assembly);

            return success;
        }

    }
}
