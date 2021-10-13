using matsukifudousan.Model;
using matsukifudousan.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace matsukifudousan
{
    /// <summary>
    /// ContractDetails.xaml の相互作用ロジック
    /// </summary>
    public partial class ContractDetails : Window
    {
        public ContractDetails()
        {
            InitializeComponent();
            ParkingChoose.IsEnabled = false;
            ElectronicChoose.IsEnabled = false;
            Gaschoose.IsEnabled = false;
            WaterServiceChoose.IsEnabled = false;
            WaterTankChoose.IsEnabled = false;
            ToiletChoose.IsEnabled = false;
            ProcessEquipment.IsEnabled = false;
            SinkChoose.IsEnabled = false;
            FaucetChoose.IsEnabled = false;
            KitchenChoose.IsEnabled = false;
            WaterHeaterChoose.IsEnabled = false;
            StoveChoose.IsEnabled = false;
            BathroomChoose.IsEnabled = false;
            ShowerChoose.IsEnabled = false;
            ReheatingChoose.IsEnabled = false;
            ShowerWithChoose.IsEnabled = false;
            BathtubChoose.IsEnabled = false;
            WashingMachineChoose.IsEnabled = false;
            ConnectionBracketChoose.IsEnabled = false;
            LightingEquipmentChoose.IsEnabled = false;
            LightBulbBallChoose.IsEnabled = false;
            AntennaChoose.IsEnabled = false;
            FixedlinephoneChoose.IsEnabled = false;
            PhoneChoose.IsEnabled = false;
            InternetChoose.IsEnabled = false;
            ProviderChoose.IsEnabled = false;
            ElectricityChoose.IsEnabled = false;
            GarbageStorageChoose.IsEnabled = false;
            PetChoose.IsEnabled = false;
            StorageChoose.IsEnabled = false;
            UseNoYesChoose.IsEnabled = false;
            HotSpringChoose.IsEnabled = false;
            OtherHouseChoose.IsEnabled = false;
            OtherConditionsChoose.IsEnabled = false;
        }
        private void ContractVM_Loaded(object sender, RoutedEventArgs e)
        {
            Parking.SelectionChanged += Parking_SelectionChanged;
            Electronic.SelectionChanged += Electronic_SelectionChanged;
            Gas.SelectionChanged += Gas_SelectionChanged;
            WaterService.SelectionChanged += WaterService_SelectionChanged;
            WaterTank.SelectionChanged += WaterTank_SelectionChanged;
            Toilet.SelectionChanged += Toilet_SelectionChanged;
            ProcessEquipment.SelectionChanged += ProcessEquipment_SelectionChanged;
            Sink.SelectionChanged += Sink_SelectionChanged;
            Faucet.SelectionChanged += Faucet_SelectionChanged;
            Kitchen.SelectionChanged += Kitchen_SelectionChanged;
            WaterHeater.SelectionChanged += WaterHeater_SelectionChanged;
            Stove.SelectionChanged += Stove_SelectionChanged;
            Bathroom.SelectionChanged += Bathroom_SelectionChanged;
            Shower.SelectionChanged += Shower_SelectionChanged;
            Reheating.SelectionChanged += Reheating_SelectionChanged;
            ShowerWith.SelectionChanged += ShowerWith_SelectionChanged;
            Bathtub.SelectionChanged += Bathtub_SelectionChanged;
            WashingMachine.SelectionChanged += WashingMachine_SelectionChanged;
            ConnectionBracket.SelectionChanged += ConnectionBracket_SelectionChanged;
            LightingEquipment.SelectionChanged += LightingEquipment_SelectionChanged;
            LightBulbBall.SelectionChanged += LightBulbBall_SelectionChanged;
            Antenna.SelectionChanged += Antenna_SelectionChanged;
            Fixedlinephone.SelectionChanged += Fixedlinephone_SelectionChanged;
            Phone.SelectionChanged += Phone_SelectionChanged;
            Internet.SelectionChanged += Internet_SelectionChanged;
            Provider.SelectionChanged += Provider_SelectionChanged;
            Electricity.SelectionChanged += Electricity_SelectionChanged;
            GarbageStorage.SelectionChanged += GarbageStorage_SelectionChanged;
            Pet.SelectionChanged += Pet_SelectionChanged;
            Storage.SelectionChanged += Storage_SelectionChanged;
            UseNoYes.SelectionChanged += UseNoYes_SelectionChanged;
            HotSpring.SelectionChanged += HotSpring_SelectionChanged;
            OtherHouse.SelectionChanged += OtherHouse_SelectionChanged;
            OtherConditions.SelectionChanged += OtherConditions_SelectionChanged;
        }
        private void Parking_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Parking.SelectedValue == "有")
            {
                ParkingChoose.IsEnabled = true;
            }
            else
            {
                ParkingChoose.IsEnabled = false;
                ParkingChoose.SelectedValue = null;
            }
        }
        private void Electronic_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Electronic.SelectedValue == "有")
            {
                ElectronicChoose.IsEnabled = true;
                ElectronicChoose.Text = "東京電力エナジーパトナー㈱";
            }
            else
            {
                ElectronicChoose.IsEnabled = false;
                ElectronicChoose.Text = null;
            }
        }
        private void Gas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Gas.SelectedValue == "有")
            {
                Gaschoose.IsEnabled = true;
            }
            else
            {
                Gaschoose.IsEnabled = false;
                Gaschoose.SelectedValue = null;
            }
        }
        private void WaterService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WaterService.SelectedValue == "有")
            {
                WaterServiceChoose.IsEnabled = true;
            }
            else
            {
                WaterServiceChoose.IsEnabled = false;
                WaterServiceChoose.SelectedValue = null;
            }
        }
        private void WaterTank_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WaterTank.SelectedValue == "有")
            {
                WaterTankChoose.IsEnabled = true;
            }
            else
            {
                WaterTankChoose.IsEnabled = false;
                WaterTankChoose.SelectedValue = null;
            }
        }
        private void Toilet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Toilet.SelectedValue == "有")
            {
                ToiletChoose.IsEnabled = true;
            }
            else
            {
                ToiletChoose.IsEnabled = false;
                ToiletChoose.SelectedValue = null;
            }
        }
        private void ProcessEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProcessEquipment.SelectedValue == "有")
            {
                ProcessEquipmentChoose.IsEnabled = true;
            }
            else
            {
                ProcessEquipmentChoose.IsEnabled = false;
            }
        }
        private void Sink_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Sink.SelectedValue == "有")
            {
                SinkChoose.IsEnabled = true;
            }
            else
            {
                SinkChoose.IsEnabled = false;
            }
        }
        private void Faucet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Faucet.SelectedValue == "有")
            {
                FaucetChoose.IsEnabled = true;
            }
            else
            {
                FaucetChoose.IsEnabled = false;
            }
        }
        private void Kitchen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Kitchen.SelectedValue == "有")
            {
                KitchenChoose.IsEnabled = true;
            }
            else
            {
                KitchenChoose.IsEnabled = false;
            }
        }
        private void WaterHeater_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WaterHeater.SelectedValue == "有")
            {
                WaterHeaterChoose.IsEnabled = true;
            }
            else
            {
                WaterHeaterChoose.IsEnabled = false;
            }
        }
        private void Stove_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Stove.SelectedValue == "有")
            {
                StoveChoose.IsEnabled = true;
            }
            else
            {
                StoveChoose.IsEnabled = false;
            }
        }
        private void Bathroom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Bathroom.SelectedValue == "有")
            {
                BathroomChoose.IsEnabled = true;
            }
            else
            {
                BathroomChoose.IsEnabled = false;
            }
        }
        private void Shower_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Shower.SelectedValue == "有")
            {
                ShowerChoose.IsEnabled = true;
            }
            else
            {
                ShowerChoose.IsEnabled = false;
            }
        }
        private void Reheating_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Reheating.SelectedValue == "有")
            {
                ReheatingChoose.IsEnabled = true;
            }
            else
            {
                ReheatingChoose.IsEnabled = false;
            }
        }
        private void ShowerWith_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ShowerWith.SelectedValue == "有")
            {
                ShowerWithChoose.IsEnabled = true;
            }
            else
            {
                ShowerWithChoose.IsEnabled = false;
            }
        }
        private void Bathtub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Bathtub.SelectedValue == "有")
            {
                BathtubChoose.IsEnabled = true;
            }
            else
            {
                BathtubChoose.IsEnabled = false;
            }
        }
        private void WashingMachine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WashingMachine.SelectedValue == "有")
            {
                WashingMachineChoose.IsEnabled = true;
            }
            else
            {
                WashingMachineChoose.IsEnabled = false;
            }
        }
        private void ConnectionBracket_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ConnectionBracket.SelectedValue == "有")
            {
                ConnectionBracketChoose.IsEnabled = true;
            }
            else
            {
                ConnectionBracketChoose.IsEnabled = false;
            }
        }
        private void LightingEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LightingEquipment.SelectedValue == "有")
            {
                LightingEquipmentChoose.IsEnabled = true;
            }
            else
            {
                LightingEquipmentChoose.IsEnabled = false;
            }
        }
        private void LightBulbBall_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LightBulbBall.SelectedValue == "有")
            {
                LightBulbBallChoose.IsEnabled = true;
            }
            else
            {
                LightBulbBallChoose.IsEnabled = false;
            }
        }
        private void Antenna_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Antenna.SelectedValue == "有")
            {
                AntennaChoose.IsEnabled = true;
            }
            else
            {
                AntennaChoose.IsEnabled = false;
            }
        }
        private void Fixedlinephone_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Fixedlinephone.SelectedValue == "有")
            {
                FixedlinephoneChoose.IsEnabled = true;
            }
            else
            {
                FixedlinephoneChoose.IsEnabled = false;
            }
        }
        private void Phone_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Phone.SelectedValue == "有")
            {
                PhoneChoose.IsEnabled = true;
            }
            else
            {
                PhoneChoose.IsEnabled = false;
            }
        }
        private void Internet_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Internet.SelectedValue == "有")
            {
                InternetChoose.IsEnabled = true;
            }
            else
            {
                InternetChoose.IsEnabled = false;
            }
        }
        private void Provider_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Provider.SelectedValue == "有")
            {
                ProviderChoose.IsEnabled = true;
            }
            else
            {
                ProviderChoose.IsEnabled = false;
            }
        }
        private void Electricity_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Electricity.SelectedValue == "有")
            {
                ElectricityChoose.IsEnabled = true;
            }
            else
            {
                ElectricityChoose.IsEnabled = false;
            }
        }
        private void GarbageStorage_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (GarbageStorage.SelectedValue == "有")
            {
                GarbageStorageChoose.IsEnabled = true;
            }
            else
            {
                GarbageStorageChoose.IsEnabled = false;
            }
        }
        private void Pet_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Pet.SelectedValue == "可")
            {
                PetChoose.IsEnabled = true;
            }
            else
            {
                PetChoose.IsEnabled = false;
            }
        }
        private void Storage_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (Storage.SelectedValue == "有")
            {
                StorageChoose.IsEnabled = true;
            }
            else
            {
                StorageChoose.IsEnabled = false;
            }
        }
        private void UseNoYes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (UseNoYes.SelectedValue == "有")
            {
                UseNoYesChoose.IsEnabled = true;
            }
            else
            {
                UseNoYesChoose.IsEnabled = false;
            }
        }
        private void HotSpring_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (HotSpring.SelectedValue == "有")
            {
                HotSpringChoose.IsEnabled = true;
            }
            else
            {
                HotSpringChoose.IsEnabled = false;
            }
        }
        private void OtherHouse_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (OtherHouse.SelectedValue == "有")
            {
                OtherHouseChoose.IsEnabled = true;
            }
            else
            {
                OtherHouseChoose.IsEnabled = false;
            }
        }
        private void OtherConditions_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (OtherConditions.SelectedValue == "有")
            {
                OtherConditionsChoose.IsEnabled = true;
            }
            else
            {
                OtherConditionsChoose.IsEnabled = false;
            }
        }
    }
}