using TestingFramework.Core.Utils.Config;

namespace CanvasTests.Resources
{
    public static class KonvaEditableTextImagesData
    {
        private static string ImagePatternsPath { get; set; } = Directory.GetCurrentDirectory() + ConfigurationManager.GetConfigurationModel().Resources.VisualTests.KonvaDragAndDropPatternImagesPath;

        public static string ExpectedResult = Path.Combine(ImagePatternsPath, "editable_text_expected_result.jpg");
    }
}
