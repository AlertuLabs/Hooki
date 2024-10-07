using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class ActionBlockBuilder : IBlockBuilder
{
     private readonly List<IActionBlockElement> _elements = new();
     private string? _blockId;
     
     public ActionBlockBuilder AddElement<T>(Func<T> elementFactory) where T : IActionBlockElement
     {
          _elements.Add(elementFactory());
          return this;
     }
     
     public ActionBlockBuilder WithBlockId(string blockId)
     {
          _blockId = blockId;
          return this;
     }
     
     public BlockBase Build()
     {
          if (_elements is null || _elements.Count == 0)
               throw new InvalidOperationException("Elements are required");
          
          return new ActionBlock
          {
               BlockId = _blockId,
               Elements = _elements
          };
     }
}