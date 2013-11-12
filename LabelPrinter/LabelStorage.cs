using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LabelPrinter
{
    public class LabelStorage
    {
        public static void Save(string path, IList<Label> labels)
        {
            File.WriteAllLines(path, labels.Select(lts).ToArray());
        }

        public static IList<Label> Read(string path)
        {
            return File
                .ReadAllLines(path)
                .Aggregate(
                    new List<Label>(),
                    (acc, str) =>
                    {
                        if (str == "label"){
                            acc.Add(new Label());
                            return acc;
                        }
                        else
                        {
                            var trimmed = str.Trim();
                            if (string.IsNullOrEmpty(trimmed))
                                return acc;
                            int zip = 0;
                            var label = acc.Last();
                            if (int.TryParse(trimmed.Substring(0, 6), out zip))
                            {
                                label.PostalCode = zip;
                                var rest = trimmed
                                    .Split('|')
                                    .Select(x => x.Trim())
                                    .ToArray();
                                label.Address = rest[1];
                                label.City = rest[2];
                            }
                            else
                                label.Addressee = trimmed;
                            return acc;
                        }
                    });
        }

        private static string format =
@"label
  {0}
  {1}|{2}|{3}
";
        private static string lts(Label l)
        {
            return string.Format(format, l.Addressee, l.PostalCode, l.Address, l.City);
        }
    }
}
