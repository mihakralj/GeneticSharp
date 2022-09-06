﻿using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

namespace GeneticSharp.Domain.UnitTests.Reinsertions
{
    [TestFixture()]
    [Category("Reinsertions")]
    public class FitnessBasedReinsertionTest
    {

        [Test()]
        public void SelectChromosomes_offspringSizeGreaterThanMaxSize_Selectoffspring()
        {
            var target = new FitnessBasedReinsertion();

            var population = new Population(2, 3, Substitute.For<ChromosomeBase>(2));
            var offspring = new List<IChromosome>() {
                Substitute.For<ChromosomeBase> (2),
                Substitute.For<ChromosomeBase> (2),
                Substitute.For<ChromosomeBase> (3),
                Substitute.For<ChromosomeBase> (4)
            };

            offspring[0].Fitness = 0.2;
            offspring[1].Fitness = 0.3;
            offspring[2].Fitness = 0.5;
            offspring[3].Fitness = 0.7;

            var parents = new List<IChromosome>() {
                Substitute.For<ChromosomeBase> (5),
                Substitute.For<ChromosomeBase> (6),
                Substitute.For<ChromosomeBase> (7),
                Substitute.For<ChromosomeBase> (8)
            };

            var selected = target.SelectChromosomes(population, offspring, parents);
            Assert.AreEqual(3, selected.Count);
            Assert.AreEqual(4, selected[0].Length);
            Assert.AreEqual(3, selected[1].Length);
            Assert.AreEqual(2, selected[2].Length);
        }
    }
}

