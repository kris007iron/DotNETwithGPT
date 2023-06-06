namespace OpenAIApp.Services
{
    public interface IOpenAiService
    {
        Task<string> CompleteSentence(string text);
    }
}
