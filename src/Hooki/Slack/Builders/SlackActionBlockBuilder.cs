using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class SlackActionBlockBuilder : ISlackBlockBuilder
{
     private readonly List<ISlackActionBlockElement> _elements = new();
     private string? _blockId;
     
     public SlackActionBlockBuilder AddElement<T>(Func<T> elementFactory) where T : ISlackActionBlockElement
     {
          _elements.Add(elementFactory());
          return this;
     }
     
     public SlackActionBlockBuilder WithBlockId(string blockId)
     {
          _blockId = blockId;
          return this;
     }
     
     public SlackBlock Build()
     {
          if (_elements is null || _elements.Count == 0)
               throw new InvalidOperationException("Elements are required");
          
          return new SlackActionBlock
          {
               BlockId = _blockId,
               Elements = _elements
          };
     }
}