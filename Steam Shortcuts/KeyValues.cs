using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam_Shortcuts
{
    static class KeyValues
    {
        private readonly static char[] whitespace = { ' ', '\n', '\r', '\t' };

        public static Dictionary<string, object> ReadFile(string path)
        {
            Dictionary<string, object> values = new Dictionary<string, object>();
            try
            {
                StreamReader reader = new StreamReader(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return new Dictionary<string, object>();
        }


        public static Dictionary<string, object> ParseValues(StreamReader reader, Dictionary<string, object> values)
        {
            char ch = (char)reader.Read();
            if (ch == '"')
            {
                string key = parseString(reader);

                do
                {
                    ch = (char)reader.Read();
                } while (whitespace.Contains(ch));

                if (ch == '"')
                {
                    values.Add(key, parseString(reader));
                }
                else if (ch == '{')
                {
                    values.Add(key, ParseValues(reader, new Dictionary<string, object>()));
                }
            }
            else if (ch == '}')
            {
                return values;
            }
            else throw new FileFormatException("Encountered unexpected character: " + ch);
            return values;
        }


        private static string parseString(StreamReader reader)
        {
            StringBuilder token = new StringBuilder();
            char ch = (char)reader.Read();

            while ((ch = (char)reader.Read()) != '"')
            {
                token.Append(ch);
            }
            return token.ToString();
        }

    }
}
