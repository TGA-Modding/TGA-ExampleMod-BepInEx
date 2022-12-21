using BepInEx;
using HarmonyLib;

namespace ExampleMod;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class TgaExampleMod : BaseUnityPlugin
{
	private void Awake()
	{
		Logger.LogInfo($"{PluginInfo.PLUGIN_NAME} ver {PluginInfo.PLUGIN_VERSION} loaded!"); // print a message to the BepInEx console
		var harmony = new Harmony(PluginInfo.PLUGIN_GUID); // create a harmony patcher
		harmony.PatchAll(); // run all patches in the mod assembly
	}
	[HarmonyPatch(typeof(LoadingScreen_TipManager))] // patch the LoadingScreen_TipManager class
	public class TipManagerPatch
	{
		[HarmonyPatch("ChooseTip")] // patch the ChooseTip method of the above class
		public static void Postfix(ref LoadingScreen_TipManager __instance) // run after the original method has finished
		{
			__instance.text.eng = "Hello, world!"; // set the english text
		}
	}
}