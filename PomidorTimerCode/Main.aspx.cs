using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PomidorTimerCode
{
    public partial class Main : System.Web.UI.Page
    {
        // оставшееся время в секундах
        private int SecondsLeft
        {
            get
            {
                return ViewState["SecondsLeft"] == null ? 25 * 60 : (int)ViewState["SecondsLeft"];
            }
            set { ViewState["SecondsLeft"] = value; }
        }

        // проверка текущего режима работы
        private string CurrentMode
        {
            get
            {
                return ViewState["CurrentMode"] == null ? "Work" : (string)ViewState["CurrentMode"];
            }
            set { ViewState["CurrentMode"] = value; }
        }

        // количество пройденных интервалов
        private int CompletedWork
        {
            get
            {
                return ViewState["CompletedWork"] == null ? 0 : (int)ViewState["CompletedWork"];
            }
            set { ViewState["CompletedWork"] = value; }
        }

        // проверка запуска
        private bool IsRunning
        {
            get
            {
                return ViewState["IsRunning"] != null && (bool)ViewState["IsRunning"];
            }
            set { ViewState["IsRunning"] = value; }
        }

        // обновление отображения времени
        private void UpdateLabel()
        {
            Label1.Text = string.Format(
                "{0:D2}:{1:D2}",
                SecondsLeft / 60,
                SecondsLeft % 60
            );
        }

        // установка нового интервала
        private void SetInterval(string mode, int minutes)
        {
            CurrentMode = mode;
            SecondsLeft = minutes * 60;
            UpdateLabel();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentMode = "Work";
                SecondsLeft = 25 * 60;
                CompletedWork = 0;
                IsRunning = false;

                Timer1.Enabled = false;

                UpdateLabel();
            }
        }

        // работа
        protected void Button1_Click(object sender, EventArgs e)
        {
            IsRunning = false;
            Timer1.Enabled = false;

            SetInterval("Work", 25);
        }

        // короткий перерыв
        protected void Button2_Click(object sender, EventArgs e)
        {
            IsRunning = false;
            Timer1.Enabled = false;

            SetInterval("Break", 5);
        }

        // длинный перерыв
        protected void Button3_Click(object sender, EventArgs e)
        {
            IsRunning = false;
            Timer1.Enabled = false;

            SetInterval("LongBreak", 15);
        }

        // старт
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (SecondsLeft > 0)
            {
                IsRunning = true;
                Timer1.Enabled = true;
            }
        }

        // пауза
        protected void Button5_Click(object sender, EventArgs e)
        {
            IsRunning = false;
            Timer1.Enabled = false;
        }

        // продолжить
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (SecondsLeft > 0)
            {
                IsRunning = true;
                Timer1.Enabled = true;
            }
        }

        // сброс
        protected void Button7_Click(object sender, EventArgs e)
        {
            IsRunning = false;
            Timer1.Enabled = false;

            if (CurrentMode == "Work")
                SecondsLeft = 25 * 60;
            else if (CurrentMode == "Break")
                SecondsLeft = 5 * 60;
            else
                SecondsLeft = 15 * 60;

            UpdateLabel();
        }

        // таймер
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (!IsRunning)
            {
                Timer1.Enabled = false;
                return;
            }

            // уменьшается оставшееся время
            if (SecondsLeft > 0)
            {
                SecondsLeft--;
            }

            // проверяем завершение интервала
            if (SecondsLeft <= 0)
            {
                if (CurrentMode == "Work")
                {
                    // завершён рабочий интервал
                    CompletedWork++;

                    if (CompletedWork % 4 == 0)
                    {
                        // после четырёх рабочих интервалов начинается длинный перерыв
                        CurrentMode = "LongBreak";
                        SecondsLeft = 15 * 60;
                    }
                    else
                    {
                        // начинается короткий перерыв
                        CurrentMode = "Break";
                        SecondsLeft = 5 * 60;
                    }
                }
                else if (CurrentMode == "Break")
                {
                    // после короткого перерыва начинается работа
                    CurrentMode = "Work";
                    SecondsLeft = 25 * 60;
                }
                else if (CurrentMode == "LongBreak")
                {
                    // полный цикл завершён
                    CurrentMode = "Work";
                    SecondsLeft = 25 * 60;

                    CompletedWork = 0;

                    // останавливаем таймер после полного цикла
                    IsRunning = false;
                    Timer1.Enabled = false;
                }
            }

            UpdateLabel();
        }

    }
}