namespace DotNETwithGPT.Services
{
    public interface IOpenAiService
    {
        // simple interface to implement abstraction but you can skip that part and just implement it into openaiservice class
        Task<string> CompleteSentence(string text);
        Task<string> CompleteSentenceAdvanced(string text);
        Task<string> CheckProgramingLanguage(string language);
    }
}
