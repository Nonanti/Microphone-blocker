using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;

namespace Unturned_AllPlugins
{
    public class Main : RocketPlugin<Config>
    {
        protected override void Load()
        {
            PlayerVoice.onRelayVoice += playerspeak;
            U.Events.OnPlayerConnected += oyunagirdin;
        }


        public void oyunagirdin(UnturnedPlayer player)
        {
            
            if (player.HasPermission(Configuration.Instance.permission))
            {
                player.Player.voice.allowVoiceChat = true;
            }
            else
            {
                player.Player.voice.allowVoiceChat = false;
                if (player.Player.voice.allowVoiceChat)
                {
                    if (player.Player.voice.isTalking)
                    {
                        UnturnedChat.Say("You dont have permision in speak.");
                    }
                }
            }
        }

        public void playerspeak(PlayerVoice speaker, bool wantsToUseWalkieTalkie, ref bool shouldAllow, ref bool shouldBroadcastOverRadio, ref PlayerVoice.RelayVoiceCullingHandler cullingHandler)
        {
            UnturnedPlayer player = UnturnedPlayer.FromPlayer(Player.player);
            if (player.HasPermission(Configuration.Instance.permission))
            {
                shouldAllow = true;
            }
            else
            {
                shouldAllow = false;
                UnturnedChat.Say("You dont have permision in speak.");
            }
        }
    }
}