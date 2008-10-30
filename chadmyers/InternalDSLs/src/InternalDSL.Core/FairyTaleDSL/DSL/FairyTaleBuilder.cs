using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using InternalDSL.Core.FairyTaleDSL.Model;
using InternalDSL.Core.Util;

namespace InternalDSL.Core.FairyTaleDSL.DSL
{
    public class FairyTaleBuilder
    {
        public static FairyTale Build(Action<FairyTaleExpression> builder)
        {
            var expression = new FairyTaleExpression();
            builder(expression);
            return expression.FairyTale;
        }
    }

    public class FairyTaleExpression
    {
        public FairyTaleExpression()
        {
            FairyTale = new FairyTale();
        }

        public FairyTale FairyTale{ get; set;}

        public FairyTaleExpression Start<INTRODUCTION>(ISubjectFocus focus) 
            where INTRODUCTION : IIntroduction, new()
        {
            FairyTale.Introduction = new INTRODUCTION();
            FairyTale.SubjectFocus = focus;

            return this;
        }

        public FairyTaleExpression WithPlot<PLOTPART>(params Expression<Func<PLOTPART, bool>>[] extraToggles)
            where PLOTPART : IPlotPart, new()
        {
            var part = new PLOTPART();

            extraToggles.Each(t => ReflectionHelper.GetAccessor(t).SetValue(part, true));

            FairyTale.PlotParts.Add(part);

            return this;
        }

        public FairyTaleExpression EndingWith<PLOTENDING>()
            where PLOTENDING : IPlotEnding, new()
        {
            FairyTale.PlotEnding = new PLOTENDING();

            return this;
        }

        public FairyTaleExpression Finally<STORYENDING>()
            where STORYENDING : IStoryEnding, new()
        {
            FairyTale.Ending = new STORYENDING();

            return this;
        }
    }

    public static class FairyTaleExtensions
    {
        public static string ToStoryText(this FairyTale tale)
        {
            var storyParts = new List<IStoryPart>();
            storyParts.AddRange(new IStoryPart[]{tale.Introduction, tale.SubjectFocus});
            storyParts.AddRange(tale.PlotParts.Cast<IStoryPart>());
            storyParts.AddRange(new IStoryPart[]{tale.PlotEnding, tale.Ending});

            var storyBuilder = new StringBuilder();

            storyParts.Each(p => storyBuilder.AppendFormat("{0} ", p.RenderPart()));

            return storyBuilder.ToString();
        }
    }
}