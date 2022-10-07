using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using MVCBasics.Models;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;

namespace MVCBasics.Controllers
{
    public class GuessNumberController : Controller
    {
        public IActionResult GuessNumber()
        {
    
            if (!SecretNumberIsSet())
            {
                InitGame();
            }

            UpdateViewBag();

            return View();
        }

        [HttpPost]
        public IActionResult GuessNumber(int guess, string action)
        {

            switch (action)
            {
                case "Guess":
                    string result = MakeGuess(guess);
                    SetMessage(result);
                    SetGuess(guess);
                    UpdateGuessCount();

                    if (GuessIsCorrect())
                    {
                        UpdateLowestGuessCount();
                    }

                    break;
                case "Play Again":
                default:
                    InitGame();
                    break;
            }

            UpdateViewBag();

            return View();
        }

        public IActionResult DeleteCookies()
        {
            DeleteLowestGuessCountCookie();

            return RedirectToAction("GuessNumber", "GuessNumber");
        }

        public IActionResult DeleteSession()
        {
            ClearSession();

            return RedirectToAction("GuessNumber", "GuessNumber");
        }

        private bool SecretNumberIsSet()
        {
            string secretNumber = HttpContext.Session.GetString("guessnumber_secretNumber") ?? string.Empty;
            return string.IsNullOrEmpty(secretNumber) == false;
        }

        private void InitGame()
        {
            SetSecretNumber(GuessNumberModel.GenerateSecretNumber());
            SetMessage("I'm thinking of a number between 1 and 100. Try to guess it!");
            SetGuess(0);
            SetGuessCount(0);
        }

        private void UpdateViewBag()
        {
            ViewBag.Guess = GetGuess();
            ViewBag.GuessCount = GetGuessCount();

            string lowestGuessCount = GetLowestGuessCount();
            ViewBag.LowestGuessCount = string.IsNullOrEmpty(lowestGuessCount) ? "(no history)" : lowestGuessCount;

            ViewBag.Message = GetMessage();
            ViewBag.AskPlayAgain = GuessIsCorrect();
        }

        private string MakeGuess(int guess)
        {
            int secretNumber = NumberAsInt(GetSecretNumber());
            return GuessNumberModel.CompareNumbers(guess, secretNumber);
        }

        private bool GuessIsCorrect()
        {
            int guess = NumberAsInt(GetGuess());
            int secretNumber = NumberAsInt(GetSecretNumber());
            return guess == secretNumber;
        }

        private void SetSecretNumber(int secretNumber)
        {
            HttpContext.Session.SetString("guessnumber_secretNumber", secretNumber.ToString());
        }

        private string GetSecretNumber()
        {
            return HttpContext.Session.GetString("guessnumber_secretNumber") ?? string.Empty;
        } 

        private void SetMessage(string message)
        {
            HttpContext.Session.SetString("guessnumber_message", message);
        }

        private string GetMessage()
        {
            return HttpContext.Session.GetString("guessnumber_message") ?? string.Empty;
        }

        private void SetGuess(int guess)
        {
            HttpContext.Session.SetString("guessnumber_guess", guess.ToString());
        }

        private string GetGuess()
        {
            return HttpContext.Session.GetString("guessnumber_guess") ?? string.Empty;
        }

        private void SetGuessCount(int guessCount)
        {
            HttpContext.Session.SetString("guessnumber_guessCount", guessCount.ToString());
        }

        private string GetGuessCount()
        {
            return HttpContext.Session.GetString("guessnumber_guessCount") ?? string.Empty;
        }

        private void UpdateGuessCount()
        {
            int count = NumberAsInt(GetGuessCount());
            count++;
            SetGuessCount(count);
        }

        private void SetLowestGuessCountCookie(int guessCount)
        {
            CookieOptions cookieOptions = new()
            {
                Expires = DateTime.Now.AddDays(7)
            };

            HttpContext.Response.Cookies.Append("guessnumber_lowestGuessCount", guessCount.ToString(), cookieOptions);
        }

        private string GetLowestGuessCountCookie()
        {
            return HttpContext.Request.Cookies["guessnumber_lowestGuessCount"] ?? string.Empty;
        }

        private void UpdateLowestGuessCountCookie(int guessCount)
        {
            string lowestGuessCount = GetLowestGuessCountCookie();

            if (string.IsNullOrEmpty(lowestGuessCount) || guessCount < NumberAsInt(lowestGuessCount))
            {
                SetLowestGuessCountCookie(guessCount);
            }
        }

        private void DeleteLowestGuessCountCookie()
        {
            HttpContext.Response.Cookies.Delete("guessnumber_lowestGuessCount");
        }

        private void SetLowestGuessCountSession(int guessCount)
        {
            HttpContext.Session.SetString("guessnumber_lowestGuessCount", guessCount.ToString());
        }

        private string GetLowestGuessCountSession()
        {
            return HttpContext.Session.GetString("guessnumber_lowestGuessCount") ?? string.Empty;
        }

        private void UpdateLowestGuessCountSession(int guessCount)
        {
            string lowestGuessCount = GetLowestGuessCountSession();

            if (string.IsNullOrEmpty(lowestGuessCount) || guessCount < NumberAsInt(lowestGuessCount))
            {
                SetLowestGuessCountSession(guessCount);
            }
        }

        private void ClearSession()
        {
            HttpContext.Session.Clear();    
        }

        public string GetLowestGuessCount()
        {
            string lowestGuessCountCookie = GetLowestGuessCountCookie();

            if (!string.IsNullOrEmpty(lowestGuessCountCookie))
            {
                UpdateLowestGuessCountSession(NumberAsInt(lowestGuessCountCookie));
            }

            return GetLowestGuessCountSession();
        }

        public void UpdateLowestGuessCount()
        {
            int guessCount = NumberAsInt(GetGuessCount());
            UpdateLowestGuessCountSession(guessCount);
            UpdateLowestGuessCountCookie(guessCount);
        }

        private static int NumberAsInt(string number)
        {
            return Int32.Parse(number);
        }
    }
}
