namespace FileEditorApp.Services;

public static class FileService
{
    public static void Open()
    {
        Console.Clear();
        Console.WriteLine("Digite o caminho do arquivo:");
        var path = Console.ReadLine()!;

        try
        {
            using var file = new StreamReader(path);
            var text = file.ReadToEnd();
            Console.WriteLine(text);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao abrir o arquivo: {ex.Message}");
        }

        Console.WriteLine("");
        Console.ReadLine();
    }

    public static void Edit()
    {
        Console.Clear();
        Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
        Console.WriteLine("----------------");
        var text = "";
        var shouldStop = false;
        
        do
        {
            var currentLine = Console.ReadLine() ?? string.Empty;
            if(currentLine.Contains('\u001b') || currentLine.Contains("ˆ[") || currentLine == "exit")
                shouldStop = true;
            else
            {
                text += currentLine;
                text += Environment.NewLine;
            }
        }
        while (!shouldStop);

        Save(text);
    }

    private static void Save(string text)
    {
        Console.Clear();
        Console.WriteLine("Digite o caminho para salvar o arquivo:");
        var path = Console.ReadLine()!;

        try
        {
            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo com sucesso em {path}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar o arquivo: {ex.Message}");
        }

        Console.ReadLine();
    }
}