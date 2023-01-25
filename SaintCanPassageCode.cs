using BepInEx;
using UnityEngine;

// mod-specific using
using Menu;
using MoreSlugcats;

namespace SaintCanPassage
{
    [BepInPlugin("kadw.saintcanpassage", "Saint Can Passage", "1.0")]
    public class SaintCanPassageCode : BaseUnityPlugin
    {
        public void OnEnable()
        {
            On.Menu.SleepAndDeathScreen.AddPassageButton += SleepAndDeathScreen_AddPassageButton;
        }

        private static void SleepAndDeathScreen_AddPassageButton(On.Menu.SleepAndDeathScreen.orig_AddPassageButton orig, SleepAndDeathScreen self, bool buttonBlack)
        {
            orig(self, buttonBlack);

            if (self.saveState != null && ModManager.MSC && self.saveState.saveStateNumber == MoreSlugcatsEnums.SlugcatStatsName.Saint)
            {
                Debug.Log("Saint Can Passage mod: Add passage button.");
                self.passageButton = new SimpleButton(self, self.pages[0], self.Translate("PASSAGE"), "PASSAGE", new Vector2(self.LeftHandButtonsPosXAdd + self.manager.rainWorld.options.SafeScreenOffset.x, Mathf.Max(self.manager.rainWorld.options.SafeScreenOffset.y, 15f)), new Vector2(110f, 30f));
                self.pages[0].subObjects.Add(self.passageButton);
                if (buttonBlack)
                {
                    self.passageButton.black = 1f;
                }
                self.passageButton.lastPos = self.passageButton.pos;
            }
        }
    }
}
