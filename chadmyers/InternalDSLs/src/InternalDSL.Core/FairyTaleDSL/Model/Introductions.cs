namespace InternalDSL.Core.FairyTaleDSL.Model
{
    public interface IStoryPart
    {
        string RenderPart();
    }

    public interface IIntroduction : IStoryPart
    {

    }

    public class OnceUponATimeInA : IIntroduction
    {
        public string RenderPart()
        {
            return "Once upon a time in a";
        }
    }

    public class ThereOnceWasA : IIntroduction
    {
        public string RenderPart()
        {
            return "There once was a";
        }
    }
}