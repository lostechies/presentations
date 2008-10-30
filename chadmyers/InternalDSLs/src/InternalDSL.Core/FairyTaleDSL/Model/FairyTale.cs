using System.Collections.Generic;

namespace InternalDSL.Core.FairyTaleDSL.Model
{
    public class FairyTale
    {
        public FairyTale()
        {
            PlotParts = new List<IPlotPart>();
        }

        public IIntroduction Introduction { get; set; }
        public ISubjectFocus SubjectFocus { get; set; }
        public IList<IPlotPart> PlotParts { get; set; }
        public IPlotEnding PlotEnding { get; set; }
        public IStoryEnding Ending { get; set; }
    }
}