# USFMToolsSharp.Renderers.USFM
A USFM renderer for USFM

# Usage

```csharp
using USFMToolsSharp;
using USFMToolsSharp.Renderers.USFM;

var parser = new USFMParser();
var document = parser.ParseFromString(usfmText);

var renderer = new USFMRenderer();
string usfm = renderer.Render(document);

// Markers the renderer doesn't support are skipped and their identifiers collected here
var skipped = renderer.UnrenderableMarkers;
```

# Requirements

This package targets .NET 10 and requires USFMToolsSharp 2.0 or later.

USFMToolsSharp 2.x parses a document into several hierarchies. The renderer walks the
default hierarchy (`USFMDocument.Hierarchies[0]`), which nests markers the same way the
1.x tree did.

# Building

```
dotnet build
dotnet test
```
