namespace InternalDSL.Core.FairyTaleDSL.Model
{
    public interface IStoryEnding : IStoryPart
    {
    }

    public class AndTheyLivedHappilyEverAfter : IStoryEnding
    {
        public bool UntilTheEndsOfTheirLives{ get; set; }

        public string RenderPart()
        {
            return "and they lived happily ever after" +
                   ((UntilTheEndsOfTheirLives)
                       ? " until the ends of their lives"
                       : "");
        }
    }

    public class AndOrderWasRestoredToTheGalaxy : IStoryEnding
    {
        public bool ForceBalanced { get; set; }

        public string RenderPart()
        {
            return "and order was restored to the galaxy" +
                    ((ForceBalanced)
           ? " and there was balance in The Force(TM)"
           : "");

        }
    }
}