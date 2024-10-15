# How to create an Image with Azure OpenAI DALL-E

**Note:** for more information about this sample see the official Microsoft web page

https://learn.microsoft.com/en-us/azure/ai-services/openai/dall-e-quickstart

This C# code interacts with the **Azure OpenAI** service to generate an image using the **DALL·E 3** model

The application makes use of the **Azure SDK for .NET** to connect to the service and requests an image to be generated based on a text prompt

## 1. Setting up the Azure OpenAI service with a DALL-E model

We login in Azure Portal and select the Azure OpenAI service

![image](https://github.com/user-attachments/assets/0d6b477a-1b8b-4426-ab69-0e12971ddc63)

We press in the Create button

![image](https://github.com/user-attachments/assets/04102886-7a19-4f83-b3db-b27f035b4cfd)

We input the Azure Open AI service definition data and press the Next button and finally the Create button

![image](https://github.com/user-attachments/assets/4f9ce363-8927-44c8-8801-336c9917ab74)

![image](https://github.com/user-attachments/assets/f5cd1878-5572-480e-bd2e-9ee09094f0f1)

![image](https://github.com/user-attachments/assets/85d8c955-859b-4fe1-970f-4ce7d9a635df)

![image](https://github.com/user-attachments/assets/c845f026-337e-40f6-9a4b-7cc816dd0255)

We verify the service was created

![image](https://github.com/user-attachments/assets/7c5de2f4-b9db-4a43-a127-920d0f2758d9)

![image](https://github.com/user-attachments/assets/4ac96bf4-6955-4d17-b219-0eabb836c4fc)

Now we create a AI model deployment

![image](https://github.com/user-attachments/assets/709b1852-1853-4ace-a3db-206755442482)

![image](https://github.com/user-attachments/assets/41fc8f1c-2131-4564-b5de-6ba9d5b6d471)

![image](https://github.com/user-attachments/assets/9c9aa7ca-dcaa-44c4-a17b-4c8d1c4c22ab)

![image](https://github.com/user-attachments/assets/1e440377-c4b8-4104-a28e-7e7a4b4d1e30)

![image](https://github.com/user-attachments/assets/a517ce40-6282-4016-811a-bc1b90d9999e)

![image](https://github.com/user-attachments/assets/8a9202dc-cf5d-489a-ad33-f9523906c90b)

## 2. Create a C# console (.NET9) application with Visual Studio 2022 Community Edition

We run Visual Studio 2022 and we create a new project

![image](https://github.com/user-attachments/assets/0a1a3adf-2ecf-47da-8f73-182cf71c15c4)

We select the C# console application as the project template and press the next button

![image](https://github.com/user-attachments/assets/e86e936a-2c7f-48c9-938d-63f9135a5e6e)

We input the project name and location in the hard disk

We select the .NET 9 framework and press the Create button

![image](https://github.com/user-attachments/assets/13705d3f-f356-42bb-96aa-93a0cb5c0667)

## 3. We load the Azure Open AI Nuget pakcakes

![image](https://github.com/user-attachments/assets/5ad58671-dfb2-4964-aaf9-48a5541c97b0)

## 4. We enter the application source code

The code uses Azure's **DALL·E 3** model to generate an image based on a text description

In this case, it generates an image of a "**BMW iX2 black**" and outputs the URL where the generated image can be accessed

**Setting up the Azure OpenAI client**:

The endpoint is the URL where the **DALL·E** model is hosted on Azure

**credentials** uses an API key (**ApiKeyCredential**) to authenticate the application to the **Azure OpenAI** service

**deploymentName** specifies the name of the deployed DALL·E model (in this case, "**dall-e-3**")

**Initializing the OpenAI client**:

The **AzureOpenAIClient** object is created using the endpoint and credentials, allowing communication with the Azure OpenAI service

**Accessing the DALL·E model**:

The **ImageClient** is retrieved from the OpenAI client using the model's deployment name (dall-e-3). This client is responsible for handling image generation task

**Generating an image**:

The **GenerateImageAsync()** method is called to request an image generation. The input prompt is "a BMW iX2 black", specifying the image the user wants to generate

The image generation options specify the size of the image as 1024x1024 pixels (GeneratedImageSize.W1024xH1024)

**Output the generated image URL**:

The method returns an image generation result, and the **URI (URL)** of the generated image is printed to the console using **Console.WriteLine()**

See the application source code:

```csharp
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
```

## 5. We run the application

After running the application in Visual Studio we get this output

![image](https://github.com/user-attachments/assets/3eebb002-be5a-4cbb-81e2-4071d4dd1bb8)

We can press Ctrl+Click on the hyperlink and the image will be opened in a new internet browser tab

![image](https://github.com/user-attachments/assets/fa9ebf86-158d-4c61-b9f8-b40043301783)
