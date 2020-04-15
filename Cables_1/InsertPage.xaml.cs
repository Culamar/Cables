using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Cables_1
{
    /// <summary>
    /// Interaction logic for InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Page
    {
        CablesEntities _db = new CablesEntities();
        public MainWindow mainWindow;
        public InsertPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }


        private void cross_sectional_screen_area_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void cross_sectional_area_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void resistance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
              && (!resistance.Text.Contains(".")
              && resistance.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void diameter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
              && (!diameter.Text.Contains(".")
              && diameter.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void core_diameter_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
              && (!core_diameter.Text.Contains(".")
              && core_diameter.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void t_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
              && (!La.Text.Contains(".")
              && La.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void t1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
              && (!rogr.Text.Contains(".")
              && rogr.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cross_sectional_area.Text == "" || int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) == 0)
                {
                    MessageBox.Show("Укажите сечение жилы");
                }
                else if (cross_sectional_screen_area.Text == "" || int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 0)
                {
                    MessageBox.Show("Укажите сечение экрана");
                }
                else if (resistance.Text == "" || double.Parse(resistance.Text, CultureInfo.InvariantCulture) == 0)
                {
                    MessageBox.Show("Укажите удельное сопротивление жилы постоянному току");
                }
                else if (diameter.Text == "" || double.Parse(diameter.Text, CultureInfo.InvariantCulture) == 0)
                {
                    MessageBox.Show("Укажите наружный диаметр кабеля");
                }
                else if (core_diameter.Text == "" || double.Parse(core_diameter.Text, CultureInfo.InvariantCulture) == 0)
                {
                    MessageBox.Show("Укажите диаметр жилы");
                }
                else if (La.Text == "" || double.Parse(La.Text, CultureInfo.InvariantCulture) == 0)
                {
                    MessageBox.Show("Укажите глубину заложения кабеля в грунт");
                }
                else if (double.Parse(diameter.Text, CultureInfo.InvariantCulture) < double.Parse(core_diameter.Text, CultureInfo.InvariantCulture))
                {


                    MessageBox.Show("Некорректно введены данные: Наружный диаметр должен быть больше диаметра жилы.");

                }
                else
                {
                    double yp1 = 0;
                    double yb1 = 0;
                    double xs4 = 1;
                    double xp4 = 1;
                    double s = 0;
                    double Ralt = 0;
                    double dzh = double.Parse(core_diameter.Text, CultureInfo.InvariantCulture);
                    double dvn = double.Parse(diameter.Text, CultureInfo.InvariantCulture);
                    double R90alt = 0;
                    double dav = 0;
                    double Xscreen = 0;
                    double Rs20 = 0;
                    double Rs90;
                    double RsR;
                    double p;
                    double q;
                    double RsX;
                    double LScreen = 0;
                    double LArmor = 0;
                    double diz = 0;
                    double dscreen = 0;
                    double h1;
                    double h2 = 0;
                    double h3 = 0;
                    double h = 0;
                    double T1;
                    double T2;
                    double T3;
                    double T4 = 0;
                    double Ds;
                    double Da;
                    double Pobolochki = 0;
                    double Ra = 0;
                    double Rsa = 0;
                    double darm;
                    double Farm = 0;
                    double s2 = 0;
                    double Imax;
                    int core = 1;
                    int Unom = 6;
                    double epsilon = 0;
                    double tgd = 0;
                    double L11 = 0;
                    if (obolochka.Text == "Полиэтилен")
                    {
                        Pobolochki = 3.5;
                    }
                    if (obolochka.Text == "Поливинилхлорид")
                    {
                        if (U.Text == "6 кВ" || U.Text == "10 кВ" || U.Text == "20 кВ")
                        {
                            Pobolochki = 5.0;
                        }
                        if (U.Text == "35 кВ" || U.Text == "110 кВ")
                        {
                            Pobolochki = 6.0;
                        }
                    }
                    double L = double.Parse(La.Text, CultureInfo.InvariantCulture);
                    if (cores.Text == "1")
                    {
                        core = 1;
                        if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) <= 25)
                        {
                            dscreen = 0.8;
                        }
                        else if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) <= 50)
                        {
                            dscreen = 1.15;
                        }
                        else if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) <= 70)
                        {
                            dscreen = 1.36;
                        }
                        else
                        {
                            dscreen = 1.6;
                        }
                        if (U.Text == "6 кВ")
                        {
                            Unom = 6;
                            epsilon = 2.5;
                            tgd = 0.004;
                            if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 500)
                            {
                                h3 = 2.5;
                            }
                            else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 800)
                            {
                                h3 = 2.7;
                            }
                            else
                            {
                                h3 = 2.9;
                            }
                        }
                        if (U.Text == "10 кВ")
                        {
                            Unom = 10;
                            epsilon = 2.5;
                            tgd = 0.004;
                            if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 500)
                            {
                                h3 = 2.5;
                            }
                            else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 800)
                            {
                                h3 = 2.7;
                            }
                            else
                            {
                                h3 = 2.9;
                            }
                        }
                        if (U.Text == "20 кВ")
                        {
                            Unom = 20;
                            epsilon = 2.5;
                            tgd = 0.004;
                            if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 400)
                            {
                                h3 = 2.5;
                            }
                            else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 630)
                            {
                                h3 = 2.7;
                            }
                            else
                            {
                                h3 = 2.9;
                            }
                        }
                        if (U.Text == "35 кВ")
                        {
                            Unom = 35;
                            epsilon = 2.5;
                            tgd = 0.004;
                            if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 240)
                            {
                                h3 = 2.5;
                            }
                            else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 500)
                            {
                                h3 = 2.7;
                            }
                            else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 800)
                            {
                                h3 = 2.9;
                            }
                            else
                            {
                                h3 = 3.5;
                            }
                        }
                        if (U.Text == "110 кВ")
                        {
                            Unom = 110;
                            epsilon = 2.5;
                            tgd = 0.001;
                            if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 240)
                            {
                                h3 = 2.5;
                            }
                            else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 500)
                            {
                                h3 = 2.7;
                            }
                            else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 800)
                            {
                                h3 = 2.9;
                            }
                            else
                            {
                                h3 = 3.5;
                            }
                        }
                    }
                    if (cores.Text == "3")
                    {
                        core = 3;
                        if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) < 70)
                        {
                            dscreen = 0.8;
                        }
                        else
                        {
                            dscreen = 1.15;
                        }
                        if (U.Text == "6 кВ")
                        {
                            Unom = 6;
                            epsilon = 2.5;
                            tgd = 0.004;
                            if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 35)
                            {
                                h3 = 2.5;
                            }
                            else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 95)
                            {
                                h3 = 2.7;
                            }
                            else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 185)
                            {
                                h3 = 2.9;
                            }
                            else
                            {
                                h3 = 3.5;
                            }
                        }
                        if (U.Text == "10 кВ")
                        {
                            Unom = 10;
                            epsilon = 2.5;
                            tgd = 0.004;
                            if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 70)
                            {
                                h3 = 2.7;
                            }
                            else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 150)
                            {
                                h3 = 2.9;
                            }
                            else
                            {
                                h3 = 3.5;
                            }
                        }
                        if (U.Text == "20 кВ")
                        {
                            Unom = 20;
                            epsilon = 2.5;
                            tgd = 0.004;
                            if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 95)
                            {
                                h3 = 2.9;
                            }
                            else
                            {
                                h3 = 3.5;
                            }
                        }
                        if (U.Text == "35 кВ")
                        {
                            Unom = 35;
                            epsilon = 2.5;
                            tgd = 0.004;
                            h3 = 3.5;
                        }
                        if (U.Text == "110 кВ")
                        {
                            Unom = 110;
                            epsilon = 2.5;
                            tgd = 0.001;
                        }
                    }
                    if (U.Text == "6 кВ")
                    {
                        h2 = 1;
                        if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 185)
                        {
                            diz = 2.5;
                        }
                        else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 240)
                        {
                            diz = 2.6;
                        }
                        else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 300)
                        {
                            diz = 2.7;
                        }
                        else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 400)
                        {
                            diz = 2.9;
                        }
                        else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) > 400)
                        {
                            diz = 3.1;
                        }
                    }
                    if (U.Text == "10 кВ")
                    {
                        h2 = 1.5;
                        diz = 3.3;
                    }
                    if (U.Text == "20 кВ")
                    {
                        h2 = 2;
                        diz = 5.3;
                    }
                    if (U.Text == "35 кВ")
                    {
                        h2 = 2.5;
                        diz = 8.2;
                    }
                    if (U.Text == "110 кВ")
                    {
                        h2 = 3;
                        if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 185)
                        {
                            diz = 16;
                        }
                        else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 240)
                        {
                            diz = 15;
                        }
                        else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 300)
                        {
                            diz = 14;
                        }
                        else
                        {
                            diz = 13;
                        }
                    }
                    if (material.Text == "Алюминий")
                    {

                        Ralt = 1.2821 * double.Parse(resistance.Text, CultureInfo.InvariantCulture);
                        if (paving.Text == "В плоскости" && cores.Text == "1")
                        {
                            s = 2 * dvn;
                        }
                        if (paving.Text == "Треугольником" && cores.Text == "1")
                        {
                            s = dvn;
                        }
                        if (cores.Text == "3")
                        {
                            if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) < 70)
                            {
                                dscreen = 0.8;
                            }
                            else
                            {
                                dscreen = 1.15;
                            }
                            s = dzh + 2 * (0.6 + diz + 0.6 + 0.25 + dscreen);
                        }
                        xs4 = 1.5735 / (Math.Pow(Ralt / 1000, 2) * 100000000);
                        xp4 = xs4;

                        if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) > 300)
                        {
                            yp1 = 1 / (0.8 + 192 / xs4);
                            yb1 = (Math.Pow(dzh / s, 2)) * (0.312 * (Math.Pow(dzh / s, 2)) + 1.18 / (0.27 + (1 / (0.8 + (192 / xp4))))) / (0.8 + (192 / xp4));

                        }
                        R90alt = Ralt * (1 + yp1 + yb1);

                    }
                    if (material.Text == "Медь")
                    {
                        Ralt = 1.275 * double.Parse(resistance.Text, CultureInfo.InvariantCulture);
                        if (paving.Text == "В плоскости" && cores.Text == "1")
                        {
                            s = 2 * dvn;
                        }
                        if (paving.Text == "Треугольником" && cores.Text == "1")
                        {
                            s = dvn;
                        }
                        if (cores.Text == "3")
                        {
                            if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) < 70)
                            {
                                dscreen = 0.8;
                            }
                            else
                            {
                                dscreen = 1.15;
                            }
                            s = dzh + 2 * (0.6 + diz + 0.6 + 0.25 + dscreen);
                        }
                        if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) < 1000)
                        {
                            xs4 = 1.5735 / (Math.Pow(Ralt / 1000, 2) * 100000000);
                            xp4 = xs4;
                        }
                        else
                        {
                            xs4 = 0.298 / (Math.Pow(Ralt / 1000, 2) * 100000000);
                            xp4 = 0.2138 / (Math.Pow(Ralt / 1000, 2) * 100000000);
                        }
                        if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) > 150)
                        {
                            yp1 = 1 / (0.8 + 192 / xs4);
                            yb1 = (Math.Pow(dzh / s, 2)) * (0.312 * (Math.Pow(dzh / s, 2)) + 1.18 / (0.27 + (1 / (0.8 + 192 / xp4)))) / (0.8 + (192 / xp4));

                        }
                        R90alt = Ralt * (1 + yp1 + yb1);
                    }
                    if (U.Text == "10 кВ" || U.Text == "6 кВ")
                    {
                        dav = dzh + 9.6 + 0.7;
                    }
                    if (U.Text == "20 кВ")
                    {
                        dav = dzh + 13.8 + 0.7;
                    }
                    if (U.Text == "35 кВ")
                    {
                        dav = dzh + 18.8 + 0.7;
                    }
                    if (U.Text == "110 кВ")
                    {
                        if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 185)
                        {
                            dav = dzh + 34.8 + 0.7;
                        }
                        else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 240)
                        {
                            dav = dzh + 32.8 + 0.7;
                        }
                        else if (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) <= 300)
                        {
                            dav = dzh + 30.8 + 0.7;
                        }
                        else
                        {
                            dav = dzh + 28.8 + 0.7;
                        }
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 16)
                    {
                        Rs20 = 1.19;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 25)
                    {
                        Rs20 = 0.759;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 35)
                    {
                        Rs20 = 0.542;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 50)
                    {
                        Rs20 = 0.379;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 70)
                    {
                        Rs20 = 0.271;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 95)
                    {
                        Rs20 = 0.200;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 120)
                    {
                        Rs20 = 0.158;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 150)
                    {
                        Rs20 = 0.127;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 185)
                    {
                        Rs20 = 0.103;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 240)
                    {
                        Rs20 = 0.079;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 300)
                    {
                        Rs20 = 0.0601;
                    }
                    if (int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture) == 400)
                    {
                        Rs20 = 0.0407;
                    }
                    Xscreen = 0.1444 * Math.Log10(2 * s / dav);
                    Rs90 = 1.2751 * Rs20;
                    RsR = Rs90 / R90alt;
                    p = Xscreen + 0.0433;
                    q = Xscreen - 0.0144;
                    RsX = Rs90 / Xscreen;

                    if (paving.Text == "Треугольником" && cores.Text == "1")
                    {
                        if ((int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) >= 1000 && material.Text == "Медь") || (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) >= 1200 && material.Text == "Алюминий"))
                        {
                            double m = 0.0314 / Rs90;
                            double F = 1 / (1 + (Math.Pow(R90alt, 2) / Math.Pow(Rs90, 2)));
                            double ds = dav + 0.7;
                            double gs = 1 + (Math.Pow((0.7 / ds), 1.74)) * ((151.24 * ds / 1000) - 1.6);
                            double L0 = 3 * (Math.Pow(m, 2) / 1 + Math.Pow(m, 2)) * (Math.Pow((dav / (2 * s)), 2));
                            double delta1 = (1.14 * Math.Pow(m, 2.45) + 0.33) * Math.Pow((dav / (2 * s)), (0.92 * m + 1.66));
                            L11 = RsR * (gs * L0 + delta1 + 0.0000436 * Math.Pow(0.7, 4)) * F;
                        }

                        LScreen = RsR / (1 + Math.Pow(RsX, 2))+L11;

                    }
                    if (paving.Text == "В плоскости" && cores.Text == "1")
                    {
                        if ((int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) >= 1000 && material.Text == "Медь") || (int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture) >= 1200 && material.Text == "Алюминий"))
                        {
                            double m = 0.0314 / Rs90;
                            double M = Rs90 / p;
                            double N = Rs90 / q;
                            double F = (4 * Math.Pow(M, 2) * Math.Pow(N, 2) + Math.Pow((M + N), 2)) / (4 * (Math.Pow(M, 2) + 1) * (Math.Pow(N, 2) + 1));
                            double ds = dav + 0.7;
                            double gs = 1 + (Math.Pow((0.7 / ds), 1.74)) * ((151.24 * ds / 1000) - 1.6);
                            double L0 = 6 * (Math.Pow(m, 2) / 1 + Math.Pow(m, 2)) * (Math.Pow((dav / (2 * s)), 2));
                            double delta1 = (0.86 * Math.Pow(m, 3.08)) * Math.Pow((dav / (2 * s)), (1.4 * m + 0.7));
                            L11 = RsR * (gs * L0 + delta1 + 0.0000436 * Math.Pow(0.7, 4)) * F;
                        }
                        LScreen = RsR * ((0.75 * Math.Pow(p, 2)) / ((Math.Pow(Rs90, 2) + Math.Pow(p, 2))) + (0.25 * Math.Pow(q, 2)) / (Math.Pow(Rs90, 2) + Math.Pow(q, 2)) + (2 * Rs90 * p * q * 0.0433) / (Math.Sqrt(3.0) * (Math.Pow(Rs90, 2) + Math.Pow(p, 2)) * (Math.Pow(Rs90, 2) + Math.Pow(q, 2))))+L11;

                    }
                    if (Armor.Text == "Без брони" && cores.Text == "3")
                    {
                        LScreen = (Rsa / R90alt) / (1 + Math.Pow((Rsa / Xscreen), 2));
                    }
                    if (Armor.Text == "Алюмининиевая проволочная")
                    {
                        Farm = 420.8;
                        Ra = 1.4 * 2.988 / Farm;
                        Rsa = Rs90 * Ra / (Rs90 + Ra);
                        LArmor = (Rsa / R90alt) / (1 + Math.Pow((Rsa / Xscreen), 2));
                        LScreen = 0;
                    }

                    if (Armor.Text == "Стальная ленточная" && cores.Text == "3")
                    {
                        Farm = 27;
                        darm = dvn - h3;
                        double k = 1 / (1 + Math.Pow(darm, 2) / 2578.79656);
                        Ra = 1.4 * 10.66 / Farm;
                        Rsa = Rs90 * Ra / (Rs90 + Ra);
                        LArmor = Math.Pow(s, 2) * Math.Pow(k, 2) * (0.166 + 1.93 / Math.Pow(darm, 2)) / (R90alt * 10000000);

                    }
                    if (Armor.Text == "Стальная проволочная" && cores.Text == "3")
                    {
                        Farm = 420.8;
                        darm = dvn - h3;
                        double c = dzh + 2 * (0.6 + diz + 0.6 + 0.25 + dscreen) + 0.3;
                        Ra = 1.4 * 10.66 / Farm;
                        Rsa = Rs90 * Ra / (Rs90 + Ra);
                        LArmor = 7.92 * (Ra / R90alt) * (Math.Pow((2 * c / darm), 2)) / (8.82 * 1000 * Ra + 1);
                    }
                    if (Armor.Text == "Стальная проволочная" && cores.Text == "1")
                    {
                        darm = dvn - h3;
                        Ra = 1.4 * 10.66 / 420.8;
                        Rsa = Rs90 * Ra / (Rs90 + Ra);
                        if (paving.Text == "Треугольником")
                        {
                            s2 = dvn;
                        }
                        if (paving.Text == "В плоскости")
                        {
                            s2 = 2.52 * dvn;
                        }
                        double dsr = dzh + 2 * (0.6 + diz + 0.6 + 0.25 + dscreen);
                        double Hs = 4.6 * Math.Log10(2 * s2 / dsr) / 10000000;
                        double H1 = 0.162 * Math.Pow(3.15 / darm, 2) / 1000;
                        double H2 = 0.162 * Math.Pow(3.15 / darm, 2) / 1000;
                        double H3 = 0.982 * (3.15 / darm) / 1000000;
                        double B1 = 314 * (Hs + H1 + H3);
                        double B2 = 314 * H2;
                        LArmor = (Rsa / R90alt) * (Math.Pow(B1, 2) + Math.Pow(B2, 2) + Rsa * B2) / (Math.Pow(B1, 2) + Math.Pow(B2 + Rsa, 2));
                        LScreen = 0;
                    }

                    h1 = 0.6 + diz + 0.6 + 0.25;

                    if (cores.Text == "1")
                    {
                        T1 = 1.28 * Math.Log10(1 + 2 * h1 / dzh);
                        Ds = dzh + 2 * (0.6 + diz + 0.6 + 0.25 + dscreen + 0.14);
                        T2 = 2.196 * Math.Log10(1 + 2 * h2 / Ds);
                        Da = dvn - 2 * h3;
                        T3 = 0.366 * Pobolochki * Math.Log10(1 + 2 * h3 / Da);
                        if (environment.Text == "Земля")
                        {
                            if (rogr.Text == "" || rogr.Text == "0")
                            {
                                T4 = 0.366 * 1.8 * (Math.Log10(4 * L * 1000 / dvn));
                            }
                            else
                            {
                                T4 = 0.366 * double.Parse(rogr.Text, CultureInfo.InvariantCulture) * (Math.Log10(4 * L * 1000 / dvn));
                            }
                        }
                        if (environment.Text == "Воздух")
                        {
                            double n;
                            n = (0.21 / (Math.Pow(dvn / 1000, 0.6))) + 3.94;
                            double ka = 3.141 * n * dvn * ((T1 / int.Parse(cores.Text, CultureInfo.InvariantCulture)) + T2 * (1 + LScreen) + T3 * (1 + LScreen + LArmor)) / ((1 + LScreen + LArmor) * 1000);
                            double Q;
                            double Qs = 65 / (1 + Math.Pow(ka, 2));
                            do
                            {
                                Q = Qs;
                                Qs = 65 / (1 + ka * Q);

                            }
                            while (Math.Abs(Q - Qs) > 0.001);
                            T4 = 0.318 / ((dvn / 1000) * n * Qs);
                        }
                    }
                    else
                    {
                        h = h1 * 2 + 2 * dscreen + 0.3;

                        T1 = 1.28 * Math.Log10(1 + 2 * h1 / dzh);
                        Ds = dzh + 2 * (0.6 + diz + 0.6 + 0.25 + dscreen);
                        T2 = 2.196 * Math.Log10(1 + 2 * h2 / Ds);
                        Da = dvn - 2 * h3;
                        T3 = 0.366 * Pobolochki * Math.Log10(1 + 2 * h3 / Da);
                        if (environment.Text == "Земля")
                        {

                            if (rogr.Text == "")
                            {
                                T4 = 0.366 * 1.8 * ((Math.Log10(4 * L * 1000 / dvn) + 2 * (Math.Log10(2 * L * 1000 / dvn))));
                            }
                            else
                            {
                                T4 = 0.366 * double.Parse(rogr.Text, CultureInfo.InvariantCulture) * ((Math.Log10(4 * L * 1000 / dvn) + 2 * (Math.Log10(2 * L * 1000 / dvn))));
                            }

                        }
                        if (environment.Text == "Воздух")
                        {
                            double n;
                            n = (0.21 / (Math.Pow(dvn / 1000, 0.6))) + 3.94;
                            double ka = 3.141 * n * dvn * ((T1 / int.Parse(cores.Text, CultureInfo.InvariantCulture)) + T2 * (1 + LScreen) + T3 * (1 + LScreen + LArmor)) / ((1 + LScreen + LArmor) * 1000);
                            double Q;
                            double Qs = 65 / (1 + Math.Pow(ka, 2));
                            do
                            {
                                Q = Qs;
                                Qs = 65 / (1 + ka * Q);

                            }
                            while (Math.Abs(Q - Qs) > 0.001);
                            T4 = 0.318 / ((dvn / 1000) * n * Qs);
                        }
                    }
                    double C = epsilon * Math.Pow(10, -9) / (18 * 2.3 * Math.Log10((dzh + 2 * (0.6 + diz)) / (dzh + 1.2)));
                    double W = 2 * (Math.PI) * 50 * C * Math.Pow((Unom * 1000 / (Math.Sqrt(3))), 2) * tgd;
                    Imax = Math.Sqrt((90 - 10 - W * (0.5 * T1 + core * (T2 + T3 + T4))) / ((R90alt / 1000) * (T1 + core * (T2 * (1 + LScreen) + (T3 + T4) * (1 + LScreen + LArmor)))));
                    Resistance newResistance = new Resistance()
                    {
                        cross_area = int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture),
                        screen_area = int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture),
                        R0 = double.Parse(resistance.Text, CultureInfo.InvariantCulture),
                        R_ = Ralt,
                        yp = yp1,
                        yb = yb1,
                        xs = xs4,
                        xp = xp4,
                        R = R90alt,
                        material = material.Text

                    };

                    _db.Resistance.Add(newResistance);
                    _db.SaveChanges();
                    AdminMenu.resistGrid.ItemsSource = _db.Resistance.ToList();

                    XResistanceScreen newXResScreen = new XResistanceScreen()
                    {
                        cable_id = newResistance.cable_id,
                        cross_area = int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture),
                        screen_area = int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture),
                        S = s,
                        d = dav,
                        dzh = dzh,
                        paving_type = paving.Text,
                        material = material.Text,
                        X = Xscreen
                    };

                    _db.XResistanceScreen.Add(newXResScreen);
                    _db.SaveChanges();
                    AdminMenu.XresistGrid.ItemsSource = _db.XResistanceScreen.ToList();

                    Loses newLoses = new Loses()
                    {
                        cable_id = newResistance.cable_id,
                        cross_area = int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture),
                        screen_area = int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture),
                        material = material.Text,
                        enviroment = environment.Text,
                        paving_type = paving.Text,
                        vein_number = int.Parse(cores.Text, CultureInfo.InvariantCulture),
                        Rs = Rs90,
                        Rs0 = Rs20,
                        Rs_R = RsR,
                        P = p,
                        Q = q,
                        Rs_X = RsX,
                        LambdaScreen = LScreen,
                        LambdaArmor = LArmor,
                        dvn = dvn,
                        Fst = 0,
                        Armor = Armor.Text
                    };
                    _db.Loses.Add(newLoses);
                    _db.SaveChanges();
                    AdminMenu.Losesgrid.ItemsSource = _db.Loses.ToList();

                    ThermalResistance thermalResistance = new ThermalResistance()
                    {
                        cable_id = newResistance.cable_id,
                        cross_area = int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture),
                        screen_area = int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture),
                        material = material.Text,
                        enviroment = environment.Text,
                        paving_type = paving.Text,
                        vein_number = int.Parse(cores.Text, CultureInfo.InvariantCulture),
                        h1 = h1,
                        h2 = h2,
                        h3 = h3,
                        h = h,
                        Ds = Ds,
                        dvn = dvn,
                        dzh = dzh,
                        T1 = T1,
                        T2 = T2,
                        T3 = T3,
                        T4 = T4,
                        Voltage = Unom,
                        Shell = obolochka.Text,
                        Armor = Armor.Text
                    };
                    _db.ThermalResistance.Add(thermalResistance);
                    _db.SaveChanges();
                    AdminMenu.Thermalgrid.ItemsSource = _db.ThermalResistance.ToList();

                    Current newCurrent = new Current()
                    {
                        cable_id = newResistance.cable_id,
                        cross_area = int.Parse(cross_sectional_area.Text, CultureInfo.InvariantCulture),
                        screen_area = int.Parse(cross_sectional_screen_area.Text, CultureInfo.InvariantCulture),
                        material = material.Text,
                        enviroment = environment.Text,
                        paving_type = paving.Text,
                        vein_number = int.Parse(cores.Text, CultureInfo.InvariantCulture),
                        I = Imax,
                        Voltage = Unom,
                        Wa = W
                    };
                    _db.Current.Add(newCurrent);
                    _db.SaveChanges();
                    AdminMenu.Igrid.ItemsSource = _db.Current.ToList();

                    mainWindow.OpenPage(MainWindow.pages.AdminMenu);
                    MessageBox.Show("Кабель добавлен.");
                }
            }
            catch
            {
                MessageBox.Show("Некоректно введены данные.");
            }

        }

        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.OpenPage(MainWindow.pages.AdminMenu);
        }

        private void cross_sectional_area_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void cross_sectional_screen_area_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void resistance_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void diameter_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void core_diameter_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void La_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void rogr_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
