using Hooki.Slack.Models;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class SlackWebhookPayloadBuilder
{
    private readonly List<SlackBlock> _blocks = new();

    public SlackWebhookPayloadBuilder AddActionBlock(Action<SlackActionBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddContextBlock(Action<SlackContextBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddDividerBlock(Action<SlackDividerBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddFileBlock(Action<SlackFileBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddHeaderBlock(Action<SlackHeaderBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddImageBlock(Action<SlackImageBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddInputBlock(Action<SlackInputBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddRichTextBlock(Action<SlackRichTextBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddSectionBlock(Action<SlackSectionBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddVideoBlock(Action<SlackVideoBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    private SlackWebhookPayloadBuilder AddBlock<T>(Action<T> buildAction) where T : ISlackBlockBuilder, new()
    {
        var builder = new T();
        buildAction(builder);
        _blocks.Add(builder.Build());
        return this;
    }

    public SlackWebhookPayload Build()
    {
        if (_blocks.Count == 0)
            throw new InvalidOperationException("At least one block is required.");

        return new SlackWebhookPayload
        {
            Blocks = _blocks
        };
    }
}