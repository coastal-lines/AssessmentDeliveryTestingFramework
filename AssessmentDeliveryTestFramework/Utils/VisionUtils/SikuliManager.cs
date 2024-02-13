using SikuliSharp;

namespace AssessmentDeliveryTestingFramework.Utils.VisionUtils
{
    public class SikuliManager : IDisposable
    {
        private ISikuliSession _session;

        public ISikuliSession GetSikuliSession()
        {
            if (_session == null) 
            {
                _session = Sikuli.CreateSession();
            }
            
            return _session;
        }

        public IPattern LoadPatternFromFile(string filePath, float similarity = 0.9f)
        {
            var pattern = Patterns.FromFile(filePath, similarity);
            return pattern;
        }

        public Match FindMatch(IPattern pattern)
        {
            var match = GetSikuliSession().Find(pattern);
            return match;
        }

        public void DragAndDropElementns(IPattern patternSource, IPattern patternDestination)
        {
            GetSikuliSession().DragDrop(patternSource, patternDestination);
        }

        public bool IsPatternExisted(IPattern pattern)
        {
            var isVisible = GetSikuliSession().Exists(pattern);
            return isVisible;
        }

        public void HighlightRegion(SikuliSharp.Region region)
        {
            GetSikuliSession().Highlight(region, "Green");
        }

        public void Dispose()
        {
            if (_session != null)
            {
                _session.Dispose();
                _session = null;
            }
        }
    }
}
