using System;
using StardewModdingAPI.Framework;
using StardewModdingAPI.Framework.Events;

namespace StardewModdingAPI.Events
{
    /// <summary>Events raised when the game loads content.</summary>
    [Obsolete("Use " + nameof(Mod.Helper) + "." + nameof(IModHelper.Events) + " instead. See https://smapi.io/3.0 for more info.")]
    public static class ContentEvents
    {
        /*********
        ** Properties
        *********/
        /// <summary>The core event manager.</summary>
        private static EventManager EventManager;

        /// <summary>Manages deprecation warnings.</summary>
        private static DeprecationManager DeprecationManager;


        /*********
        ** Events
        *********/
        /// <summary>Raised after the content language changes.</summary>
        public static event EventHandler<EventArgsValueChanged<string>> AfterLocaleChanged
        {
            add
            {
                ContentEvents.DeprecationManager.WarnForOldEvents();
                ContentEvents.EventManager.Legacy_LocaleChanged.Add(value);
            }
            remove => ContentEvents.EventManager.Legacy_LocaleChanged.Remove(value);
        }


        /*********
        ** Public methods
        *********/
        /// <summary>Initialise the events.</summary>
        /// <param name="eventManager">The core event manager.</param>
        /// <param name="deprecationManager">Manages deprecation warnings.</param>
        internal static void Init(EventManager eventManager, DeprecationManager deprecationManager)
        {
            ContentEvents.EventManager = eventManager;
            ContentEvents.DeprecationManager = deprecationManager;
        }
    }
}
