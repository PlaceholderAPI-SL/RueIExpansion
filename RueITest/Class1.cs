namespace SCPList
{
    /*
    This shows using RueI to create a simple SCP list *EXILED* plugin.
    */
    using System.Text;
    using System.Drawing;

    using PlayerRoles;

    using Exiled.API.Features;
    using Exiled.API.Enums;
    using Exiled.API.Interfaces;

    using RueI.Elements;
    using RueI.Extensions.HintBuilding;
    using RueI.Displays;
    using RueI.Parsing.Enums;
    using System;

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;
    }

    public class SCPList : Plugin<Config>
    {
        public override string Name => "SCPList";

        public static DynamicElement MyElement { get; } = new(GetContent, 900);

        public static AutoElement AutoElement { get; } = new(Roles.Scps, new DynamicElement(GetContent, 900))
        {
            UpdateEvery = new(TimeSpan.FromSeconds(2))
        };

        public override void OnEnabled()
        {
            RueI.RueIMain.EnsureInit(); // make sure to always call this!
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            AutoElement.Disable();
            base.OnDisabled();
        }

        private static string GetContent(DisplayCore core)
        {
            StringBuilder sb = new StringBuilder()
                .SetSize(65, MeasurementUnit.Percentage)
                .SetAlignment(HintBuilding.AlignStyle.Right);

            foreach (Player player in Player.List)
            {
                sb.Append("Position: %player_x% %player_y% %player_z%");
            }

            return sb.ToString();
        }

        private static float Clamp(float value, float min, float max) => Math.Max(Math.Min(value, min), max);
    }
}