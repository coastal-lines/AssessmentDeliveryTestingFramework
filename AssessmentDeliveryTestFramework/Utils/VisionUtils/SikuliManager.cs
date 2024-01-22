using AssessmentDeliveryTestingFramework.Core.Session;
using SikuliSharp;

namespace AssessmentDeliveryTestingFramework.Utils.VisionUtils
{
    public class SikuliManager
    {
        public ISikuliSession CreateSikuliSession()
        {
            var session = Sikuli.CreateSession();

            return session;
        }

        public IPattern LoadPatternFromFile(string filePath, float similarity = 0.9f)
        {
            var pattern = Patterns.FromFile(filePath, similarity);

            return pattern;
        }

        public Match FindMatch(ISikuliSession session, IPattern pattern)
        {
            var match = session.Find(pattern);

            return match;
        }

        public void DragAndDropElementns(ISikuliSession session, IPattern patternSource, IPattern patternDestination)
        {
            session.DragDrop(patternSource, patternDestination);
        }

        public bool IsPatternExisted(ISikuliSession session, IPattern pattern)
        {
            var isVisible = session.Exists(pattern);
            return isVisible;
        }

        public void HighlightRegion(ISikuliSession session, SikuliSharp.Region region)
        {
            session.Highlight(region, "Green");
        }
    }
}
