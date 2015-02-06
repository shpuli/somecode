using System;
using Some.Applications.Test.Entities;
using Some.Presentation.Scenes;
using Some.Presentation.UI;
using Some.Presentation.UI.Panels;

namespace Some.Applications.Test.Scenes
{
    /// <summary>
    /// Represents scene for testing <see cref="UIElement.DataContext"/> binding.
    /// </summary>
    public partial class DataContextTestScene : Scene
    {
        /// <summary>
        /// The instance of the <see cref="ColoredText"/> used for testing data context mappings.
        /// </summary>
        private ColoredText _coloredText;

        /// <summary>
        /// The instance of the <see cref="ResizeableText"/> used for testing data context mappings.
        /// </summary>
        private ResizeableText _resizeableText;

        /// <summary>
        /// Initializes an instance of the <see cref="DataContextTestScene"/> class.
        /// </summary>
        public DataContextTestScene()
        {
            IsAlternativeTextMeasurementEnabled = true;
        }

        /// <summary>
        /// Performs logic when the <see cref="Scene"/> is initialized.
        /// </summary>
        /// <remarks>All UI elements created in DataContextScene.sml.</remarks>
        protected override void OnInitialized()
        {
            View.SetValue(TextBlock.FontFamilyProperty, "PF Square Sans Pro");

            ParentBorder.DataContext = new ColoredText("Default Data", Colors.Black);
            _coloredText = new ColoredText("ColoredText", Colors.Red);
            _resizeableText = new ResizeableText("ResizeableText", 50, Dock.Bottom, 280f);

            text3.SetBinding(DockPanel.DockProperty, "Dock");
            text3.SetBinding(CatWidthManager.AttachedWidthProperty, "AttachedWidth");

            btnAddColoredText.Click += (sender, args) => ParentStackPanel.DataContext = _coloredText;
            btnAddResizeableText.Click += (sender, args) => ChildThirdStackPanel.DataContext = _resizeableText;
            btnChangeColoredText.Click += (sender, args) => _coloredText.Content += Environment.NewLine + "1st changed";
            btnChangeResizeableText.Click += (sender, args) => _resizeableText.Content += Environment.NewLine + "2nd changed";
            btnDeleteAllColoredText.Click += (sender, args) => ParentStackPanel.ClearValue(UIElement.DataContextProperty);
            btnDeleteResizeableText.Click += (sender, args) => ChildThirdStackPanel.ClearValue(UIElement.DataContextProperty);
        }
    }
}