﻿using System;
using System.Collections.Generic;
using System.Linq;
using AppKit;

namespace SpiderEye.Mac
{
    internal class CocoaSaveFileDialog : ISaveFileDialog
    {
        public string? Title { get; set; }
        public string? InitialDirectory { get; set; }
        public string? FileName { get; set; }
        public ICollection<FileFilter> FileFilters { get; } = new List<FileFilter>();
        public bool OverwritePrompt { get; set; }

        public DialogResult Show()
        {
            return Show(null);
        }

        public DialogResult Show(IWindow? parent)
        {
            // TODO: can't disable overwrite prompt on macOS
            using var panel = NSSavePanel.SavePanel;
            panel.Title = Title ?? string.Empty;
            panel.CanCreateDirectories = true;

            if (!string.IsNullOrWhiteSpace(InitialDirectory))
            {
                panel.DirectoryUrl = new Uri(InitialDirectory);
            }

            if (!string.IsNullOrWhiteSpace(FileName))
            {
                panel.NameFieldStringValue = FileName;
            }

            var fileTypes = FileFilters
                .SelectMany(t => t.Filters.Select(u => u.TrimStart('*', '.')))
                .Distinct()
                .ToArray();

            if (fileTypes.Length > 0)
            {
                panel.AllowedFileTypes = fileTypes;
            }

            nint result;
            if (parent == null)
            {
                result = panel.RunModal();
            }
            else
            {
                panel.BeginSheet((CocoaWindow)parent, result => NSApplication.SharedApplication.StopModalWithCode(result));
                result = NSApplication.SharedApplication.RunModalForWindow(panel);
            }

            var mappedResult = MapResult(result);
            FileName = mappedResult == DialogResult.Ok ? panel.Url.Path : null;

            return mappedResult;
        }

        private static DialogResult MapResult(nint result)
        {
            return result switch
            {
                1 => DialogResult.Ok,
                0 => DialogResult.Cancel,
                _ => DialogResult.None,
            };
        }
    }
}
