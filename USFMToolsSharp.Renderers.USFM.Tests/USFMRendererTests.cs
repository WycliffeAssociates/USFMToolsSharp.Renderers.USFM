using System;
using System.Collections.Generic;
using USFMToolsSharp.Models.Markers;
using USFMToolsSharp.Renderers.USFM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace USFMToolsSharp.Renderers.USFM.Tests
{
    [TestClass]
    public class USFMRendererTests
    {
        USFMRenderer renderer;
        USFMDocument input;
        // Using this because newline might be different per platform
        string newLine = Environment.NewLine;

        [TestInitialize]
        public void SetUp()
        {
            renderer = new USFMRenderer();
            input = new USFMDocument();
        }

        [TestMethod]
        public void TestIDEMarker()
        {
            input.Contents.Add(new IDEMarker() { Encoding = "utf-8" });
            var output = renderer.Render(input);
            Assert.AreEqual($"\\ide utf-8{newLine}", output);
        }

        [TestMethod]
        public void TestIDMarker()
        {
            input.Contents.Add(new IDMarker() { TextIdentifier = "mat"});
            var output = renderer.Render(input);
            Assert.AreEqual($"\\id mat{newLine}", output);
        }

        [TestMethod]
        public void TestTOC1()
        {
            input.Contents.Add(new TOC1Marker() { LongTableOfContentsText = "Matthew" });
            var output = renderer.Render(input);
            Assert.AreEqual($"\\toc1 Matthew{newLine}", output);
        }

        [TestMethod]
        public void TestTOC2()
        {
            input.Contents.Add(new TOC2Marker() { ShortTableOfContentsText = "Matthew" });
            var output = renderer.Render(input);
            Assert.AreEqual($"\\toc2 Matthew{newLine}", output);
        }

        [TestMethod]
        public void TestTOC3()
        {
            input.Contents.Add(new TOC3Marker() { BookAbbreviation  = "mat" });
            var output = renderer.Render(input);
            Assert.AreEqual($"\\toc3 mat{newLine}", output);
        }

        [TestMethod]
        public void TestChapter()
        {
            input.Contents.Add(new CMarker() { Number = 2, Contents = new List<Marker>() { new VMarker() { VerseNumber = "1" } } });
            var output = renderer.Render(input);
            Assert.AreEqual($"\\c 2{newLine}\\v 1 {newLine}", output);
        }

        [TestMethod]
        public void TestVMarker()
        {
            input.Contents.Add(new VMarker() { VerseNumber = "1", Contents = new List<Marker>() { new TextBlock("verse text") } });
            var output = renderer.Render(input);
            Assert.AreEqual($"\\v 1 verse text{newLine}", output);
        }

        [TestMethod]
        public void TestTextBlock()
        {
            input.Contents.Add(new TextBlock("text"));
            var output = renderer.Render(input);
            Assert.AreEqual($"text", output);
        }

        [TestMethod]
        public void TestPMarker()
        {
            input.Contents.Add(new PMarker() { Contents = new List<Marker>() { new CMarker() { Number = 1 } } });
            var output = renderer.Render(input);
            Assert.AreEqual($"{newLine}\\p{newLine}\\c 1{newLine}", output);
        }

        [TestMethod]
        public void TestQMarker()
        {
            input.Contents.Add(new QMarker() { Contents = new List<Marker>() { new TextBlock("text") } });
            var output = renderer.Render(input);
            Assert.AreEqual($"\\q1 text", output);
        }

        [TestMethod]
        public void TestAddAndAddEndMarker()
        {
            input.Contents.Add(new ADDMarker() { Contents = new List<Marker>() { new TextBlock("text") } });
            input.Contents.Add(new ADDEndMarker());
            var output = renderer.Render(input);
            Assert.AreEqual($"\\add text\\add*", output);
        }
    }
}
