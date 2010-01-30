using System;
using System.Collections.Generic;
using System.Text;

namespace Amaranth.Util
{
    public static class Text
    {
        public static string[] CharacterWrap(string text, int lineWidth)
        {
            List<string> lines = new List<string>();

            while (text.Length > lineWidth)
            {
                lines.Add(text.Substring(0, lineWidth));
                text = text.Substring(lineWidth);
            }

            if (text.Length > 0)
            {
                lines.Add(text);
            }

            return lines.ToArray();
        }

        public static string[] WordWrap(string text, int lineWidth)
        {
            List<string> lines = new List<string>();

            string line;

            int lastWrapPoint = 0;
            int thisLineStart = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == ' ')
                {
                    lastWrapPoint = i;
                }

                // wrap if we got too long
                if (i - thisLineStart >= lineWidth)
                {
                    if (lastWrapPoint != 0)
                    {
                        // have a recent point to wrap at, so word wrap
                        line = text.Substring(thisLineStart, lastWrapPoint - thisLineStart);
                        thisLineStart = lastWrapPoint;
                    }
                    else
                    {
                        // no convenient point to word wrap, so character wrap
                        line = text.Substring(thisLineStart, i - thisLineStart);
                        thisLineStart = i;
                    }

                    line = line.Trim();
                    lines.Add(line);
                }
            }

            // add the last bit
            line = text.Substring(thisLineStart);
            line = line.Trim();
            lines.Add(line);

            return lines.ToArray();
        }
    }
}
