namespace InternalDSL.Core.FairyTaleDSL.Model
{
    public interface IPlotEnding : IStoryPart
    {
    }

    public class AndSheMarriedThePrince : IPlotEnding
    {
        public string PrinceName { get; set; }
        public bool InAChurch { get; set; }
        public Season DuringSeason { get; set; }

        public string RenderPart()
        {
            throw new System.NotImplementedException();
        }
    }

    public enum Season
    {
        Spring,
        Summer,
        Fall,
        Winter
    }

    public class AndTheWickedWolfPerished : IPlotEnding
    {
        public string RenderPart()
        {
            return "and the wicked wolf perished";
        }
    }

    public class AndTheEmpireFell : IPlotEnding
    {
        public string RenderPart()
        {
            throw new System.NotImplementedException();
        }
    }
}