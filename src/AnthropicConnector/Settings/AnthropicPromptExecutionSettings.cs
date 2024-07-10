using System.Collections.ObjectModel;

using AnthropicClient.Models;

using Microsoft.SemanticKernel;

/// <summary>
/// The settings for executing a prompt with the Anthropic API.
/// </summary>
public class AnthropicPromptExecutionSettings : PromptExecutionSettings
{
  private int _maxTokens = 1024;
  private string? _system = null;
  private IDictionary<string, object>? _metadata;
  private IList<string> _stopSequences = [];
  private decimal _temperature = 0.0m;
  private int? _topK = null;
  private decimal? _topP = null;
  private ToolChoice? _toolChoice = null;

  /// <summary>
  /// The maximum number of tokens to generate.
  /// </summary>
  public int MaxTokens 
  { 
    get => _maxTokens;
    set
    {
      ThrowIfFrozen();
      _maxTokens = value;
    } 
  }

  /// <summary>
  /// The system prompt to use
  /// </summary>
  public string? System
  {
    get => _system;
    set
    {
      ThrowIfFrozen();
      _system = value;
    }
  }

  /// <summary>
  /// Gets the metadata to include
  /// </summary>
  public IDictionary<string, object>? Metadata 
  {
    get => _metadata;
    set
    {
      ThrowIfFrozen();
      _metadata = value;
    } 
  }

  /// <summary>
  /// The prompt stop sequences.
  /// </summary>
  public IList<string> StopSequences
  {
    get => _stopSequences;
    set
    {
      ThrowIfFrozen();
      _stopSequences = value;
    }
  }

  /// <summary>
  /// The temperature to use
  /// </summary>
  public decimal Temperature
  {
    get => _temperature;
    set
    {
      ThrowIfFrozen();
      _temperature = value;
    }
  }

  /// <summary>
  /// The top K value to use
  /// </summary>
  public int? TopK
  {
    get => _topK;
    set
    {
      ThrowIfFrozen();
      _topK = value;
    }
  }

  /// <summary>
  /// The top P value to use
  /// </summary>
  public decimal?
  TopP
  {
    get => _topP;
    set
    {
      ThrowIfFrozen();
      _topP = value;
    }
  }

  /// <summary>
  /// The tool choice mode to use
  /// </summary>
  public ToolChoice? ToolChoice
  {
    get => _toolChoice;
    set
    {
      ThrowIfFrozen();
      _toolChoice = value;
    }
  }

  /// <inheritdoc />
  public override void Freeze()
  {
    if (IsFrozen)
    {
      return;
    }

    base.Freeze();

    if (_stopSequences is not null)
    {
      _stopSequences = new ReadOnlyCollection<string>(_stopSequences);
    }

    if (_metadata is not null)
    {
      _metadata = new ReadOnlyDictionary<string, object>(_metadata);
    }
  }

  /// <inheritdoc />
  public override PromptExecutionSettings Clone()
  {
    return new AnthropicPromptExecutionSettings
    {
      MaxTokens = MaxTokens,
      System = System,
      Metadata = Metadata is not null ? new Dictionary<string, object>(Metadata) : null,
      StopSequences = new List<string>(StopSequences),
      Temperature = Temperature,
      TopK = TopK,
      TopP = TopP,
      ToolChoice = ToolChoice
    };
  }
}