using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class ActionBlockBuilder : BlockBaseBuilder
{
     private List<IActionBlockElement>? _elements;

     public ActionBlock Build()
     {
          if (_elements is null)
               throw new InvalidOperationException("Elements are required");
          
          return new ActionBlock
          {
               BlockId = base.Build().BlockId,
               Elements = _elements
          };
     }
}