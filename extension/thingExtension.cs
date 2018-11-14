using System;
using System.Collections.Generic;
using System.Linq;
using catamorphism.models;

namespace catamorphism.extension {
    public static class ThingExtension {
        public static readonly IThing[] EMPTY_THING = new IThing[] { };
        public static TResult MapThing<TResult>(this IThing current, Func<Section, TResult> sectionFunc, Func<Subsection, TResult> subsectionFunc, Func<Clause, TResult> clauseFunc, Func<Subclause, TResult> subclauseFunc)
        {
            switch (current)
            {
                case Section section:  return sectionFunc(section);
                case Subsection subsection: return subsectionFunc(subsection);
                case Clause clause: return clauseFunc(clause);
                case Subclause subclause: return subclauseFunc(subclause);
                default:
                    throw new Exception("Should Never Happen!");
            }
        }

        public static IEnumerable<IThing> GetChildren(this IThing thing) =>
            thing.MapThing(
                s => s.Subsections as IEnumerable<IThing>,
                ss => ss.Clauses as IEnumerable<IThing>,
                c => c.Subclauses as IEnumerable<IThing>,
                sc => EMPTY_THING
            );

        public static string ToPrettyString(this IThing thing) =>
            thing.MapThing(
                s => $"{s.Title} ({s.Subsections.Length.ToString()})",
                ss => $"{ss.Title} ({ss.Clauses.Length.ToString()})",
                c => $"{c.Title} ({c.Subclauses.Length.ToString()})",
                sc => $"{sc.Title}"
            );

        public static IEnumerable<IThing> Flatten(this IEnumerable<IThing> things) =>
            things.Aggregate(
                things,
                (prev, curr) =>
                    prev.Union(curr.GetChildren().Flatten()));
    }
}
