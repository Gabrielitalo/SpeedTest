using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;


namespace SpeedTest
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      const string tempfile = "tempfile.tmp";
      System.Net.WebClient webClient = new System.Net.WebClient();

      listBox1.Items.Add("iniciando teste...");

      System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
      //webClient.DownloadFile("http://dl.google.com/googletalk/googletalk-setup.exe", tempfile);
      // Link de preferência estático de download para abir request, precisa ser o link de download no ponto a ser medido
      webClient.DownloadFile("https://uc2242f273f2d3d5fdeeed40dd80.dl.dropboxusercontent.com/cd/0/get/Azq28lX1zZIEvPzHEzFZBrn3O-H2aMLF5NnMb0GHq4hP0XwP1fH61ViekdGro5JJ92Eu88VVTUOg6tPEb1CQqXo6WG_bgbqoQQv5WCI7n3driQ/file", tempfile);
      sw.Stop();

      FileInfo fileInfo = new FileInfo(tempfile);
      long speed = fileInfo.Length / sw.Elapsed.Seconds; // Bytes/S

      listBox1.Items.Add("Tempo gasto: " + sw.Elapsed.ToString());
      listBox1.Items.Add("Tamanho do arquivo: " + fileInfo.Length.ToString("N0"));
      listBox1.Items.Add("Taxa de Transferência do Download é: " + (speed / 1000000).ToString() + " MBps.");
      listBox1.Items.Add("Velocidade de Download é: " + ((speed / 1000000) * 8).ToString() + " MB.");

      //MessageBox.Show(sw.Elapsed.ToString());
      //MessageBox.Show(fileInfo.Length.ToString("N0"));
      //MessageBox.Show(speed.ToString("N0"));

      webClient.Dispose();
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      const string tempfile = "EFD.txt";
      string caminhoUpload = "\\\\192.168.0.5\\Arquivo\\4\\Usuários\\2528\\GINFES";
      System.Net.WebClient webClient = new System.Net.WebClient();

      listBox1.Items.Add("iniciando teste Upload...");

      System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
      webClient.UploadFile(caminhoUpload, tempfile);
      sw.Stop();

      FileInfo fileInfo = new FileInfo(tempfile);
      long speed = fileInfo.Length / sw.Elapsed.Seconds; // Bytes/S

      listBox1.Items.Add("Tempo gasto: " + sw.Elapsed.ToString());
      listBox1.Items.Add("Tamanho do arquivo: " + fileInfo.Length.ToString("N0"));
      listBox1.Items.Add("Taxa de Transferência do Upload é: " + (speed / 1000000).ToString() + " MBps.");
      listBox1.Items.Add("Velocidade de Upload é: " + ((speed / 1000000) * 8).ToString() + " MB.");

      //MessageBox.Show(sw.Elapsed.ToString());
      //MessageBox.Show(fileInfo.Length.ToString("N0"));
      //MessageBox.Show(speed.ToString("N0"));

      webClient.Dispose();
    }


  }
}
