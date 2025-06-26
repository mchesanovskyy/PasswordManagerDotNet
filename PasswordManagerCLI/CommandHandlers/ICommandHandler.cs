namespace PasswordManagerCLI.CommandHandlers;

internal interface ICommandHandler
{

}

internal interface ICommandHandler<TOptions> : ICommandHandler
{
    public void Process(TOptions options, LocalSessionContext sessionContext);
}