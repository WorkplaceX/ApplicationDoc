# Markdown Parser (Feature)

The framework comes with a markdown (*.md) text parser. It contains a superset of: https://www.markdownguide.org/basic-syntax/

Additionally the parser supports custom syntax elements such as:
* (Note) to display a yellow note.
* (Youtube) to display a youtube film.

## Markdown to Html
Markdown 
(*.md) text can be transformed into 
(*.html) with the following function:
```csharp
string html = UtilFramework.TextMdToHtml(textMd);
```
## List of Supported Markdown Syntax Elements
The following syntax elements are parsed interpreted:
```txt
Header
    # Title Level 1
    ## Title Level 2

Font Bold
    **Bold**

Font Italic
    *Italic*

Bullet
    * Bullet 1
    * Bullet 2

Image
    ![Description](/assets/my.png)

Hyperlink
    [Description](https://www.workplacex.org)
    https://www.workplacex.org
    
Code 
    ` ` `csharp (Without spaces!)
    int a = 0;   
    ` ` `

Note (Custom Syntax)
    (Note)
    Text shown in a yellow note.
    (Note)

Youtube (Custom Syntax)
    (Youtube Link="https://www.youtube.com/embed/ORDp3uNPrSY")
```

# Custom Syntax Elements
It's possible to further extend the md syntax parser and define new custom elements. All source code of lexer and syntax parser is in file: Framework/Framework/UtilDoc.cs