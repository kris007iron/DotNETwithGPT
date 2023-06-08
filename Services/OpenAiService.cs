using DotNETwithGPT.Configurations;
using Microsoft.Extensions.Options;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace DotNETwithGPT.Services
{
    public class OpenAiService : IOpenAiService
    {
        private readonly OpenAiConfig _config;

        public OpenAiService(IOptionsMonitor<OpenAiConfig> optionsMonitor) 
        {
            _config = optionsMonitor.CurrentValue;
        }
        
        public async Task<string> CheckProgramingLanguage(string language)
        {
            var api = new OpenAI_API.OpenAIAPI(_config.Key);

            var chat = api.Chat.CreateConversation();
            // configuration of answers 
            chat.AppendSystemMessage("You are a teacher who help new programmers understand things are programming language or not. If the user tells you a programming language respond with yes, if a user tells you something which is not a programming language respond with no. you will only respond with yes or no. you do not say anything else.");

            chat.AppendUserInput(language);

            var response = await chat.GetResponseFromChatbotAsync();

            return response;
        }

        public async Task<string> CompleteSentence(string text)
        {
            // api instance with simple answers like input one two and answer three ...
            var api = new OpenAI_API.OpenAIAPI(_config.Key);
            var result = await api.Completions.GetCompletion(text);
            return result;
        }

        public async Task<string> CompleteSentenceAdvanced(string text)
        {
            // api instance with model where temperature means how broadly will text model answer where small values mean keeping close to topic and 1.0 means that model have the most freedom in answer
            var api = new OpenAI_API.OpenAIAPI(_config.Key);
            var result = await api.Completions.CreateCompletionAsync(new CompletionRequest(text, model:Model.CurieText, temperature: 0.1));
            return result.Completions[0].Text;
        }
    }
}
