using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using System;

class catFacts{
    static string getCatFact(){
        HttpWebRequest rq = (HttpWebRequest)WebRequest.Create("https://catfact.ninja/fact");
        rq.Method = "GET";
        HttpWebResponse resp = (HttpWebResponse)rq.GetResponse();
        using(StreamReader s = new StreamReader(resp.GetResponseStream())) {
            for(int i = 0; i < 9; i++){
                s.Read();
            }
            string output = "";
            char ch = (char)s.Read();
            while (ch != '\"'){
                if(ch == '\\')
                    ch = (char)s.Read();
                output += ch;
                ch = (char)s.Read();
            }
            return output;
        }
    }
    [STAThread]
    public static void Main(){
        while(true){
            Clipboard.SetText(getCatFact());
            Thread.Sleep(500);
        }
    }
}
