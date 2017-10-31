using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System;


class catFacts{
    static string getCatFact(){
        var lines = File.ReadAllLines("catfacts.txt");
        
        int rand = new Random().Next(lines.Length);
        return lines[rand];
    }
    [STAThread]
    public static void Main(){
        while(true){
            
            Clipboard.SetText(getCatFact());
            Thread.Sleep(1000);
        }
    }
}
