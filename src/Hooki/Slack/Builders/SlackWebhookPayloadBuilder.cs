using Hooki.Slack.Models;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class SlackWebhookPayloadBuilder
{
    private readonly List<BlockBase> _blocks = new();

    public SlackWebhookPayloadBuilder AddActionBlock(Action<ActionBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddContextBlock(Action<ContextBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddDividerBlock(Action<DividerBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddFileBlock(Action<FileBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddHeaderBlock(Action<HeaderBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddImageBlock(Action<ImageBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddInputBlock(Action<InputBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddRichTextBlock(Action<RichTextBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddSectionBlock(Action<SectionBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    public SlackWebhookPayloadBuilder AddVideoBlock(Action<VideoBlockBuilder> buildAction)
    {
        return AddBlock(buildAction);
    }

    private SlackWebhookPayloadBuilder AddBlock<T>(Action<T> buildAction) where T : IBlockBuilder, new()
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