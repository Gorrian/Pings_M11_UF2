using System;
using System.Net.NetworkInformation;
using System.IO;

namespace Pings_M11_UF2
{
    class Program
    {
        private static IPStatus P_Reply(string IP){
            Ping p = new Ping();
            PingReply Answer;
            //string s;
            Answer = p.Send(IP);
            return Answer.Status;
        }
        private static Boolean Contains_something(string Line){
            char[] words=Line.ToCharArray();
            for(int i=0;i<words.Length;i++){
                if(words[i]!=' '){
                    return true;
                }
            }
            return false;
        }
        private static string Remove_spaces(string Name){
            Char words=Name.ToCharArray();
            String Solved="";
            for(int i=0;i<words.Length;i++){
                if(words!=' '){
                    Solved+=words[i];
                }
            }
            return Solved;
        }
        static void Main(string[] args)
        {
            //args=new String[]{"IP", "Somewhere"};
            try{
                if(args[0].ToUpper()=="FILE"){
                    ViaFile(args[1]);
                }else if(args[0].ToUpper()=="IP"){
                    ViaIP(args[1]);
                }else{
                    Console.WriteLine("El primer argumento no es valido");
           }
            }catch(IndexOutOfRangeException){
                Console.WriteLine("ERROR: No hay suficientes argumentos");
                Console.WriteLine("El programa requiere del tipo de metodo y un segundo argumento sea IP o direccion de archivo conteniendo IP");
                Console.WriteLine("Dependiendo del tipo de metodo que escoja, las opciones son: File | IP");
            }
           
            
        }
        static void ViaFile(string file){
            StreamReader F_Reader= new StreamReader(file);
            string Line;
            while (F_Reader.Peek() >= 0){
                Line=F_Reader.ReadLine();
                if(Contains_something(Line)){
                    try{
                        Console.WriteLine(Remove_spaces(Line)+": "+P_Reply(Line));
                    }catch(Exception){
                        //Cuando el programa intenta hacer una resolucion de nombres y falla provoca una excepcion haciendo que el programe para su proceso.
                        //Para solucionarlo cre un try catch que al detectar caulquier excepcion simplemente dice que hubo un error en la resolucion
                        Console.WriteLine(Line+": NameNotRecognized");
                        
                    }
                }
                
            }
        }
        static void ViaIP(string IP){
            try{
                Console.WriteLine(IP+": "+P_Reply(IP));
            }catch(Exception){
                Console.WriteLine(IP+": NameNotRecognized");
            }
            
        }
    }
}
