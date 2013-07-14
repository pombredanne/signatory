﻿using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Signatory.Models
{
    public class SettingsViewModel
    {
        public SettingsViewModel() : this(null)
        {
        }

        public SettingsViewModel(string defaultLicenseTextPath)
        {
            if (defaultLicenseTextPath != null)
            {
                var mdFile = new FileInfo(defaultLicenseTextPath);
                using (var reader = mdFile.OpenText())
                {
                    LicenseText = reader.ReadToEnd();
                }
                RequireCla = false;
            }
        }

        [Required]
        public string Repo { get; set; }

        [Required]
        public string Username { get; set; }

        [Display(Name = "Access Token"), Required]
        public string AccessToken { get; set; }

        [Display(Name = "License Text"), Required]
        public string LicenseText { get; set; }

        [Display(Name = "Require a CLA?"), Required]
        public bool RequireCla { get; set; }
    }
}