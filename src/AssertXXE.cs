using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XXEExamples.Tests
{
public static class AssertXXE
{
    private static string _xml = "<?xml version=\"1.0\" ?><!DOCTYPE foo [<!ENTITY xxe SYSTEM \"_EXTERNAL_FILE_\">]> <product id=\"1\"> <description>&xxe;</description></product>";

    public static void IsXMLParserSafe(Func<string, string> xmlParser, bool expectedToBeSafe)
    {
        var externalFilePath = Path.GetFullPath("external.txt");
        var xml = _xml.Replace("_EXTERNAL_FILE_", externalFilePath);
        var parsedXml = xmlParser(xml);

        var containsXXE = parsedXml.Contains("XXEVULNERABLE");

        Assert.AreEqual(containsXXE, !expectedToBeSafe);
    }
}
}
