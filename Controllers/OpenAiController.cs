using DotNETwithGPT.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNETwithGPT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAiController : ControllerBase
    {
        private readonly ILogger<OpenAiController> _logger;
        private readonly IOpenAiService _openAiService;

        public OpenAiController(ILogger<OpenAiController> logger, IOpenAiService openAiService)
        {
            _logger = logger;
            _openAiService = openAiService;
        }

        // Endpoint for completing a sentence using the OpenAI GPT model
        [HttpPost]
        [Route("CompleteSentence")]
        public async Task<IActionResult> CompleteSentence(string text)
        {
            var result = await _openAiService.CompleteSentence(text);
            return Ok(result);
        }

        // Endpoint for advanced sentence completion using the OpenAI GPT model
        [HttpPost]
        [Route("CompleteSentenceAdvanced")]
        public async Task<IActionResult> CompleteSentenceAdvanced(string text)
        {
            var result = await _openAiService.CompleteSentenceAdvanced(text);
            return Ok(result);
        }

        // Endpoint for asking a question about a programming language using the OpenAI GPT model
        [HttpPost]
        [Route("AskQuestion")]
        public async Task<IActionResult> AskQuestion(string language)
        {
            var result = await _openAiService.CheckProgramingLanguage(language);
            return Ok(result);
        }
    }
}
