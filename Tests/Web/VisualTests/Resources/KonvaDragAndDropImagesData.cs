using TestingFramework.Core.Utils.Config;

namespace CanvasTests.Resources
{
    internal static class KonvaDragAndDropImagesData
    {
        private static string ImagePatternsPath { get; set; } = Directory.GetCurrentDirectory() + ConfigurationManager.GetConfigurationModel().Resources.VisualTests.KonvaDragAndDropPatternImagesPath;

        public static string SnakeImg = Path.Combine(ImagePatternsPath, "snake.jpg");
        public static string SnakeFig = Path.Combine(ImagePatternsPath, "snake2.jpg");
        public static string LionImg = Path.Combine(ImagePatternsPath, "lion.jpg");
        public static string LionFig = Path.Combine(ImagePatternsPath, "lion2.jpg");
        public static string GiraffeImg = Path.Combine(ImagePatternsPath, "giraffe.jpg");
        public static string GiraffeFig = Path.Combine(ImagePatternsPath, "giraffe2.jpg");
        public static string MonkeyImg = Path.Combine(ImagePatternsPath, "monkey.jpg");
        public static string MonkeyFig = Path.Combine(ImagePatternsPath, "monkey2.jpg");
        public static string ExpectedResult = Path.Combine(ImagePatternsPath, "expected_result.jpg");
        public static string ExpectedResultFullScreenshot = Path.Combine(ImagePatternsPath, "excpected_result_full_screenshot.jpg");
    }
}
