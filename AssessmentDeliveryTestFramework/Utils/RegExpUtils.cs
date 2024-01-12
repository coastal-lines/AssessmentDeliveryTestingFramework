using System.Text.RegularExpressions;

namespace AssessmentDeliveryTestingFramework.Utils
{
    public class RegExpUtils
    {
        public string Matching(string what, string where, int group = 0)
        {
            var regex = new Regex(what);
            var matches = regex.Matches(where);

            return matches[0].Groups[group].Value;
        }

        public string Matching(string what, string where)
        {
            var regex = new Regex(what);
            var matches = regex.Matches(where);

            return matches[0].Value;
        }
    }
}
