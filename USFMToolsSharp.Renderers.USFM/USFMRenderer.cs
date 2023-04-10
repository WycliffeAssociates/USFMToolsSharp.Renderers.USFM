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
                    output.AppendLine($"\\c {cMarker.Number.ToString()}");
                    break;
                case VMarker vMarker:
                    output.AppendLine();
                    output.Append($"\\v {vMarker.VerseNumber} ");
                    break;
                case TextBlock textBlock:
                    output.Append(textBlock.Text);
                    break;
                case PMarker pMarker:
                    output.AppendLine();
                    output.AppendLine("\\p");
                    break;
                case QMarker qMarker:
                    output.Append($"\\q{qMarker.Depth.ToString()} ");
                    break;
                case ADDMarker aDDMarker:
                    output.Append("\\add ");
                    break;
                case ADDEndMarker _:
                    output.Append("\\add* ");
                    break;
                case BDMarker bDMarker:
                    output.Append("\\bd ");
                    break;
                case BDITMarker bDITMarker:
                    output.Append("\\bdit ");
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
                case SMarker sMarker:
                    output.AppendLine($"\\s{(sMarker.Weight == 1 ? "" : sMarker.Weight.ToString())}");
                    break;
                case BMarker bMarker:
                    output.Append("\\b ");
                    break;
                case LIMarker lIMarker:
                    output.AppendLine($"\\li{((lIMarker.Depth == 1) ? "" : lIMarker.Depth.ToString())} ");
                    break;
                case FEndMarker _:
                    output.Append("\\f* ");
                    break;
                case FREndMarker _:
                    output.Append("\\fr* ");
                    break;
                case FRMarker fRMarker:
                    output.Append($"\\fr {fRMarker.VerseReference}");
                    break;
                case FTMarker _:
                    output.Append($"\\ft ");
                    break;
                case XTMarker xTMarker:
                    output.Append($"\\xt ");
                    break;
                case PMOMarker pMOMarker:
                    output.AppendLine($"\\pmo ");
                    break;
                case PMMarker pMMarker:
                    output.AppendLine($"\\pm ");
                    break;
                case MIMarker mIMarker:
                    output.AppendLine($"\\mi ");
                    break;
                case PIMarker pIMarker:
                    output.AppendLine($"\\pi ");
                    break;
                case LHMarker lHMarker:
                    output.AppendLine($"\\lh ");
                    break;
                case FMarker fMarker:
                    output.Append($"\\f {fMarker.FootNoteCaller} ");
                    break;
                case LFMarker lFMarker:
                    output.AppendLine($"\\lf ");
                    break;
                case MMarker mMarker:
                    output.AppendLine($"\\m ");
                    break;
                case LITLMarker lITLMarker:
                    output.Append($"\\litl ");
                    break;
                case LITLEndMarker _:
                    output.Append($"\\litl* ");
                    break;
                case PCMarker pCMarker:
                    output.AppendLine($"\\pc ");
                    break;
                case MSMarker mSMarker:
                    output.AppendLine($"\\ms{(mSMarker.Weight == 1 ? "" : mSMarker.Weight.ToString())} {mSMarker.Heading}");
                    break;
                case DMarker dMarker:
                    output.AppendLine($"\\d {dMarker.Description}");
                    break;
                case SPMarker sPMarker:
                    output.AppendLine($"\\sp {sPMarker.Speaker}");
                    break;
                case TableBlock _:
                    break;
                case MRMarker mRMarker:
                    output.AppendLine($"\\mr{(mRMarker.Weight ==1 ? "" : mRMarker.Weight.ToString())} {mRMarker.SectionReference}");
                    break;
                case BDEndMarker _:
                    output.Append("\\bd* ");
                    break;
                case BDITEndMarker _:
                    output.Append("\\bdit* ");
                    break;
                case TRMarker _:
                    output.AppendLine($"\\tr ");
                    break;
                case TCMarker _:
                    output.AppendLine($"\\tc ");
                    break;
                case THMarker _:
                    output.AppendLine($"\\th ");
                    break;
                case XMarker xMarker:
                    output.Append($"\\x {xMarker.CrossRefCaller} ");
                    break;
                case XOMarker xoMarker:
                    output.Append($"\\xo {xoMarker.OriginRef} ");
                    break;
                case XQMarker xqMarker:
                    output.Append($"\\xq ");
                    break;
                default:
                    UnrenderableMarkers.Add(input.Identifier);
                    break;
            }
            foreach(var marker in input.Contents)
            {
                RenderMarker(marker, output);
            }
        }
    }
}
