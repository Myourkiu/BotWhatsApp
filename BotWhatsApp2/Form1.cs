namespace BotWhatsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WhatsAppSendMessage w = new WhatsAppSendMessage();
            w.SendMessage("oi maeeee","Mãe",false, null);
            //w.SendMessageWithImage("enviado pelo bot", "C:\\Users\\pedro\\OneDrive\\Imagens\\Imagens da Câmera\\amor.jpg", "Meu Amor");
            //w.SendImageToSticker( "C:\\Users\\pedro\\OneDrive\\Imagens\\Imagens da Câmera\\wl.jpg", "eu");
            //w.SendMessageWithEmoji("olá ", new List<string> { "brilhant", "robo" }, "Meu Amor");

        }
    }
}
