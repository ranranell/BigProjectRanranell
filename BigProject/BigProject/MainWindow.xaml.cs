using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BigProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int GlobalNumber = 1;
        int Globalnumber1 = 0;
        public string[] items { get; set; }
        Unit unit;
        //int Token = 0;
        private int _token = 0;
        public int Token
        {
            get { return _token; }
            set
            {
                
                _token = value;
                
            }
        }

        private int _lvl = 2;
        public int Lvl
        {
            get { return _lvl; }
            set
            {
                if (value > 99)
                {
                    _lvl = 99;
                }
                else
                    _lvl = value;
            }
        }

        public MainWindow()
        {

            InitializeComponent();
            items = new string[] { "Warrior", "Rogue", "Wizard" };
            DataContext = this;


        }


        private void Character_Selction_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (Character_Selction.SelectedItem != null)
            {
                // Получаем выбранное значение
                string selectedValue = Character_Selction.SelectedItem.ToString();

                // Здесь вы можете вызвать нужные действия или функции, используя выбранное значение
                // Например:
                if (selectedValue == "Warrior")
                {
                    unit = new Warrior();
                    CreateUnit(unit);
                }
                else if (selectedValue == "Rogue")
                {
                    unit = new Rogue();
                    CreateUnit(unit);
                }
                else if (selectedValue == "Wizard")
                {
                    unit = new Wizard();
                    CreateUnit(unit);
                }
            }
        }
        private void CreateUnit(Unit unit)
        {
            strength.Content = $" {unit.Strength.ToString()}";
            vitality.Content = $" {unit.Vitality.ToString()}";
            dexterity.Content = $" {unit.Dexterity.ToString()}";
            inteligence.Content = $"{unit.Inteligence.ToString()}";
            hp.Content = $"{unit.Health.ToString()}"; 
            mana.Content = $"{unit.Mana.ToString()}";
            p__damage.Content = $"{unit.PDmg.ToString()}";
            m__damage.Content = $"{unit.MDmg.ToString()}";
            crt__damage.Content = $"{unit.CrtDmg.ToString()}";
            armor.Content = $"{unit.Armor.ToString()}";
            crt__chance.Content = $"{unit.CrtChance.ToString()}";
            m__defence.Content = $"{unit.MDef.ToString()}";
            numberTokens.Content = Token.ToString();
        }

        private void strength__add_Click(object sender, RoutedEventArgs e)
        {
            if (unit != null & Token> 0)
            {
                unit.Strength += 1;
                
                unit.StartHealth();
                unit.StartPDamage();
                Token--;
                CreateUnit(unit);
            }
        }

        private void vitality__add_Click(object sender, RoutedEventArgs e)
        {
            if (unit != null & Token > 0)
            {
                unit.Vitality += 1;
                
                unit.StartHealth();
                Token--;
                CreateUnit(unit);
            }
        }

        private void dexterity__add_Click(object sender, RoutedEventArgs e)
        {
            if (unit != null & Token > 0)
            {
                unit.Dexterity += 1;
                
                unit.StartArmor();
                unit.StartCrtChance();
                unit.StartCrtDamage();
                Token--;
                CreateUnit(unit);
            }
        }

        private void inteligence__add_Click(object sender, RoutedEventArgs e)
        {
            if (unit != null & Token > 0)
            {
                unit.Inteligence += 1;
                
                unit.StartMana();
                unit.StartMDamage();
                unit.StartMDefense();
                Token--;
                CreateUnit(unit);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            numberTokens.Content = number__of__tokens.Text;
            string _token = number__of__tokens.Text;
            Token = Convert.ToInt32(_token);
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            if (unit != null & unit.Strength > 0)
            {
                Token++;
                unit.Strength -= 1;
                unit.StartHealth();
                unit.StartPDamage();
                CreateUnit(unit);
            }
        }

        private void minus_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (unit != null & unit.Vitality > 0)
            {
                unit.Vitality -= 1;
                unit.StartHealth();

                Token++;
                CreateUnit(unit);
            }
            
        }

        private void minus_Copy2_Click(object sender, RoutedEventArgs e)
        {
            if (unit != null & unit.Dexterity > 0)
            {
                unit.Dexterity -= 1;
                unit.StartCrtDamage();
                unit.StartCrtChance();
                unit.StartArmor();

                Token++;
                CreateUnit(unit);
            }
            
        }

        //private void minus_Copy3_Click(object sender, RoutedEventArgs e)
        //{
        //    if (unit != null & unit.Inteligence > 0)
        //    {
        //        unit.Inteligence -= 1;
        //        unit.StartMDefense();
        //        unit.StartMDamage();
        //        unit.StartMana();

        //        Token++;
        //        CreateUnit(unit);
        //    }
        //}

        private void minus_Copy3_Click_1(object sender, RoutedEventArgs e)
        {
            if (unit != null & unit.Inteligence > 0)
            {
                unit.Inteligence -= 1;
                unit.StartMDefense();
                unit.StartMDamage();
                unit.StartMana();

                Token++;
                CreateUnit(unit);
            }
        }

        private void OneHundred_button_Click(object sender, RoutedEventArgs e)
        {
            int Info_TextBox = Convert.ToInt32(number__of__tokens.Text.ToString());
            number__of__tokens.Text = (Info_TextBox + 100).ToString();
            CheckNumberOfToken();
        }

        private void FiveHundred_button_Click(object sender, RoutedEventArgs e)
        {
            int Info_TextBox = Convert.ToInt32(number__of__tokens.Text.ToString());
            number__of__tokens.Text = (Info_TextBox + 500).ToString();
            CheckNumberOfToken();
        }

        private void OneThousand_button_Click(object sender, RoutedEventArgs e)
        {
            int Info_TextBox = Convert.ToInt32(number__of__tokens.Text.ToString());
            number__of__tokens.Text = (Info_TextBox + 1000).ToString();
            CheckNumberOfToken();
        }

        private void CheckNumberOfToken()
        {

            int NumberOfTokensInt = Convert.ToInt32(number__of__tokens.Text.ToString());

            int NumberLvl = Globalnumber1 + (GlobalNumber) * 1000;

            if (NumberOfTokensInt >= NumberLvl)
            {
                Globalnumber1 = NumberLvl;
                number__of__tokens.Text = $"{0}";
                Token += (GlobalNumber) * 1000;
                numberTokens.Content = $"{Token}";
                lvl_label.Content = $"{Lvl++}";
                GlobalNumber += 1;
            }



        }
    }
}
