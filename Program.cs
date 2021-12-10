using System;
using System.Net.NetworkInformation;
using System.IO;

namespace Pings_M11_UF2
{
    class Program
    {
        private static System.Net.NetworkInformation.IPStatus P_Reply(String IP){
            Ping p = new Ping();
            PingReply Answer;
            //string s;
            Answer = p.Send(IP);
            return Answer.Status;
        }
        private static Boolean Contains_something(String Line){
            char[] words=Line.ToCharArray();
        }
        static void Main(string[] args)
        {
            args=new String[]{"File", "Jping.txt"};
            try{
                if(args[0].ToUpper()=="FILE"){
                    ViaFile(args[1]);
                }else if(args[0].ToUpper()=="IP"){
                    ViaIP(args[1]);
                }else{
                    Console.WriteLine("The first argument is not valid");
           }
            }catch(IndexOutOfRangeException e){
                Console.WriteLine("ERROR: No hay suficientes argumentos");
                Console.WriteLine("El programa requiere del tipo de metodo y un segundo argumento sea IP o direccion de archivo conteniendo IP");
                Console.WriteLine("Dependiendo del tipo de metodo que escoja, las opciones son: File | IP");
            }
           
            
        }
        static void ViaFile(String file){
            StreamReader F_Reader= new StreamReader(file);
            String Line;
            while (F_Reader.Peek() >= 0){
                Line=F_Reader.ReadLine();
                try{
                    Console.WriteLine(Line+": "+P_Reply(Line));
                }catch(Exception e){
                    //Cuando el programa intenta hacer un ping donde hay una linia en blanco o una resolucion de nombres que no funcionase, provoca una excepcion
                    //La solucion en este caso fue hacer un try catch para que no parase el proceso
                    if(Line.Length>0){
                        //Y para que no leyese linias en blanco pues simplemente reviso que haya algo en el string aunque tambien cuente espacios en blanco
                        Console.WriteLine(Line+": HostUnreachable");
                    }
                    
                }
            }
        }
        static void ViaIP(String IP){
            Console.WriteLine(IP+": "+P_Reply(IP));
        }
    }
}
