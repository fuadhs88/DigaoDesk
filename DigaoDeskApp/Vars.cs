﻿using System.Collections.Generic;

namespace DigaoDeskApp
{
    class Vars
    {

        public const string APP_VERSION = "1.0.3";
        public const string APP_REGKEY = @"SOFTWARE\DigaoDesk";

        public const string GITHUB_LINK = "https://github.com/digao-dalpiaz/DigaoDesk";

        public const string DATETIME_FMT = "dd/MM/yyyy HH:mm:ss";

        public static FrmMain FrmMainObj;
        public static FrmConfig FrmConfigObj;
        public static FrmApps FrmAppsObj;
        public static FrmRepos FrmReposObj;

        public static FrmFind FrmFindObj;
        public static FindMemory FindMemoryObj;

        public static List<DigaoApplication> AppList;

        public static Config Config;

    }
}
