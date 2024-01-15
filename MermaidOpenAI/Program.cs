using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Orchestration;

namespace MermaidOpenAI;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .Build();

        var kernel = Kernel.Builder
            .WithAzureChatCompletionService(
                config.GetSection("DeploymentName").Value,
                config.GetSection("Endpoint").Value,
                config.GetSection("apiKey").Value
            )
            .Build();

        // Hacer galletas de gengibre para Navidad

        Console.Write("Tema: ");

        var topic = Console.ReadLine();

        // ¿En que pais es más tradicional?, ¿qué variantes existen por paises?, ¿de qué tradiciones proviene?

        Console.Write("Añade cuestiones a considerar, separalo con comas, pero ten en cuenta que como máximo usaré 5: ");

        var questions = Console.ReadLine();

        var plugin = kernel.ImportSemanticSkillFromDirectory("Plugins", "WriteGraph");

        var variables = new ContextVariables();

        var markdownContent = "# Tema Original planteado por el cliente\n\n" +
                              @topic + "\n\n";
        markdownContent += "# Cuestiones planteadas por el cliente\n\n" +
                              @questions + "\n\n";

        variables.Set("topic", topic);
        variables.Set("questions", questions);

        var researchPrompt = await kernel.RunAsync(variables, plugin["Step1_ResearchPrompt"]);

        var research = researchPrompt.ToString();

        markdownContent += "# Paso 1 - Prompt de Investigación\n\n" +
                           research + "\n\n";

        variables.Set("flowchart", research);

        var mermaidOutput = await kernel.RunAsync(variables, plugin["Step2_MermaidOutput"]);

        markdownContent += "# Paso 2 - Gráfico en formato \n\n" +
                           @mermaidOutput.ToString() + "\n\n";

        var outputFile = "ResearchOutput.md";

        File.WriteAllText(outputFile, markdownContent);

        Console.WriteLine("Investigación finalizada, puede leer el archivo markdown que se ha creado.");
    }
}