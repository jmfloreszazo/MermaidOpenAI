# Research Project: Azure AI Open AI Semantic Kernel

This research project focuses on the Semantic Kernel of OpenAI implemented in Azure AI. The main goal is to explore and understand how artificial intelligence can enhance semantics and natural language processing. This study also aims to discover new ways to integrate and utilize these technologies in various applications and services.

## Technologies

This project is built with the following technologies:

- C#: A modern, object-oriented programming language developed by Microsoft.
- .NET: A free, cross-platform, open-source developer platform for building many different types of applications.
- Microsoft.Extensions.Configuration: A library in .NET for handling application configuration.
- Microsoft.SemanticKernel: A custom library for semantic processing tasks.
- Microsoft.SemanticKernel.Orchestration: A custom library for orchestrating semantic processing tasks.
- Azure: Microsoft's cloud platform. Used in this project for the Azure Chat Completion Service.
- Mermaid: A JavaScript library for generating diagrams and flowcharts from text in a syntax similar to markdown.

## How to use

1. Clone the repository: `git clone URL_OF_THE_REPOSITORY`
2. Navigate to the project directory: `cd DIRECTORY_NAME`
3. Install the dependencies: `dotnet restore`
4. Edit the configuration file: `appsettings.json` with your OpenAI deployment name, endpoint, and API key to properly configure the connection to the OpenAI service.
5. Run the project: `dotnet run`

## Output

This project generates a markdown file named ResearchOutput.md which contains a detailed research report based on a given topic and questions, including a flowchart in Mermaid format.