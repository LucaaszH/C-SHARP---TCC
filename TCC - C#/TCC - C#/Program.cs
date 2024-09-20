using System;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        int[] vet = new int[8];

        Console.Clear();
        Texto1();
        Texto2();
        Vet(vet);
        Jump();

        Console.WriteLine("Automático: 1 ");
        Console.WriteLine("Manual: 0 ");
        Console.WriteLine(" ");
        Console.Write("Selecione o tipo de comando: ");

        int AM = int.Parse(Console.ReadLine());

        if (AM == 0)
        {

            Console.Clear();
            Texto1();
            Texto2();
            Vet(vet);
            Jump();

            Console.Write("Qual a sitação do Sistema: "); int S = int.Parse(Console.ReadLine());
            if (S == 1)
            {
                vet[0] = 1; Console.Clear();
            }
            else if (S == 0)
            {
                Console.Clear();
                Console.WriteLine("STOP! Sistema desligado!");
                Environment.Exit(0);
            }
            if ((S < 0) || (S > 1))
            {
                Console.Clear();
                vet[0] = S; Texto1(); Texto2(); Vet(vet); Jump();
                do
                {
                    Console.Write("Qual a sitação do Sistema: "); int T = int.Parse(Console.ReadLine());
                    Console.Clear();
                    vet[0] = T; Texto1(); Texto2(); Vet(vet); Jump();
                    if (T == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("STOP! Sistema desligado!");
                        Environment.Exit(0);
                    }
                    else if (T == 1)
                    {
                        vet[0] = 1; Console.Clear();
                        break;
                    }

                } while ((S != 1) || (S != 0));
            }

            while (S == 1)
            {
                Console.Clear();
                Texto1(); Texto2(); Vet(vet);
                Jump();
                Console.Write("Nível Baixo: "); int NB = int.Parse(Console.ReadLine());
                vet[1] = NB; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.Write("Nível Alto: "); int NA = int.Parse(Console.ReadLine());
                vet[2] = NA; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();

                while ((NA != 1 && NB != 0) || (NA != 0 && NB != 1))
                {
                    Console.WriteLine("STOP! Corrija o defeito e tente novamente!");
                    Console.Clear(); ClearVet(vet); vet[7] = 1; Texto1(); Texto2(); Vet(vet); Jump();
                    Console.Write("Nível Baixo: "); int NB2 = int.Parse(Console.ReadLine());
                    vet[1] = NB2; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.Write("Nível Alto: "); int NA2 = int.Parse(Console.ReadLine());
                    vet[2] = NA2; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();

                    if (NA2 == 0 && NB2 == 0)
                    {
                        Console.Clear(); vet[7] = 0; vet[0] = 1; Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Aguarde a ativação da valvula de fluido quente! (Observe o atuador F_H) (5s)");
                        Thread.Sleep(5000);
                        vet[4] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Aguarde o enchimento parcial da caldeira com fluido quente! (Observe o sensor N / B) (10s)");
                        Thread.Sleep(10000);
                        vet[1] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Aguarde a ativação da valvula de fluido frio! (Observe o atuador F_C) (5s)");
                        Thread.Sleep(5000);
                        vet[3] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Aguarde o enchimento da caldeira com fluido quente e frio! (Observe o atuador F_C) (15s)");
                        Thread.Sleep(15000);
                        vet[3] = 0; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Aguarde o termino do enchimento da caldeira com fluido quente! (10s) (Observe o atuador F_H e o sensor N / A)");
                        Thread.Sleep(10000);
                        vet[4] = 0; vet[2] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Aguarde a ativação do Agitador! (Observe o atuador AGITD) (5s)");
                        Thread.Sleep(5000);
                        vet[5] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("AGUARDE: Agitador ativo! (15s)");
                        Thread.Sleep(15000);
                        Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Aguarde a ativação da Bomba e desativação do Agitador! (Observe os atuadores AGITD e BOMBA) (5s)");
                        Thread.Sleep(5000);
                        vet[5] = 0; vet[6] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("AGUARDE: Esvaziamento do tanque! (Observe o sensor N / A) (10s)");
                        Thread.Sleep(10000);
                        vet[2] = 0; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("AGUARDE: Esvaziamento do tanque! (Observe o sensor N / B e o atuador BOMBA) (20s)");
                        Thread.Sleep(20000);
                        ClearVet(vet); Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Processo completo: Sistema ATIVO, pronto para setar novamente!");
                        goto Sair;
                    }

                    else if (NA2 == 1 && NB2 == 1)
                    {
                        vet[1] = 1; vet[2] = 1; vet[7] = 0; vet[0] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Caldeira completamente cheia! (AGUARDE: 2s)");
                        Thread.Sleep(2000);
                        Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        vet[4] = 0; vet[2] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Aguarde a ativação do Agitador! (Observe o atuador AGITD) (5s)");
                        Thread.Sleep(5000);
                        vet[5] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("AGUARDE: Agitador ativo! (15s)");
                        Thread.Sleep(15000);
                        Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Aguarde a ativação da Bomba e desativação do Agitador! (Observe os atuadores AGITD e BOMBA) (5s)");
                        Thread.Sleep(5000);
                        vet[5] = 0; vet[6] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("AGUARDE: Esvaziamento do tanque! (Observe o sensor N / A) (10s)");
                        Thread.Sleep(10000);
                        vet[2] = 0; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("AGUARDE: Esvaziamento do tanque! (Observe o sensor N / B e o atuador BOMBA) (20s)");
                        Thread.Sleep(20000);
                        ClearVet(vet); Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                        Console.WriteLine("Processo completo: Sistema ATIVO, pronto para setar novamente!");
                        goto Sair;
                    }
                }
                if (NA == 0 && NB == 0)
                {
                    Console.Clear(); vet[7] = 0; vet[0] = 1; Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Aguarde a ativação da valvula de fluido quente! (Observe o atuador F_H) (5s)");
                    Thread.Sleep(5000);
                    vet[4] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Aguarde o enchimento parcial da caldeira com fluido quente! (Observe o sensor N / B) (10s)");
                    Thread.Sleep(10000);
                    vet[1] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Aguarde a ativação da valvula de fluido frio! (Observe o atuador F_C) (5s)");
                    Thread.Sleep(5000);
                    vet[3] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Aguarde o enchimento da caldeira com fluido quente e frio! (Observe o atuador F_C) (15s)");
                    Thread.Sleep(15000);
                    vet[3] = 0; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Aguarde o termino do enchimento da caldeira com fluido quente! (10s) (Observe o atuador F_H e o sensor N / A)");
                    Thread.Sleep(10000);
                    vet[4] = 0; vet[2] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Aguarde a ativação do Agitador! (Observe o atuador AGITD) (5s)");
                    Thread.Sleep(5000);
                    vet[5] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("AGUARDE: Agitador ativo! (15s)");
                    Thread.Sleep(15000);
                    Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Aguarde a ativação da Bomba e desativação do Agitador! (Observe os atuadores AGITD e BOMBA) (5s)");
                    Thread.Sleep(5000);
                    vet[5] = 0; vet[6] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("AGUARDE: Esvaziamento do tanque! (Observe o sensor N / A) (10s)");
                    Thread.Sleep(10000);
                    vet[2] = 0; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("AGUARDE: Esvaziamento do tanque! (Observe o sensor N / B e o atuador BOMBA) (20s)");
                    Thread.Sleep(20000);
                    ClearVet(vet); Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Processo completo: Sistema ATIVO, pronto para setar novamente!");
                }

                else if (NA == 1 && NB == 1)
                {
                    vet[1] = 1; vet[2] = 1; vet[7] = 0; vet[0] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Caldeira completamente cheia! (AGUARDE: 2s)");
                    Thread.Sleep(2000);
                    Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    vet[4] = 0; vet[2] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Aguarde a ativação do Agitador! (Observe o atuador AGITD) (5s)");
                    Thread.Sleep(5000);
                    vet[5] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("AGUARDE: Agitador ativo! (15s)");
                    Thread.Sleep(15000);
                    Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Aguarde a ativação da Bomba e desativação do Agitador! (Observe os atuadores AGITD e BOMBA) (5s)");
                    Thread.Sleep(5000);
                    vet[5] = 0; vet[6] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("AGUARDE: Esvaziamento do tanque! (Observe o sensor N / A) (10s)");
                    Thread.Sleep(10000);
                    vet[2] = 0; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("AGUARDE: Esvaziamento do tanque! (Observe o sensor N / B e o atuador BOMBA) (20s)");
                    Thread.Sleep(20000);
                    ClearVet(vet); Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                    Console.WriteLine("Processo completo: Sistema ATIVO, pronto para setar novamente!");
                }

            Sair:

                Console.Clear(); ClearVet(vet); vet[0] = 1; Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Aperte uma tecla para setar novamente:");
                Console.ReadKey();
            }

        }

        int AT = 1;

        if (AM == 1)
        {
            vet[0] = 1;

            while (AT == 1)
            {
                Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();

                Console.WriteLine("Sistema ligado!  AGUARDE: (5s) ");
                Thread.Sleep(5000);
                Console.Clear();

                Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Nível Baixo: 0 (VAZIO) "); Thread.Sleep(2000);
                vet[1] = 0; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Nível Alto: 0 (VAZIO) "); Thread.Sleep(2000);
                vet[2] = 0; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();

                Console.Clear(); vet[7] = 0; vet[0] = 1; Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Aguarde a ativação da valvula de fluido quente! (Observe o atuador F_H) (5s)");
                Thread.Sleep(5000);
                vet[4] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Aguarde o enchimento parcial da caldeira com fluido quente! (Observe o sensor N / B) (10s)");
                Thread.Sleep(10000);
                vet[1] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Aguarde a ativação da valvula de fluido frio! (Observe o atuador F_C) (5s)");
                Thread.Sleep(5000);
                vet[3] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Aguarde o enchimento da caldeira com fluido quente e frio! (Observe o atuador F_C) (15s)");
                Thread.Sleep(15000);
                vet[3] = 0; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Aguarde o termino do enchimento da caldeira com fluido quente! (10s) (Observe o atuador F_H e o sensor N / A)");
                Thread.Sleep(10000);
                vet[4] = 0; vet[2] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Aguarde a ativação do Agitador! (Observe o atuador AGITD) (5s)");
                Thread.Sleep(5000);
                vet[5] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("AGUARDE: Agitador ativo! (15s)");
                Thread.Sleep(15000);
                Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Aguarde a ativação da Bomba e desativação do Agitador! (Observe os atuadores AGITD e BOMBA) (5s)");
                Thread.Sleep(5000);
                vet[5] = 0; vet[6] = 1; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("AGUARDE: Esvaziamento do tanque! (Observe o sensor N / A) (10s)");
                Thread.Sleep(10000);
                vet[2] = 0; Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("AGUARDE: Esvaziamento do tanque! (Observe o sensor N / B e o atuador BOMBA) (20s)");
                Thread.Sleep(20000);
                ClearVet(vet); Console.Clear(); Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Processo completo: Sistema ATIVO, pronto para setar novamente!");

                Console.Clear(); ClearVet(vet); vet[0] = 1; Texto1(); Texto2(); Vet(vet); Jump();
                Console.WriteLine("Reiniciando...  AGUARDE: (3s) ");
                Thread.Sleep(3000);

            }
        }


        static void Texto1() { Console.WriteLine("***      --------------->  Controle Geral da Caldeira  <---------------      ***"); }
        static void Texto2() { Console.WriteLine(" "); Console.WriteLine("***  ON//OFF --- N/B ---  N/A --- F_C --- F_H --- AGITD --- BOMBA --- ALERT  ***"); }
        static void ClearVet(int[] vet)
        {
            vet[0] = 0; vet[1] = 0; vet[2] = 0; vet[3] = 0; vet[4] = 0; vet[5] = 0; vet[6] = 0; vet[7] = 0;

        }
        static void Vet(int[] vet)
        {
            Console.WriteLine("        " + vet[0] + "         " + vet[1] + "        " + vet[2] + "       " + vet[3] + "       " + vet[4] + "        " + vet[5] + "         " + vet[6] + "         " + vet[7]);
        }

        static void Jump()
        {
            for (int q = 0; q < 3; q++)
            {
                Console.WriteLine(" ");
            }
        }
    }

}