using System;
using System.IO;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class TestAssemblyTests
    {
        [Test]
        public void TestTheTruth()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void CharacterisationTest()
        {
            StreamWriter writer;
            TextWriter oldOut = System.Console.Out;
            try
            {
                var ostrm = new FileStream("./now.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);

            }
            catch (Exception e)
            {
                System.Console.WriteLine("Cannot open Redirect.txt for writing");
                System.Console.WriteLine(e.Message);
                return;
            }

            System.Console.SetOut(writer);
            Program.Main(null);
            writer.Close();

            using (var legacy = File.OpenText(@"CharacterisationTest\legacy.txt"))
            using (var now = File.OpenText(@"./now.txt"))
            {
                while (legacy.Peek() != -1)
                {
                    Assert.That(now.ReadLine(),Is.EqualTo(legacy.ReadLine()));
                }
            }

            System.Console.SetOut(oldOut);
        }

    }
}