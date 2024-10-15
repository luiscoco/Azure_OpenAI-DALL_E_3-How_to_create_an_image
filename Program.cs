using Azure;
using Azure.AI.OpenAI;
using OpenAI.Images;
using System.ClientModel;
using static System.Environment;

var endpoint = new Uri("https://mydalleluiscoco.openai.azure.com/");
var credentials = new ApiKeyCredential("e37cd32e8d41409cafaa17471944f930");
var deploymentName = "dall-e-3";

var openAIClient = new AzureOpenAIClient(endpoint, credentials);

// Corrected deployment name
ImageClient chatClient = openAIClient.GetImageClient("dall-e-3");

var imageGeneration = await chatClient.GenerateImageAsync(
        "a BMW iX2 black",
        new ImageGenerationOptions()
        {
            Size = GeneratedImageSize.W1024xH1024
        }
    );

Console.WriteLine(imageGeneration.Value.ImageUri);
