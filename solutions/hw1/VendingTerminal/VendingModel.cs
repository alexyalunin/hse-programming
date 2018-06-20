using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VendingTerminal
{
    public class VendingMachineModel
    {
        public event Action OnClicksUpdated;
        public event Action<string> FeedbackDelegate;


        public void GetVendingMashineInfo()
        {
            var json = File.ReadAllText(@"../../VendingMachineInfo.json");
            VendingMachine.instance = JsonConvert.DeserializeObject<VendingMachine>(json);
        }


        public void UpdateFile()
        {
            if (VendingMachine.instance != null)
            {
                string info = JsonConvert.SerializeObject(VendingMachine.instance);
                File.WriteAllText(@"../../VendingMachineInfo.json", info);
            }
        }


        public void ChangeCredit(int _amount)
        {
            VendingMachine.instance.credit += _amount;
            UpdateFile();
            OnClicksUpdated();
        }


        public void BuyItem(Item _item)
        {
            if (VendingMachine.instance.credit < _item.price)
            {
                FeedbackDelegate("Not enough credit");
                return;
            }
            if (_item.count < 1)
            {
                FeedbackDelegate($"{_item.name} is over");
                return;
            }

            int moneyToChange = VendingMachine.instance.credit - _item.price;
            Cash cashClone = CopyCash(VendingMachine.instance.cash);
            if (!IsPossibleToGiveChange(moneyToChange, cashClone))
            {
                FeedbackDelegate($"You can't buy a {_item.name}, because vending machine will not be able to give you the change");
                return;
            }

            _item.count -= 1;
            ChangeCredit(-_item.price);
        }


        public void GiveChange(int amount)
        {
            if (amount >= 1000 && VendingMachine.instance.cash.RUB1000 > 0)
            {
                UpdateCash(-1000);
                Console.WriteLine(1000);
                GiveChange(amount - 1000);
            }
            else if (amount >= 500 && VendingMachine.instance.cash.RUB500 > 0)
            {
                UpdateCash(-500);
                Console.WriteLine(500);
                GiveChange(amount - 500);
            }
            else if (amount >= 100 && VendingMachine.instance.cash.RUB100 > 0)
            {
                UpdateCash(-100);
                Console.WriteLine(100);
                GiveChange(amount - 100);
            }
            else if (amount >= 50 && VendingMachine.instance.cash.RUB500 > 0)
            {
                UpdateCash(-50);
                Console.WriteLine(50);
                GiveChange(amount - 50);
            }
            else if (amount >= 10 && VendingMachine.instance.cash.RUB10 > 0)
            {
                UpdateCash(-10);
                Console.WriteLine(10);
                GiveChange(amount - 10);
            }
            else if (amount >= 5 && VendingMachine.instance.cash.RUB5 > 0)
            {
                UpdateCash(-5);
                Console.WriteLine(5);
                GiveChange(amount - 5);
            }
            else if (amount >= 2 && VendingMachine.instance.cash.RUB2 > 0)
            {
                UpdateCash(-2);
                Console.WriteLine(2);
                GiveChange(amount - 2);
            }
            else if (amount >= 1 && VendingMachine.instance.cash.RUB1 > 0)
            {
                UpdateCash(-1);
                Console.WriteLine(1);
                GiveChange(amount - 1);
            }
            ChangeCredit(-VendingMachine.instance.credit);
        }


        private bool IsPossibleToGiveChange(int _amount, Cash _cash)
        {
            if (_amount >= 1000 && _cash.RUB1000 > 0)
            {
                _amount -= 1000;
                _cash.RUB1000 -= 1;
                IsPossibleToGiveChange(_amount, _cash);
            }
            else if (_amount >= 500 && _cash.RUB500 > 0)
            {
                _amount -= 500;
                _cash.RUB500 -= 1;
                IsPossibleToGiveChange(_amount, _cash);
            }
            else if (_amount >= 100 && _cash.RUB100 > 0)
            {
                _amount -= 100;
                _cash.RUB100 -= 1;
                IsPossibleToGiveChange(_amount, _cash);
            }
            else if (_amount >= 50 && _cash.RUB50 > 0)
            {
                _amount -= 50;
                _cash.RUB50 -= 1;
                IsPossibleToGiveChange(_amount, _cash);
            }
            else if (_amount >= 10 && _cash.RUB10 > 0)
            {
                _amount -= 10;
                _cash.RUB10 -= 1;
                IsPossibleToGiveChange(_amount, _cash);
            }
            else if (_amount >= 5 && _cash.RUB5 > 0)
            {
                _amount -= 5;
                _cash.RUB5 -= 1;
                IsPossibleToGiveChange(_amount, _cash);
            }
            else if (_amount >= 2 && _cash.RUB2 > 0)
            {
                _amount -= 2;
                _cash.RUB2 -= 1;
                IsPossibleToGiveChange(_amount, _cash);
            }
            else if (_amount >= 1 && _cash.RUB1 > 0)
            {
                _amount -= 1;
                _cash.RUB1 -= 1;
                IsPossibleToGiveChange(_amount, _cash);
            }
            else if (_amount >= 1 && _cash.RUB1 == 0)
            {
                return false;
            }
            return true;
        }


        public void UpdateCash(int _amount)
        {
            switch (_amount)
            {
                case -1000: VendingMachine.instance.cash.RUB1000 -= 1; break;
                case -500:  VendingMachine.instance.cash.RUB500  -= 1; break;
                case -100:  VendingMachine.instance.cash.RUB100  -= 1; break;
                case -50:   VendingMachine.instance.cash.RUB50   -= 1; break;
                case -10:   VendingMachine.instance.cash.RUB10   -= 1; break;
                case -5:    VendingMachine.instance.cash.RUB5    -= 1; break;
                case -2:    VendingMachine.instance.cash.RUB2    -= 1; break;
                case -1:    VendingMachine.instance.cash.RUB1    -= 1; break;
                case 1:     VendingMachine.instance.cash.RUB1    += 1; break;
                case 2:     VendingMachine.instance.cash.RUB2    += 1; break;
                case 5:     VendingMachine.instance.cash.RUB5    += 1; break;
                case 10:    VendingMachine.instance.cash.RUB10   += 1; break;
                case 50:    VendingMachine.instance.cash.RUB50   += 1; break;
                case 100:   VendingMachine.instance.cash.RUB100  += 1; break;
                case 500:   VendingMachine.instance.cash.RUB500  += 1; break;
                case 1000:  VendingMachine.instance.cash.RUB1000 += 1; break;
                default: break;
            }
        }


        private Cash CopyCash(Cash _cash)
        {
            Cash c = new Cash();
            string tmpStr = JsonConvert.SerializeObject(_cash);
            c = JsonConvert.DeserializeObject<Cash>(tmpStr);
            return c;
        }

    }
}
