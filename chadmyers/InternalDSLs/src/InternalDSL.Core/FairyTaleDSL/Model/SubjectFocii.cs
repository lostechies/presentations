namespace InternalDSL.Core.FairyTaleDSL.Model
{
    public interface ISubjectFocus : IStoryPart
    {
    }

    public class GalaxyFarFarAway : ISubjectFocus
    {
        public string RenderPart()
        {
            return "galaxy far, far away";
        }
    }

    public class FairMaiden : ISubjectFocus
    {
        public string Name { get; set; }


        public string RenderPart()
        {
            return string.IsNullOrEmpty(Name)
                       ? "fair maiden"
                       : "fair maiden named " + Name;
        }
    }

    public class LittleGirl : ISubjectFocus
    {
        public string Name { get; set; }
        public bool GoldHair { get; set; }
        public bool RedHood { get; set; }

        public string RenderPart()
        {
            return string.Format("little girl named {0}{1}{2}",
                                 Name,
                                 GoldHair ? " with gold hair" : " with brown hair",
                                 RedHood ? " and a red hood" : "");

        }
    }
}