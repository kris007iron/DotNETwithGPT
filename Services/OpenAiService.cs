using Microsoft.Extensions.Options;
using OpenAIApp.Configurations;

namespace OpenAIApp.Services
{
    public class OpenAiService : IOpenAiService
    {
        private readonly OpenAiConfig _openAiConfig;
        public OpenAiService(IOptionsMonitor<OpenAiConfig> optionsMonitor) 
        {
            _openAiConfig = optionsMonitor.CurrentValue;
        }

        public async Task<string> CompleteSentence(string text) 
        {
            //api instance
            var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
            var result = await api.Completions.GetCompletion(text);
            return result;
        }
    }
}
