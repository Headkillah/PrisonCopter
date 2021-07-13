using PrisonHelicopter.OptionsFramework.Extensions;
using PrisonHelicopter.Utils;
using CitiesHarmony.API;
using ICities;

namespace PrisonHelicopter {
    public class PrisonHelicopterMod : IUserMod {

        string IUserMod.Name => "Prison Helicopter Mod";
        string IUserMod.Description => "Allow the police helicopter depot to spawn prison helicopters to transport prisoners to jail";

        public void OnSettingsUI(UIHelperBase helper)
        {
            helper.AddOptionsGroup<Options>();
        }

        public void OnEnabled() {
            HarmonyHelper.DoOnHarmonyReady(() => PatchUtil.PatchAll());
        }

        public void OnDisabled() {
            if (HarmonyHelper.IsHarmonyInstalled) PatchUtil.UnpatchAll();
        }
    }

}
