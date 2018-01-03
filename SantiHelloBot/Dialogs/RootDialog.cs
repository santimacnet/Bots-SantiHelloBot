using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace SantiHelloBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user 
            if (activity.Text.Contains("hello"))
            {
                await context.PostAsync("No entiendo el idioma ingles, pero podemos chatear en castellano!!");
            }
            if (activity.Text.Contains("hola"))
            {
                await context.PostAsync("Hola Qtal!!");
            }
            else if (activity.Text.Contains("adios"))
            {
                await context.PostAsync("Adios, hasta pronto...");
            }
            else if (activity.Text.Contains("llamas"))
            {
                await context.PostAsync("Me llamo SantiBot");
            }
            else if (activity.Text.Contains("quien eres"))
            {
                await context.PostAsync("Soy un ChatBot de pruebas");
            }
            else if (activity.Text.Contains("dias"))
            {
                await context.PostAsync("Buenos dias, hora de trabajar!!");
            }
            else if (activity.Text.Contains("noches"))
            {
                await context.PostAsync("Buenas noches");
            }
            else if (activity.Text.Contains("fecha"))
            {
                await context.PostAsync($"Hoy es {DateTime.Now.ToShortDateString()}");
            }
            else if (activity.Text.Contains("hora"))
            {
                await context.PostAsync($"Son las {DateTime.Now.ToShortTimeString()}");
            }
            else
            {
                await context.PostAsync($"You sent {activity.Text} which was {length} chars");
            }

            context.Wait(MessageReceivedAsync);
        }
    }
}