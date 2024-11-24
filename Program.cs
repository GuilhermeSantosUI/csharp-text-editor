using FileEditorApp.Services;

int option;

do
{
    Console.WriteLine("O que você deseja fazer?");
    Console.WriteLine("1 - Abrir arquivo");
    Console.WriteLine("2 - Criar novo arquivo");
    Console.WriteLine("0 - Sair");

    option = short.Parse(Console.ReadLine()!);

    switch (option)
    {
        case 0:
            Console.WriteLine("Aplicação encerrada.");
            break;
        
        case 1:
            FileService.Open();
            break;

        case 2:
            FileService.Edit();
            break;

        default:
            Console.WriteLine("Opção inválida! Tente novamente.");
            break;
    }
} while (option != 0);