
using AnthropicClient;

using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace AnthropicConnector.Services;

/// <summary>
/// A chat completion service that uses the Anthropic API to provide completions.
/// </summary>
public class AnthropicChatCompletionService : IChatCompletionService
{
  private readonly Dictionary<string, object?> _attributes = [];
  private readonly string _apiKey;
  private readonly HttpClient _httpClient;
  private IAnthropicApiClient AnthropicClient => new AnthropicApiClient(_apiKey, _httpClient);

  /// <summary>
  /// Initializes a new instance of the <see cref="AnthropicChatCompletionService"/> class.
  /// </summary>
  public AnthropicChatCompletionService(
    string apiKey,
    HttpClient httpClient
  )
  {
    _apiKey = apiKey;
    _httpClient = httpClient;
  }

  /// <inheritdoc />
  public IReadOnlyDictionary<string, object?> Attributes => _attributes;


  /// <inheritdoc />
  public Task<IReadOnlyList<ChatMessageContent>> GetChatMessageContentsAsync(
    ChatHistory chatHistory, 
    PromptExecutionSettings? executionSettings = null, 
    Kernel? kernel = null, 
    CancellationToken cancellationToken = default
  )
  {
    throw new NotImplementedException();
  }

  /// <inheritdoc />
  public IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContentsAsync(
    ChatHistory chatHistory, 
    PromptExecutionSettings? executionSettings,
    Kernel? kernel = null,
    CancellationToken cancellationToken = default
  )
  {
    throw new NotImplementedException();
  }
}