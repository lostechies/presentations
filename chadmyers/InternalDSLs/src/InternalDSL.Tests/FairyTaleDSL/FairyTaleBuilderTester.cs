using System.Diagnostics;
using InternalDSL.Core.FairyTaleDSL.DSL;
using InternalDSL.Core.FairyTaleDSL.Model;
using NUnit.Framework;

namespace InternalDSL.Tests.FairyTaleDSL
{
    [TestFixture]
    public class FairyTaleBuilderTester
    {
        [Test]
        public void TestFullDSL()
        {
            FairyTale tale = FairyTaleBuilder.Build(x =>
            {
                x.Start<ThereOnceWasA>(new LittleGirl
                                           {
                                               Name = "Little Red Riding Hood",
                                               GoldHair = false,
                                               RedHood = true
                                           })

                    .WithPlot<WhoWasGoingToGrandmasHouse>(p => p.ThroughTheForest)

                    .WithPlot<CarryingABasket>(p => p.WithGoodies)

                    .EndingWith<AndTheWickedWolfPerished>()

                    .Finally<AndTheyLivedHappilyEverAfter>();
            });

            string storyText = tale.ToStoryText();

            Debug.WriteLine(storyText);

            storyText.ShouldNotBeEmpty();
        }
    }
}