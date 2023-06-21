using Telegram.Bot;
using Telegram.Bot.Polling;

public class BotBackgroundService : BackgroundService
{
    private readonly ILogger<BotBackgroundService> logger;
    private readonly ITelegramBotClient telegramBotClient;
    private readonly IUpdateHandler updateHandler;

    public BotBackgroundService(ILogger<BotBackgroundService> logger,
     TelegramBotClient telegramBotClient,
     IUpdateHandler updateHandler)
    {
        this.logger = logger;
        this.telegramBotClient = telegramBotClient;
        this.updateHandler = updateHandler;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var me = await telegramBotClient.GetMeAsync(stoppingToken);

        telegramBotClient.StartReceiving(
            updateHandler: updateHandler,
            receiverOptions: default,
            cancellationToken: stoppingToken
        );
    }
}
