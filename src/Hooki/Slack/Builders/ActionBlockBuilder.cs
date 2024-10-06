using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class ActionBlockBuilder : BlockBaseBuilder
{
     private readonly List<IActionBlockElement> _elements = new();

     public ActionBlockBuilder AddElement<T>(Func<T> elementFactory) where T : IActionBlockElement
     {
          _elements.Add(elementFactory());
          return this;
     }
     
     public override ActionBlock Build()
     {
          if (_elements is null || _elements.Count == 0)
               throw new InvalidOperationException("Elements are required");
          
          return new ActionBlock
          {
               BlockId = base.Build().BlockId,
               Elements = _elements
          };
     }
}