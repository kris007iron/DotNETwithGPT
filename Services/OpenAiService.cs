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

        // Method to check if the given input is a programming language or not
        public async Task<string> CheckProgramingLanguage(string language)
        {
            var api = new OpenAI_API.OpenAIAPI(_config.Key);

            var chat = api.Chat.CreateConversation();
            // Configure the conversation with system message and user input
            chat.AppendSystemMessage("You are a teacher who helps new programmers understand what things are programming languages or not. If the user tells you a programming language, respond with 'yes'. If the user tells you something which is not a programming language, respond with 'no'. You will only respond with 'yes' or 'no'; do not say anything else.");

            chat.AppendUserInput(language);

            // Get the response from the chatbot
            var response = await chat.GetResponseFromChatbotAsync();

            return response;
        }

        // Method to complete a sentence using the OpenAI GPT model
        public async Task<string> CompleteSentence(string text)
        {
            // Create an API instance for simple text completion
            var api = new OpenAI_API.OpenAIAPI(_config.Key);
            var result = await api.Completions.GetCompletion(text);
            return result;
        }

        // Method to advanced sentence completion using the OpenAI GPT model
        public async Task<string> CompleteSentenceAdvanced(string text)
        {
            // Create an API instance with a model that provides more freedom in the answer
            var api = new OpenAI_API.OpenAIAPI(_config.Key);
            var result = await api.Completions.CreateCompletionAsync(new CompletionRequest(text, model: Model.CurieText, temperature: 0.1));
            return result.Completions[0].Text;
        }
    }
}
