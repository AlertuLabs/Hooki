using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class SlackHeaderBlockBuilder : ISlackBlockBuilder
{
    private SlackTextObject? _text;
    private string? _blockId;
    
    public SlackHeaderBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
    
    public SlackHeaderBlockBuilder WithText(SlackTextObject slackText)
    {
        _text = slackText;
        return this;
    }

    public SlackBlock Build()
    {
        if (_text is null)
            throw new InvalidOperationException("Text is required");
        
        return new SlackHeaderBlock
        {
            BlockId = _blockId,
            SlackText = _text
        };
    }
}