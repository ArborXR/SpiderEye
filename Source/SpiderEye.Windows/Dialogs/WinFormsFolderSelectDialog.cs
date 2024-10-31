﻿using WFFolderBrowserDialog = System.Windows.Forms.FolderBrowserDialog;

namespace SpiderEye.Windows
{
    internal class WinFormsFolderSelectDialog : WinFormsDialog<WFFolderBrowserDialog>, IFolderSelectDialog
    {
        public string? SelectedPath { get; set; }

        protected override WFFolderBrowserDialog GetDialog()
        {
            return new WFFolderBrowserDialog
            {
                UseDescriptionForTitle = true,                
                Description = Title ?? string.Empty,
                SelectedPath = SelectedPath ?? string.Empty,
                ShowNewFolderButton = true,
            };
        }

        protected override void BeforeReturn(WFFolderBrowserDialog dialog)
        {
            SelectedPath = dialog.SelectedPath;
        }
    }
}
