﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Libs
{
    public class BadZone
    {
        public int ZoneId { get; set; } = -1;
        public WowPoint ExitZoneLocation { get; set; } = new WowPoint(0, 0);
    }

    public class ClassConfiguration
    {
        public string ClassName { get; set; } = string.Empty;
        public bool Loot { get; set; } = true;

        public string PathFilename { get; set; } = string.Empty;
        public string SpiritPathFilename { get; set; } = string.Empty;
        public bool PathThereAndBack { get; set; } = true;
        public bool PathReduceSteps { get; set; } = false;

        public bool CorpseRunOnly { get; set; } = false;

        public BadZone WrongZone { get; set; } = new BadZone();

        public int NPCMaxLevels_Above { get; set; } = 1;
        public int NPCMaxLevels_Below { get; set; } = 7;
        public List<string> Blacklist { get; } = new List<string>();

        public KeyConfigurations Pull { get; set; } = new KeyConfigurations();
        public KeyConfigurations Combat { get; set; } = new KeyConfigurations();
        public KeyConfigurations Adhoc { get; set; } = new KeyConfigurations();
        public KeyConfigurations Parallel { get; set; } = new KeyConfigurations();

        public List<KeyConfiguration> ShapeshiftForm { get; } = new List<KeyConfiguration>();

        public KeyConfiguration Interact { get; set; } = new KeyConfiguration();
        public KeyConfiguration Blink { get; set; } = new KeyConfiguration();
        public string InteractKey { get; set; } = "H";

        public static Dictionary<ShapeshiftForm, ConsoleKey> ShapeshiftFormKeys { get; private set; } = new Dictionary<ShapeshiftForm, ConsoleKey>();

        public void Initialise(PlayerReader playerReader, RequirementFactory requirementFactory, ILogger logger)
        {
            Pull.Initialise(playerReader, requirementFactory, logger);
            Combat.Initialise(playerReader, requirementFactory, logger);
            Adhoc.Initialise(playerReader, requirementFactory, logger);
            Parallel.Initialise(playerReader, requirementFactory, logger);
            ShapeshiftForm.ForEach(i => i.Initialise(playerReader, requirementFactory, logger));

            Interact.Key = InteractKey;
            Interact.Initialise(playerReader, requirementFactory, logger);
            Blink.Initialise(playerReader, requirementFactory, logger);
        }
    }
}