using EasyAutomationFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotWhatsApp2
{
    public class WhatsAppSendMessage : Web
    {

        public void StartApplication(string to)
        {
            StartBrowser(TypeDriver.GoogleChorme, "C:\\Users\\pedro\\AppData\\Local\\Google\\Chrome\\User Data");
            Navigate("https://web.whatsapp.com");

            WaitForLoad();

            Thread.Sleep(TimeSpan.FromSeconds(10));

            var searchEl = AssignValue(TypeElement.Xpath, "/html/body/div[1]/div/div[2]/div[3]/div/div[1]/div/div[2]/div[2]/div/div[1]", to);

            searchEl.element.SendKeys(OpenQA.Selenium.Keys.Enter);
        }

        public void SendMessage(string message, string to, bool isLoop, int? timeLoop) 
        {
            StartApplication(to);

            if(isLoop == true)
            {
                for (int? i = 0; i < timeLoop; i++)
                {
                    var messageEl = AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]", message);

                    messageEl.element.SendKeys(OpenQA.Selenium.Keys.Enter);

                    
                }
            }
            else
            {
                timeLoop = null;

                var messageEl = AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]", message);

                Thread.Sleep(TimeSpan.FromSeconds(1));

                messageEl.element.SendKeys(OpenQA.Selenium.Keys.Enter);

                Thread.Sleep(TimeSpan.FromSeconds(2));
            }

            Thread.Sleep(TimeSpan.FromSeconds(2));

            CloseBrowser();

        }

        public void SendMessageWithImage(string message, string pathImg, string to)
        {
            StartApplication(to);

            Thread.Sleep(TimeSpan.FromSeconds(1));

            Click(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/div/div");

            AssignValue(TypeElement.Xpath, "/html/body/div[1]/div/div[2]/div[4]/div/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/span/div/ul/div/div[2]/li/div/input", pathImg);

            Thread.Sleep(TimeSpan.FromSeconds(1));

            var inputEl = AssignValue(TypeElement.Xpath, "//*[@id=\"app\"]/div/div[2]/div[2]/div[2]/span/div/span/div/div/div[2]/div/div[1]/div[3]/div/div/div[1]/div[1]/div[1]/p", message);

            inputEl.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            Thread.Sleep(TimeSpan.FromSeconds(8));

            CloseBrowser();
        }

        public void SendImageToSticker(string pathImg, string to)
        {
            StartApplication(to);

            Thread.Sleep(TimeSpan.FromSeconds(1));

            AssignValue(TypeElement.Xpath, "/html/body/div[1]/div/div[2]/div[4]/div/footer/input", pathImg);


            Thread.Sleep(TimeSpan.FromSeconds(1));

            Click(TypeElement.Xpath, "//*[@id=\"app\"]/div/div[2]/div[2]/div[2]/span/div/span/div/div/div[2]/div/div[2]/div[2]/div/div");

            Thread.Sleep(TimeSpan.FromSeconds(8));

            CloseBrowser();
        }

        public void SendMessageWithEmoji(string message, List<string> emojis, string to)
        {
            StartApplication(to);

            var inputEl = AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]", message);

            foreach (var emoji in emojis)
            {
                AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]", ":");
                var emojiEl = AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]", emoji);

                emojiEl.element.SendKeys(OpenQA.Selenium.Keys.Tab);
            }
            
            inputEl.element.SendKeys(OpenQA.Selenium.Keys.Enter);

            Thread.Sleep(TimeSpan.FromSeconds(3));

            CloseBrowser();

        }

    }
}
