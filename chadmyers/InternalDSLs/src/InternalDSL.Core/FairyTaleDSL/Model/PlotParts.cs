namespace InternalDSL.Core.FairyTaleDSL.Model
{
    public interface IPlotPart : IStoryPart
    {
    }

    public class WhoWasGoingToGrandmasHouse : IPlotPart
    {
        public bool ThroughTheForest { get; set; }
        public string RenderPart()
        {
            return "who was going to grandma's house" +
                   (ThroughTheForest ? " through the forest" : "");
        }
    }

    public class WhoHadAWickedStepMother : IPlotPart
    {
        public string Named { get; set; }

        public string RenderPart()
        {
            return "who had a wicked step mother" +
                   (string.IsNullOrEmpty(Named) ? "" : " named " + Named);
        }
    }

    public class WasControlledByAnEvilEmpire : IPlotPart
    {
        public string RenderPart()
        {
            return "was controlled by an evil empire";
        }
    }

    public class WithAnEvilEmporer : IPlotPart
    {
        public string Named { get; set; }
        public bool WhoHadAnEvilApprentice { get; set; }

        public string RenderPart()
        {
            return "with an evil empire"
                   + (string.IsNullOrEmpty(Named) ? "" : " named " + Named)
                   + (WhoHadAnEvilApprentice ? " who had an evil apprentice" : "");
        }
    }

    public class AndEvilStepSisters : IPlotPart
    {
        public string Sister1Name { get; set; }
        public string Sister2Name { get; set; }

        public string RenderPart()
        {
            return "and evil step sisters"
                   + (string.IsNullOrEmpty(Sister1Name) ? "" : " the first was named " + Sister1Name)
                   + (string.IsNullOrEmpty(Sister2Name) ? "" : " and the second was named " + Sister2Name);
        }
    }

    public class CarryingABasket : IPlotPart
    {
        public bool WithGoodies { get; set; }

        public string RenderPart()
        {
            return "carrying a basket" +
                   (WithGoodies ? " with goodies inside" : ""); 
        }
    }

    public class FightingAgainstARebellion : IPlotPart
    {
        public bool WithASecretBase { get; set; }

        public string RenderPart()
        {
            return "fighting against a rebellion" +
                   (WithASecretBase ? " with a secret base" : "");
        }
    }
}