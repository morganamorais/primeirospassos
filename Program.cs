using System;

namespace Revisao
{
    class Program
    {
        static  void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObteropcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case"1":
                       Console.WriteLine("Informe o nome do aluno:");
                       var aluno = new Aluno();                       
                       aluno.Nome = Console.ReadLine();

                        Console.WriteLine();

                       Console.WriteLine("Informe a nota do aluno:");
                                         

                       if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                       {
                           aluno.Nota = nota;
                       }
                       else
                       {
                           throw new ArgumentException("Valor da nota deve ser decimal");
                       }
                               //22:30                                    

                         alunos[indiceAluno] = aluno;
                         indiceAluno++; 

                        break;
                    case "2":
                        foreach(var alu in alunos)
                        {
                            if (!string.IsNullOrEmpty(alu.Nome))
                            Console.WriteLine($"ALUNO: {alu.Nome} - NOTA: {alu.Nota}");
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for(int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                               notaTotal = notaTotal + alunos[i].Nota;
                               nrAlunos++; 
                            }
                        }
                        var mediaGeral = notaTotal / nrAlunos;
                        ConceitoEnum conceitoGeral;

                        if( mediaGeral < 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                        }
                        else
                        {
                            conceitoGeral = ConceitoEnum.A;
                        } 
                        Console.WriteLine($"MÉDIA GERAL {mediaGeral} - CONCEITO: {conceitoGeral}");

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                    opcaoUsuario = ObteropcaoUsuario();

            }
        }

               private static string ObteropcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo Aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("x- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}