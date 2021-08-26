using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcaoUsuario;
            int indice = 0;
            Aluno[] alunos = new Aluno[5];

            do
            {
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1- Inserir novo aluno");
                Console.WriteLine("2- Listar alunos");
                Console.WriteLine("3- Calcular média geral");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                opcaoUsuario =  Console.ReadLine();
                Console.WriteLine();


                switch (opcaoUsuario.ToUpper())
                {
                    case "1":
                        if(indice < 4)
                        {
                            Aluno aluno = new Aluno();

                            Console.WriteLine("Informe o nome do aluno:");
                            aluno.nome =  Console.ReadLine();

                            Console.WriteLine("Informe a nota do aluno:");
                            if(decimal.TryParse(Console.ReadLine(),out decimal nota))
                            {
                                aluno.nota = nota;
                            }
                            else
                            {
                                throw new ArgumentException("Valor da nota deve ser decimal");
                            }
                            
                            alunos[indice] = aluno;
                            indice++;
                        }
                        else
                        {
                            throw new IndexOutOfRangeException("O limite de alunos cadastrados foi execedido");
                        }
                        break;

                    case "2":
                        foreach (var aluno in alunos)
                        {
                            if(!string.IsNullOrEmpty(aluno.nome))
                                Console.WriteLine($"Aluno: {aluno.nome} -- Nota: {aluno.nota}");
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        decimal notaMedia= 0;
                        decimal cont = 0;
                        foreach (var aluno in alunos)
                        {
                            if(!string.IsNullOrEmpty(aluno.nome))
                            {
                                notaMedia = (notaMedia+aluno.nota);
                                cont++;
                            }

                        }
                        notaMedia = notaMedia/cont;

                        ConceitoEnum conceitogeral;
                        if(notaMedia < 2)
                        {
                             conceitogeral = ConceitoEnum.E;
                        }
                        else if(notaMedia < 4)
                        {
                            conceitogeral = ConceitoEnum.D;
                        }
                        else if(notaMedia < 6)
                        {
                            conceitogeral = ConceitoEnum.C;
                        }
                        else if(notaMedia < 8)
                        {
                            conceitogeral = ConceitoEnum.B;
                        }
                        else
                        {
                            conceitogeral = ConceitoEnum.A;
                        }
                        

                        Console.WriteLine($"A média dos alunos é: {notaMedia} e o Conceito: {conceitogeral}");
                        Console.WriteLine();
                        break;

                    case "X":
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }
            } while (opcaoUsuario.ToUpper() != "X");


        }
    }
}
