using System;
using System.Collections.Generic;
using System.Text;
using USFMToolsSharp.Models.Markers;

namespace USFMToolsSharp.Renderers.USFM
{
    public class USFMRenderer
    {
        public List<string> UnrenderableMarkers;

        public USFMRenderer()
        {
            UnrenderableMarkers = new List<string>();
        }
        public string Render(USFMDocument input)
        {
            StringBuilder output = new StringBuilder();
            foreach(var marker in input.Contents)
            {
                RenderMarker(marker, output);
            }
            return output.ToString();
        }

        private void RenderMarker(Marker input, StringBuilder output)
        {
            switch (input)
            {
                case IDMarker iDMarker:
                    output.AppendLine($"\\id {iDMarker.TextIdentifier}");
                    break;
                case TOC1Marker tOC1Marker:
                    output.AppendLine($"\\toc1 {tOC1Marker.LongTableOfContentsText}");
                    break;
                case TOC2Marker tOC2Marker:
                    output.AppendLine($"\\toc2 {tOC2Marker.ShortTableOfContentsText}");
                    break;
                case TOC3Marker tOC3Marker:
                    output.AppendLine($"\\toc3 {tOC3Marker.BookAbbreviation}");
                    break;
                case CMarker cMarker:
                    output.AppendLine($"\\c {cMarker.Number}");
                    foreach(var marker in input.Contents)
                    {
                        RenderMarker(marker, output);
                    }
                    break;
                case VMarker vMarker:
                    output.Append($"\\v {vMarker.VerseNumber} ");
                    foreach(var marker in input.Contents)
                    {
                        RenderMarker(marker, output);
                    }
                    output.Append("\n");
                    break;
                case TextBlock textBlock:
                    output.Append(textBlock.Text);
                    break;
                case PMarker pMarker:
                    output.AppendLine();
                    output.AppendLine("\\p");
                    foreach(var marker in input.Contents)
                    {
                        RenderMarker(marker, output);
                    }
                    break;
                case QMarker qMarker:
                    output.Append($"\\q{qMarker.Depth} ");
                    foreach(var marker in input.Contents)
                    {
                        RenderMarker(marker, output);
                    }
                    break;
                case ADDMarker aDDMarker:
                    output.Append("\\add ");
                    foreach(var marker in input.Contents)
                    {
                        RenderMarker(marker, output);
                    }
                    break;
                case ADDEndMarker _:
                    output.Append("\\add*");
                    break;
                case BDMarker bDMarker:
                    output.Append("\\bd");
                    foreach(var marker in input.Contents)
                    {
                        RenderMarker(marker, output);
                    }
                    output.Append("\\bd*");
                    break;
                case BDITMarker bDITMarker:
                    output.Append("\\bdit");
                    foreach(var marker in input.Contents)
                    {
                        RenderMarker(marker, output);
                    }
                    output.Append("\\bdit*");
                    break;
                case BKMarker bKMarker:
                    output.Append($"\\bd {bKMarker.BookTitle} \\bd*");
                    break;
                case CAMarker cAMarker:
                    output.AppendLine($"\\ca {cAMarker.AltChapterNumber} \\ca*");
                    break;
                case CDMarker cDMarker:
                    output.AppendLine($"\\cd {cDMarker.Description}");
                    break;
                case CLMarker cLMarker:
                    output.AppendLine($"\\cl {cLMarker.Label}");
                    break;
                case CLSMarker cLSMarker:
                    output.AppendLine("\\cls");
                    foreach(var marker in input.Contents)
                    {
                        RenderMarker(marker, output);
                    }
                    break;
                case IDEMarker iDEMarker:
                    output.AppendLine($"\\ide {iDEMarker.Encoding}");
                    break;
                case HMarker hMarker:
                    output.AppendLine($"\\h {hMarker.HeaderText}");
                    break;
                case MTMarker mTMarker:
                    output.AppendLine($"\\mt {mTMarker.Title}");
                    break;
                default:
                    UnrenderableMarkers.Add(input.Identifier);
                    break;
            }
        }
    }
}
