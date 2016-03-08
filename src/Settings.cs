﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell.Settings;

namespace SolutionExtensions
{
    public static class Settings
    {
        private static SettingsManager _settings;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            _settings = new ShellSettingsManager(serviceProvider);
        }

        public static void IgnoreSolution(bool ignore)
        {
            WritableSettingsStore wstore = _settings.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!wstore.CollectionExists(Vsix.Name))
                wstore.CreateCollection(Vsix.Name);

            string solution = VSPackage.GetSolution();

            if (string.IsNullOrEmpty(solution))
                return;

            string property = GetPropertyName(solution);

            if (ignore)
            {
                wstore.SetInt32(Vsix.Name, property, 1);
            }
            else
            {
                wstore.DeleteProperty(Vsix.Name, property);
            }
        }

        public static void IgnoreFileType(IEnumerable<string> fileTypes, bool ignore)
        {
            WritableSettingsStore wstore = _settings.GetWritableSettingsStore(SettingsScope.UserSettings);

            if (!wstore.CollectionExists(Vsix.Name))
                wstore.CreateCollection(Vsix.Name);

            foreach (string fileType in fileTypes.Distinct())
            {
                string property = fileType.ToLowerInvariant();

                if (ignore)
                {
                    wstore.SetInt32(Vsix.Name, property, 1);
                }
                else
                {
                    wstore.DeleteProperty(Vsix.Name, property);
                }
            }
        }

        public static bool IsSolutionIgnored()
        {
            SettingsStore store = _settings.GetReadOnlySettingsStore(SettingsScope.UserSettings);

            string solution = VSPackage.GetSolution();

            if (string.IsNullOrEmpty(solution))
                return false;

            string property = GetPropertyName(solution);

            return store.PropertyExists(Vsix.Name, property);
        }

        public static bool IsFileTypeIgnored(IEnumerable<string> fileTypes)
        {
            SettingsStore store = _settings.GetReadOnlySettingsStore(SettingsScope.UserSettings);

            foreach (string fileType in fileTypes.Where(f => !string.IsNullOrEmpty(f)))
            {
                if (store.PropertyExists(Vsix.Name, fileType.ToLowerInvariant()))
                    return true;
            }

            return false;
        }

        private static string GetPropertyName(string solution)
        {
            string clean = solution.ToLowerInvariant().Trim();
            byte[] unicodeText = Encoding.UTF8.GetBytes(clean);

            var crypto = new MD5CryptoServiceProvider();
            byte[] result = crypto.ComputeHash(unicodeText);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
