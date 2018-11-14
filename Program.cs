using System;
using System.Collections.Generic;
using System.Linq;
using catamorphism.extension;
using catamorphism.models;

namespace catamorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var testSet = BuildTestSet();

            Console.WriteLine("Got test set");
            Console.WriteLine(testSet.Count());

            var flattened = testSet.Flatten();

            Console.WriteLine("Flattened");
            Console.WriteLine(flattened.Count());

            foreach (var x in flattened) {
                Console.WriteLine(x.Title);
            }

            foreach (var x in flattened) {
                Console.WriteLine(x.ToPrettyString());
            }

            var logstuff = flattened.Aggregate(
                "",
                (prev, curr) => prev + curr.ToPrettyString() + "\r\n");

            Console.WriteLine(logstuff);
        }

        static IEnumerable<Section> BuildTestSet() {
            return new Section[] {
                new Section {
                    Title = "Section 1",
                    Subsections = new Subsection[] {
                        new Subsection {
                            Title = "Subsection 1.1"
                        },
                        new Subsection {
                            Title = "Subsection 1.2",
                            Clauses = new Clause[] {
                                new Clause {
                                    Title = "Clause 1.2.1"
                                },
                                new Clause {
                                    Title = "Clause 1.2.2"
                                },
                                new Clause {
                                    Title = "Clause 1.2.3",
                                    Subclauses = new Subclause[] {
                                        new Subclause { Title = "Subclause 1.2.3.1" },
                                        new Subclause { Title = "Subclause 1.2.3.2" },
                                        new Subclause { Title = "Subclause 1.2.3.3" },
                                        new Subclause { Title = "Subclause 1.2.3.4" },
                                        new Subclause { Title = "Subclause 1.2.3.5" }
                                    }
                                }
                            }
                        },
                        new Subsection {
                            Title = "Subsection 1.3"
                        }
                    }
                },
                new Section { Title = "Section 2"
                },
            };
        }
    }
}
